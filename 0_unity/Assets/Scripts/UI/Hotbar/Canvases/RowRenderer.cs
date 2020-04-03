using UnityEngine;

namespace UI.Hotbar.Canvases
{
    public class RowRenderer : MonoBehaviour
    {
        [SerializeField]
        Data.Container inspectedContainer;

        public enum ORIENTATION
        {
            HORIZONTAL,
            VERTICAL
        };

        public int hotbarID;

        public Vector2 positionOffset = Vector2.zero;

        public Vector2 position
        {
            get
                => new Vector2(
                    (Screen.width - (((Data.Row.AvailableActionCount * (BoxSize + BoxMargin)) - BoxMargin))) / 2,
                    Screen.height - ((BoxSize + BoxMargin) * (hotbarID + 1))
                ) + positionOffset;
        }

        public ORIENTATION orientation = ORIENTATION.HORIZONTAL;

        private Data.Row rowData;

        private GUIStyle style = new GUIStyle();
        private Texture2D whiteTexture;
        void CreateTexture()
        {
            whiteTexture = new Texture2D(1, 1);
            whiteTexture.SetPixel(0, 0, Color.white);
            whiteTexture.Apply();
        }

        public void Awake()
        {
            CreateTexture();

            rowData = inspectedContainer[hotbarID];
            style.normal.background = whiteTexture;
        }

        private const int BoxSize = 50;
        private const int BoxMargin = 10;

        private Rect GenerateButtonPosition(int buttonIndex)
        {
            int iconOffset = (BoxSize + BoxMargin) * buttonIndex;
            return new Rect(
                (orientation == ORIENTATION.HORIZONTAL ? iconOffset : 0) + position.x,
                (orientation == ORIENTATION.VERTICAL ? iconOffset : 0) + position.y,
                BoxSize,
                BoxSize
            );
        }

        private Rect GenerateOrientationFlipPosition()
        {
            Rect flipOrientationRect = GenerateButtonPosition(0);
            return new Rect(
                flipOrientationRect.xMin - 25,
                flipOrientationRect.yMin,
                15,
                15
            );
        }

        private Vector2 CursorPositionInUISpace
        {
            get
            {
                return new Vector2(
                    Input.mousePosition.x,
                    Screen.height - Input.mousePosition.y
                );
            }
        }

        Vector2 lastMousePosition = -Vector2.one;
        bool isInMovingMode
        {
            get
            {
                return lastMousePosition != -Vector2.one;
            }
        }

        private void ApplyMovement()
        {
            if (!isInMovingMode)
            {
                return;
            }

            Vector2 mouseDelta = CursorPositionInUISpace - lastMousePosition;
            if (!Input.GetMouseButton(0))
            {
                lastMousePosition = -Vector2.one;
                return;
            }

            positionOffset += mouseDelta;
            lastMousePosition = CursorPositionInUISpace;
        }

        public void OnGUI()
        {
            ApplyMovement();

            if (GUI.Button(GenerateOrientationFlipPosition(), ""))
            {
                orientation = orientation == ORIENTATION.HORIZONTAL ? ORIENTATION.VERTICAL : ORIENTATION.HORIZONTAL;
            }

            for (int i = 0; i < Data.Row.AvailableActionCount; i++)
            {
                if (!isInMovingMode && Input.GetButton("Unlock UI") && GenerateButtonPosition(i).Contains(CursorPositionInUISpace) && Input.GetMouseButton(0))
                {
                    lastMousePosition = CursorPositionInUISpace;
                    return;
                }

                bool hasAction = rowData[i] != null;
                GUI.color = hasAction ? Color.green : Color.red;

                if (GUI.Button(GenerateButtonPosition(i), i.ToString() + (!hasAction ? "" : "\r\n" + rowData[i]), style))
                {
                    if (inspectedContainer.ActionToMap != null)
                    {
                        inspectedContainer.SetMapping(hotbarID, i, inspectedContainer.ActionToMap);
                        inspectedContainer.ActionToMap = null;
                        continue;
                    }

                    if (!hasAction)
                    {
                        Debug.LogWarning($"UI action {hotbarID}/{i} is not mapped");
                        continue;
                    }
                    Debug.Log($"Run UI action {hotbarID}/{i}: {rowData[i]}");
                }
            }
        }
    }

}