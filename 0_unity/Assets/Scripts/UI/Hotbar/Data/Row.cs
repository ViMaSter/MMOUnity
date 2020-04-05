using UnityEngine;

namespace UI.Hotbar.Data
{
    public class Row
    {
        public const int AvailableActionCount = 12;
        
        [SerializeField]
        private Game.Data.Actions.Action[] actionIDs = default;
        public Row()
        {
            actionIDs = new Game.Data.Actions.Action[AvailableActionCount];
        }

        public void SetAction(int index, Game.Data.Actions.Action actionID)
        {
            if (index >= AvailableActionCount)
            {
                Debug.LogError($"Action index '{index}' is out of bounds (max is {AvailableActionCount-1})");
            }

            actionIDs[index] = actionID;
        }

        public Game.Data.Actions.Action this[int key]
        {
            get => actionIDs[key];
            set => SetAction(key, value);
        }
    }
}