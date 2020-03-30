using System.Linq;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "AreaOfEffectAttack", menuName = "Data/Attack/Area of Effect", order = 101)]
    public class AreaOfEffectAttack : Attack
    {
        [SerializeField]
        private float attackValueAtCenter;
        public float AttackValueAtCenter => attackValueAtCenter;
        
        [SerializeField]
        private float radius;
        public float Radius => radius;
        
        [SerializeField]
        private AnimationCurve falloffByDistance;
        public AnimationCurve FalloffByDistance => falloffByDistance;

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