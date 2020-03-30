using UnityEngine;

namespace Utilities
{
    public static class Combat
    {
        public static Vector2 WorldPositionToCombatPosition(Vector3 worldPosition)
        {
            return new Vector2(worldPosition.x, worldPosition.z);
        }
        public static Vector2 ComponentToCombatPosition(Component component)
        {
            return WorldPositionToCombatPosition(component.transform.position);
        }
        public static Vector3 CombatPositionToWorldPosition(Vector2 position)
        {
            return new Vector3(position.x, 0, position.y);
        }
    }
}
