using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace UI.Hotbar.Canvases
{
    public class ActionList : MonoBehaviour
    {
        [SerializeField]
        Data.Container container;

        private Vector2 position = new Vector2(Screen.width - (ButtonSize + ButtonPadding) * 2, 0);
        [SerializeField]
        private uint[] availableActions = new uint[] {};

        const int ButtonSize = 50;
        const int ButtonPadding = 10;

        void OnGUI()
        {
            for (int i = 0; i < availableActions.Length; i++)
            {
                if (GUI.Button(new Rect(position.x, position.y + ((ButtonSize + ButtonPadding) * (i / 2)), ButtonSize, ButtonSize), availableActions[i].ToString()))
                {
                    container.ActionToMap = new Data.ActionID(availableActions[i]);
                }
                ++i;
                if (availableActions.Length <= i)
                {
                    return;
                }

                if (GUI.Button(new Rect(position.x + ButtonSize + ButtonPadding, position.y + ((ButtonSize + ButtonPadding) * (i / 2)), ButtonSize, ButtonSize), availableActions[i].ToString()))
                {
                    container.ActionToMap = new Data.ActionID(availableActions[i]);
                }
            }
        }
    }
}
