using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UI.Hotbar.Data
{
    public class Container : MonoBehaviour
    {
        [SerializeField]
        private int availableRows = 4;

        public int RowCount => availableRows;

        [SerializeField]
        private Dictionary<int, Row> actions = default;
        public void Awake()
        {
            actions = Enumerable.Range(0, availableRows).Select(index => new KeyValuePair<int, Row>(index, new Row())).ToDictionary(item => item.Key, item => item.Value);
        }

        public Game.Data.Actions.Action ActionToMap = null;

        public void SetMapping(int rowID, int columnID, Game.Data.Actions.Action actionID)
        {
            actions[rowID][columnID] = actionID;
        }

        public Row this[int key]
        {
            get => actions[key];
        }
    }
}
