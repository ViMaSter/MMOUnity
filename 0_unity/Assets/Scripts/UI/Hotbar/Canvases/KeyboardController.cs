using System.Collections.Generic;
using UnityEngine;

namespace UI.Hotbar.Canvases
    {
    public class KeyboardController : MonoBehaviour
    {
        [SerializeField]
        Data.Container inspectedContainer = default;

        private Dictionary<KeyCode, int> modifierToHotbarID = new Dictionary<KeyCode, int> {
            {KeyCode.LeftShift,      1},
            {KeyCode.RightShift,     1},
            {KeyCode.LeftControl,    2},
            {KeyCode.RightControl,   2},
            {KeyCode.LeftAlt,        3},
            {KeyCode.RightAlt,       3},
            {KeyCode.LeftCommand,    3},
            {KeyCode.RightCommand,   3}
        };

        private Dictionary<KeyCode, int> hotbarButtons = new Dictionary<KeyCode, int> {
            {KeyCode.Alpha1,        0},
            {KeyCode.Alpha2,        1},
            {KeyCode.Alpha3,        2},
            {KeyCode.Alpha4,        3},
            {KeyCode.Alpha5,        4},
            {KeyCode.Alpha6,        5},
            {KeyCode.Alpha7,        6},
            {KeyCode.Alpha8,        7},
            {KeyCode.Alpha9,        8},
            {KeyCode.Alpha0,        9},
            {KeyCode.Minus,         10},
            {KeyCode.Equals,        11},
            {KeyCode.LeftBracket,   10},
            {KeyCode.RightBracket,  11}
        };

        int DetermineModifier()
        {
            foreach (var mapping in modifierToHotbarID)
            {
                if (Input.GetKey(mapping.Key))
                {
                    return mapping.Value;
                }
            }
            
            return 0;
        }

        void Update()
        {
            int hotbarID = DetermineModifier();
            foreach (var hotbarButton in hotbarButtons)
            {
                if (Input.GetKeyDown(hotbarButton.Key))
                {
                    Debug.Log($"Run keyboard action {hotbarID}/{hotbarButton.Value}: {inspectedContainer[hotbarID][hotbarButton.Value]}");
                }
            }
        }
    }
}