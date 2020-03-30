using System;
using UnityEngine;

namespace Globals
{
    public class Combat : MonoBehaviour
    {
        [SerializeField]
        private float _maximumMeleeRange = 1.0f;
        public float MaximumMeleeRange => _maximumMeleeRange;

        

        private float _AoEHitHeightBounds = 100;
        public float AoEHitHeightBounds => _AoEHitHeightBounds;

        private static readonly Lazy<Combat> lazy = new Lazy<Combat>(() => {
            GameObject globals = GameObject.Find("GLOBALS") ?? new GameObject("GLOBALS");
            return globals.GetComponent<Combat>() ?? globals.AddComponent<Combat>();
        });

        public static Combat Instance
        {
            get
            {
                return lazy.Value;
            }
        }
    }
}