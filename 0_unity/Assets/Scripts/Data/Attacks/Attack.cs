using UnityEngine;

namespace Data
{
    public abstract class Attack : ScriptableObject
    {
        [SerializeField]
        private string displayName;
        public string DisplayName => displayName;
        
        [SerializeField]
        private Texture2D icon;
        public Texture2D Icon => icon;
    }
}