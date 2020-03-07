using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActionList : MonoBehaviour
{
    private Vector2 position = new Vector2(Screen.width - (ButtonSize + ButtonPadding) * 2, 0);
    [SerializeField]
    private int[] availableActions = new int[] {};

    const int ButtonSize = 50;
    const int ButtonPadding = 10;

    void OnGUI()
    {
        for (int i = 0; i < availableActions.Length; i++)
        {
            if (GUI.Button(new Rect(position.x, position.y + ((ButtonSize + ButtonPadding) * (i / 2)), ButtonSize, ButtonSize), availableActions[i].ToString()))
            {
                HotbarDataManager.Instance.ActionToMap = ScriptableObject.CreateInstance<ActionID>().Init(availableActions[i]);
            }
            ++i;
            if (availableActions.Length <= i)
            {
                return;
            }

            if (GUI.Button(new Rect(position.x + ButtonSize + ButtonPadding, position.y + ((ButtonSize + ButtonPadding) * (i / 2)), ButtonSize, ButtonSize), availableActions[i].ToString()))
            {
                HotbarDataManager.Instance.ActionToMap = ScriptableObject.CreateInstance<ActionID>().Init(availableActions[i]);
            }
        }
    }
}
