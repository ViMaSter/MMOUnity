﻿using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UI.Hotbar;

namespace UI.Hotbar.Data
{
    public class Container : MonoBehaviour
    {
        [SerializeField]
        private int availableRows = 4;

        [SerializeField]
        Dictionary<int, Row> actions;
        public void Awake()
        {
            actions = Enumerable.Range(0, availableRows).Select(index => new KeyValuePair<int, Row>(index, new Row())).ToDictionary(item => item.Key, item => item.Value);
        }

        public ActionID ActionToMap = null;

        public void SetMapping(int rowID, int columnID, ActionID actionID)
        {
            actions[rowID][columnID] = actionID;
        }

        public Row this[int key]
        {
            get => actions[key];
        }
    }
}