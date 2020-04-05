using UnityEngine;

namespace UI.Hotbar.Canvases
{
    public class ActionList : MonoBehaviour
    {
        [SerializeField]
        Data.Container container = default;

        private Vector2 position = new Vector2(Screen.width - (ButtonSize + ButtonPadding) * 2, 0);
        [SerializeField]
        private Game.Data.Actions.Action[] availableActions = new Game.Data.Actions.Action[] {};

        const int ButtonSize = 50;
        const int ButtonPadding = 10;

        [SerializeField]
        private GUISkin Skin = default;

        void OnGUI()
        {
            for (int i = 0; i < availableActions.Length; i++)
            {
                GUIStyle buttonStyle = new GUIStyle(Skin.button);
                buttonStyle.normal.background = availableActions[i].Icon;
                buttonStyle.hover.background = availableActions[i].Icon;
                if (GUI.Button(new Rect(position.x, position.y + ((ButtonSize + ButtonPadding) * (i / 2)), ButtonSize, ButtonSize), availableActions[i].Name, buttonStyle))
                {
                    container.ActionToMap = availableActions[i];
                }
                ++i;
                if (availableActions.Length <= i)
                {
                    return;
                }

                if (GUI.Button(new Rect(position.x + ButtonSize + ButtonPadding, position.y + ((ButtonSize + ButtonPadding) * (i / 2)), ButtonSize, ButtonSize), availableActions[i].Name, buttonStyle))
                {
                    container.ActionToMap = availableActions[i];
                }
            }
        }
    }
}
