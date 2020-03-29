using UnityEngine;

namespace Data
{
    public class Attack : ScriptableObject
    {
        [SerializeField]
        private string displayName;
        public string DisplayName => displayName;
        
        [SerializeField]
        private Texture2D icon;
        public Texture2D Icon => icon;
    }
    
    [CreateAssetMenu(fileName = "SingleTargetAttack", menuName = "Data/Attack/Single Target", order = 100)]
    public class SingleTargetAttack : Attack
    {
        [SerializeField]
        private float regularAttackValue;
        public float RegularAttackValue => regularAttackValue;
        
        [SerializeField]
        private bool isPositional;
        public bool IsPositional => isPositional;
    }
    
    [CreateAssetMenu(fileName = "AoETargetAttack", menuName = "Data/Attack/Area of Effect", order = 101)]
    public class AoEAttack : Attack
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
    }

}