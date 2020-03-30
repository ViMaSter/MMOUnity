using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "SingleTargetAttack", menuName = "Data/Attack/Single Target", order = 100)]
    public class SingleTargetAttack : Attack
    {
        [SerializeField]
        private float regularAttackValue;
        public float RegularAttackValue => regularAttackValue;
        
        [SerializeField]
        private bool isPositional;
        public bool IsPositional => isPositional;

        private bool IsInRange(Killable target, Component source)
        {
            return Vector2.Distance(Utilities.Combat.ComponentToCombatPosition(source), Utilities.Combat.ComponentToCombatPosition(target)) < Globals.Combat.Instance.MaximumMeleeRange;
        }

        public bool TryApply(Killable target, Component source)
        {
            if (IsInRange(target, source))
            {
                Debug.Log($"Unable to hit {target.gameObject.name}, as it is too far away");
                return false;
            }

            target.InflictDamage(regularAttackValue);
            return true;
        }
    }
}