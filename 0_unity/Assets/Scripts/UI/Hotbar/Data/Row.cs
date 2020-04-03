using UnityEngine;

namespace UI.Hotbar.Data
{
    public class Row
    {
        public const int AvailableActionCount = 12;
        
        [SerializeField] 
        private ActionID[] actionIDs;
        public Row()
        {
            actionIDs = new ActionID[AvailableActionCount];
        }

        public void SetAction(int index, ActionID actionID)
        {
            if (index >= AvailableActionCount)
            {
                Debug.LogError($"Action index '{index}' is out of bounds (max is {AvailableActionCount-1})");
            }

            actionIDs[index] = actionID;
        }

        public ActionID this[int key]
        {
            get => actionIDs[key];
            set => SetAction(key, value);
        }
    }
}