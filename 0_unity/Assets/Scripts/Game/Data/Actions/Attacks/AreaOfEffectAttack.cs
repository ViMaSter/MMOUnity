using System.Linq;
using UnityEngine;

namespace Game.Data.Actions.Attacks
{
    [CreateAssetMenu(fileName = "AreaOfEffectAttack", menuName = "Data/Attack/Area of Effect", order = 101)]
    public class AreaOfEffectAttack : Game.Data.Actions.Attack
    {
        [SerializeField]
        private float attackValueAtCenter = default;
        public float AttackValueAtCenter => attackValueAtCenter;
        
        [SerializeField]
        private float radius = default;
        public float Radius => radius;
        
        [SerializeField]
        private AnimationCurve falloffByDistance = default;
        public AnimationCurve FalloffByDistance => falloffByDistance;

        public override bool CanBeExecuted(Transform executor, Transform target)
        {
            return CanApply(target.position, executor);
        }

        public override bool Execute(Transform executor, Transform target)
        {
            var targetHittable = target.GetComponent<Killable>();
            return TryApply(target.position, executor);
        }

        public bool CanApply(Vector2 worldTargetPosition, Component source)
        {
            return true;
        }

        public bool TryApply(Vector2 worldTargetPosition, Component source)
        {
            var affectedKillables = Physics.CapsuleCastAll(
                Utilities.Combat.CombatPositionToWorldPosition(worldTargetPosition) - (Vector3.up * Globals.Combat.Instance.AoEHitHeightBounds),
                Utilities.Combat.CombatPositionToWorldPosition(worldTargetPosition) + (Vector3.up * Globals.Combat.Instance.AoEHitHeightBounds),
                Radius,
                Vector3.up
            ).Where(hit => hit.transform.GetComponent<Killable>() != null).Select(hit => hit.transform.GetComponent<Killable>());

            foreach (var affectedKillable in affectedKillables)
            {
                affectedKillable.InflictDamage(attackValueAtCenter);
            }

            if (!affectedKillables.Any())
            {
                Debug.LogWarning("AoE hit no targets!");
            }

            return true;
        }
    }

}