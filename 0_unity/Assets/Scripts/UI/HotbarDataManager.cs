using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionID : ScriptableObject
{
    public int? ID = null;
    public ActionID Init(int ID)
    {
        this.ID = ID;
        return this;
    }

    public override string ToString()
    {
        return ID.ToString();
    }
}

[Serializable]
public class HotbarActions : ScriptableObject
{
    public const int ActionsPerBar = 12;
    
    [SerializeField] 
    private ActionID[] actionIDs;
    public HotbarActions()
    {
        actionIDs = new ActionID[ActionsPerBar];
    }

    public void SetAction(int index, ActionID actionID)
    {
        if (index >= ActionsPerBar)
        {
            Debug.LogError($"Action index '{index}' is out of bounds (max is {ActionsPerBar-1})");
        }

        actionIDs[index] = actionID;
    }

    public ActionID this[int key]
    {
        get => actionIDs[key];
        set => SetAction(key, value);
    }
}

[Serializable] public class HotbarMapping : SerializableDictionary<int, HotbarActions>{};

public class HotbarDataManager : MonoBehaviour
{
    private static HotbarDataManager _instance;
    public static HotbarDataManager Instance {
        get => _instance;
        set {
            if (_instance != null) 
            {
                Debug.LogError("HotbarDataManager already set!");
            }
            _instance = value;
        }
    }

    [SerializeField]
    HotbarMapping actions;
    public void Awake()
    {
        Instance = this;

        actions = new HotbarMapping() {
            {0, ScriptableObject.CreateInstance<HotbarActions>()},
            {1, ScriptableObject.CreateInstance<HotbarActions>()},
            {2, ScriptableObject.CreateInstance<HotbarActions>()},
            {3, ScriptableObject.CreateInstance<HotbarActions>()}
        };
    }

    public ActionID ActionToMap = null;

    public void SetMapping(int rowID, int columnID, ActionID actionID)
    {
        actions[rowID][columnID] = actionID;
    }

    public HotbarActions this[int key]
    {
        get => actions[key];
    }
}
