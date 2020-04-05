using UnityEngine;
using System;
using System.Collections.Generic;

namespace UI.Hotbar.Canvases
{
    public class CrossBarRenderer : MonoBehaviour
    {
        public float doublePressThresholdInSeconds = 0.5f;
        Tuple<string, float> lastMenuPressAt = null;
        CrossAnchors activeAnchor = CrossAnchors.NONE;

        List<string> toggles = new List<string>{"L", "R"};
        private bool ValidateLastPress(string toggle)
        {
            if (lastMenuPressAt == null)
            {
                lastMenuPressAt = new Tuple<string, float>(toggle, Time.time);
                return false;
            }
            
            if (lastMenuPressAt.Item1 != toggle)
            {
                lastMenuPressAt = new Tuple<string, float>(toggle, Time.time);
                return false;
            }
            
            if (lastMenuPressAt.Item2 + doublePressThresholdInSeconds < Time.time)
            {
                lastMenuPressAt = new Tuple<string, float>(toggle, Time.time);
                return false;
            }
            
            return true;
        }

        private void Update()
        {
            activeAnchor = DetermineActiveAnchor();
            for (int i = 0; i < 4; ++i)
            {
                if (Input.GetButtonDown("Cross Hotbar - Action L"+i))
                {
                    Debug.Log($"Action: {activeAnchor}|{i}");
                }
                if (Input.GetButtonDown("Cross Hotbar - Action R"+i))
                {
                    Debug.Log($"Action: {activeAnchor}|{i+4}");
                }
            }
        }

        private CrossAnchors DetermineActiveAnchor()
        {
            if (Input.GetButton("Cross Hotbar - Toggle R") && Input.GetButtonDown("Cross Hotbar - Toggle L"))
            {
                return CrossAnchors.COMBO_LEFT;
            }
            
            
            if (Input.GetButton("Cross Hotbar - Toggle L") && Input.GetButtonDown("Cross Hotbar - Toggle R"))
            {
                return CrossAnchors.COMBO_RIGHT;
            }

            if (Input.GetButtonDown("Cross Hotbar - Toggle L"))
            {
                bool isDoublePress = ValidateLastPress("L");
                if (isDoublePress)
                {
                    return CrossAnchors.SECONDARY_LEFT;
                }
                else
                {
                    return CrossAnchors.PRIMARY_LEFT;
                }
            }

            if (Input.GetButtonDown("Cross Hotbar - Toggle R"))
            {
                bool isDoublePress = ValidateLastPress("R");
                if (isDoublePress)
                {
                    return CrossAnchors.SECONDARY_RIGHT;
                }
                else
                {
                    return CrossAnchors.PRIMARY_RIGHT;
                }
            }

            if (Input.GetButton("Cross Hotbar - Toggle L"))
            {
                return activeAnchor != CrossAnchors.NONE ? activeAnchor : CrossAnchors.PRIMARY_LEFT;
            }

            if (Input.GetButton("Cross Hotbar - Toggle R"))
            {
                return activeAnchor != CrossAnchors.NONE ? activeAnchor : CrossAnchors.PRIMARY_RIGHT;
            }

            return CrossAnchors.NONE;
        }

        [SerializeField]
        private Data.Container inspectedContainer = default;

        [SerializeField]
        private int currentPrimaryRowID = 0;
        private int currentSecondaryRowID
        {
            get => (currentPrimaryRowID + 1) % inspectedContainer.RowCount;
        }

        [Header("Styling")]

        [SerializeField]
        private Vector2 positionOffset = Vector2.zero;
        [SerializeField]
        private float BoxSize = 50;

        [SerializeField]
        private float BoxMargin = 10;

        [SerializeField]
        private float CenterMargin = 10;

        [SerializeField]
        private float MappingBlockMargin = 1.75f;

        [Header("Debug")]
        [SerializeField]
        private float debugVisualizationBoxSize = 5;

        private Vector2 defaultPosition
        {
            get => new Vector2(
                Screen.width / 2,
                Screen.height - (BoxSize * 2)
            );
        }

        private Vector2 currentPosition
        {
            get => defaultPosition + positionOffset;
        }

        enum CrossAnchors
        {
            NONE,
            PRIMARY_LEFT = 1,
            PRIMARY_RIGHT = 2,
            SECONDARY_LEFT = 3,
            SECONDARY_RIGHT = 4,
            COMBO_LEFT,
            COMBO_RIGHT
        }

        enum MappingBlock
        {
            LEFT = -1,
            RIGHT = 1
        }

        private readonly Dictionary<CrossAnchors, Vector2> relativeOffsetByAnchorFromCenter = new Dictionary<CrossAnchors, Vector2>
        {
            {CrossAnchors.PRIMARY_LEFT,     new Vector2(-3.5f,  0  )},
            {CrossAnchors.PRIMARY_RIGHT,    new Vector2( 3.5f, 0  )},
            {CrossAnchors.SECONDARY_LEFT,   new Vector2(-3.5f,  -3f)},
            {CrossAnchors.SECONDARY_RIGHT,  new Vector2( 3.5f, -3f)},
        };

        private readonly Dictionary<int, Vector2> relativeOffsetByButton = new Dictionary<int, Vector2>
        {
            {0, new Vector2( 0, 0.625f)},
            {1, new Vector2( 1, 0)},
            {2, new Vector2( 0, -0.625f)},
            {3, new Vector2(-1, 0)},
        };

        private Vector2 GenerateAnchorOffsetFromCenter(CrossAnchors anchorPosition, MappingBlock mappingBlock)
            => new Vector2((CenterMargin * Mathf.Sign(relativeOffsetByAnchorFromCenter[anchorPosition].x) + ((int)mappingBlock * MappingBlockMargin * BoxSize)), 0) + (BoxSize * relativeOffsetByAnchorFromCenter[anchorPosition]);

        private Vector2 GenerateButtonOffset(int buttonIndex)
            => (BoxSize) * relativeOffsetByButton[buttonIndex] + (BoxMargin) * relativeOffsetByButton[buttonIndex];

        private Vector2 GenerateButtonPosition(CrossAnchors anchor, int buttonIndex, MappingBlock mappingBlock)
        {
            return GenerateAnchorOffsetFromCenter(anchor, mappingBlock) + GenerateButtonOffset(buttonIndex);
        }

        List<CrossAnchors> renderedAnchors = new List<CrossAnchors>
        {
            CrossAnchors.PRIMARY_LEFT,
            CrossAnchors.PRIMARY_RIGHT,
            CrossAnchors.SECONDARY_LEFT,
            CrossAnchors.SECONDARY_RIGHT,
        };

        public void OnGUI()
        {
            if (debugVisualizationBoxSize > 0)
            {
                GUI.Label(new Rect(0, Screen.height - 25, Screen.width, 25), "White: Center | Blue: Anchor");
                GUI.backgroundColor = Color.white;

                Color previousBackgroundColor = GUI.backgroundColor;

                GUI.Button(new Rect(currentPosition.x - debugVisualizationBoxSize, currentPosition.y - debugVisualizationBoxSize, debugVisualizationBoxSize * 2, debugVisualizationBoxSize * 2), "", new GUIStyle { normal = new GUIStyleState { background = Texture2D.whiteTexture } });
                foreach (var renderedAnchor in renderedAnchors)
                {
                    GUI.backgroundColor = Color.blue;
                    {
                        var anchorOffset = GenerateAnchorOffsetFromCenter(renderedAnchor, MappingBlock.LEFT);
                        GUI.Button(new Rect((currentPosition.x - debugVisualizationBoxSize) + anchorOffset.x, (currentPosition.y - debugVisualizationBoxSize) + anchorOffset.y, debugVisualizationBoxSize * 2, debugVisualizationBoxSize * 2), "", new GUIStyle { normal = new GUIStyleState { background = Texture2D.whiteTexture } });
                    }
                    {
                        var anchorOffset = GenerateAnchorOffsetFromCenter(renderedAnchor, MappingBlock.RIGHT);
                        GUI.Button(new Rect((currentPosition.x - debugVisualizationBoxSize) + anchorOffset.x, (currentPosition.y - debugVisualizationBoxSize) + anchorOffset.y, debugVisualizationBoxSize * 2, debugVisualizationBoxSize * 2), "", new GUIStyle { normal = new GUIStyleState { background = Texture2D.whiteTexture } });
                    }
                }
                GUI.backgroundColor = previousBackgroundColor;
            }

            foreach (var renderedAnchor in renderedAnchors)
            {
                GUI.backgroundColor = activeAnchor == renderedAnchor ? Color.green : Color.white;
                // left cross
                for (int buttonIndex = 0; buttonIndex < 4; buttonIndex++)
                {
                    Vector2 buttonPosition = currentPosition + GenerateButtonPosition(renderedAnchor, buttonIndex, MappingBlock.LEFT) - (BoxSize * Vector2.one * 0.5f);
                    GUI.Button(new Rect(buttonPosition.x, buttonPosition.y, BoxSize, BoxSize), buttonIndex.ToString());
                }
                // right cross
                for (int buttonIndex = 0; buttonIndex < 4; buttonIndex++)
                {
                    Vector2 buttonPosition = currentPosition + GenerateButtonPosition(renderedAnchor, buttonIndex, MappingBlock.RIGHT) - (BoxSize * Vector2.one * 0.5f);
                    GUI.Button(new Rect(buttonPosition.x, buttonPosition.y, BoxSize, BoxSize), buttonIndex.ToString());
                }
            }
        }
    }

}