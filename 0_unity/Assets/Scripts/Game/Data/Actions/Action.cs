using System;
using UnityEngine;

namespace Game.Data.Actions
{
    public abstract class Action : ScriptableObject
    {

        public virtual string Name
        {
            get => throw new NotImplementedException("Derivative has no implementation!");
        }
        public virtual Texture2D Icon
        {
            get
            {
                return Resources.Load<Texture2D>("Textures/Defaults/DefaultIcon");
            }
        }

        public abstract bool CanBeExecuted(Transform executor, Transform target);
        public abstract bool Execute(Transform executor, Transform target);
    }
}