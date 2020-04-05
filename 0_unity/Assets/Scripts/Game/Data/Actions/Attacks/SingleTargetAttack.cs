using UnityEngine;

namespace Game.Data.Actions.Attacks
{
    [CreateAssetMenu(fileName = "SingleTargetAttack", menuName = "Data/Attack/Single Target", order = 100)]
    public class SingleTargetAttack : Game.Data.Actions.Attack
    {
        [SerializeField]
        private float regularAttackValue = default;
        public float RegularAttackValue => regularAttackValue;
        
        [SerializeField]
        private bool isPositional = default;
        public bool IsPositional => isPositional;

        public override bool CanBeExecuted(Transform executor, Transform target)
        {
            if (target == null)
            {
                return false;
            }

            var targetHittable = target.GetComponent<Killable>();
            if (targetHittable == null)
            {
                return false;
            }

            return true;
        }

        public override bool Execute(Transform executor, Transform target)
        {
            if (target == null)
            {
                return false;
            }

            var targetHittable = target.GetComponent<Killable>();
            if (targetHittable == null)
            {
                return false;
            }

            return TryApply(targetHittable, executor);
        }

        private bool IsInRange(Killable target, Component source)
        {
            return Vector2.Distance(Utilities.Combat.ComponentToCombatPosition(source), Utilities.Combat.ComponentToCombatPosition(target)) < Globals.Combat.Instance.MaximumMeleeRange;
        }

        public bool CanApply(Killable target, Component source)
        {
            if (IsInRange(target, source))
            {
                Debug.Log($"Unable to hit {target.gameObject.name}, as it is too far away");
                return false;
            }

            return true;
        }

        public bool TryApply(Killable target, Component source)
        {
            if (!CanApply(target, source))
            {
                return false;
            }

            target.InflictDamage(regularAttackValue);
            return true;
        }
    }
}