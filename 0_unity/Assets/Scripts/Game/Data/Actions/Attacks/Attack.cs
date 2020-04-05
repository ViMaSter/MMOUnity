using UnityEngine;

namespace Game.Data.Actions
{
    public abstract class Attack : Game.Data.Actions.Action
    {
        [SerializeField]
        private string displayName = default;
        
        [SerializeField]
        private Texture2D hotbarImage = default;

        public override string Name => displayName ?? base.Name;
        public override Texture2D Icon 
        {
            get
            {
                return hotbarImage == null ? base.Icon : hotbarImage;
            }
        }
    }
}