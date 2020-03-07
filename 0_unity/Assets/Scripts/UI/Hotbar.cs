using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Hotbar : MonoBehaviour
{
    public enum ORIENTATION
    {
        HORIZONTAL,
        VERTICAL
    };

    public int hotbarID;

    public Vector2 position {
        get
            => new Vector2(
                (Screen.width - (((HotbarActions.ActionsPerBar * (BoxSize + BoxMargin)) - BoxMargin)))/2,
                Screen.height - ((BoxSize + BoxMargin) * (hotbarID + 1))
            );
    }
    public ORIENTATION orientation = ORIENTATION.HORIZONTAL;

    private HotbarActions actions;
    
    private GUIStyle style = new GUIStyle();
    private Texture2D whiteTexture;
    void CreateTexture()
    {
        whiteTexture = new Texture2D( 1, 1 );
        whiteTexture.SetPixel( 0, 0, Color.white );
        whiteTexture.Apply();
    }

    public void Awake()
    {
        CreateTexture();

        actions = HotbarDataManager.Instance[hotbarID];
        style.normal.background = whiteTexture;
    }

    private const int BoxSize = 50;
    private const int BoxMargin = 10;

    public void OnGUI()
    {
        for(int i = 0; i < HotbarActions.ActionsPerBar; i++)
        {
            bool hasAction = actions[i] != null;
            GUI.color = hasAction ? Color.green : Color.red;

            int iconOffset = (BoxSize+BoxMargin) * i;
            if (GUI.Button(new Rect(
                (orientation == ORIENTATION.HORIZONTAL ? iconOffset : 0) + position.x,
                (orientation == ORIENTATION.VERTICAL ? iconOffset : 0) + position.y,
                BoxSize,
                BoxSize
            ), i.ToString() + (!hasAction ? "" : "\r\n"+actions[i]), style))
            {
                if (HotbarDataManager.Instance.ActionToMap != null)
                {
                    HotbarDataManager.Instance.SetMapping(hotbarID, i, HotbarDataManager.Instance.ActionToMap);
                    HotbarDataManager.Instance.ActionToMap = null;
                    continue;
                }

                if (!hasAction)
                {
                    Debug.LogWarning($"UI action {hotbarID}/{i} is not mapped");
                    continue;
                }
                Debug.Log($"Run UI action {hotbarID}/{i}: {actions[i]}");
            }
        }
    }
}
