﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI.Combat.Widgets
{
    public class Healthbar : MonoBehaviour
    {
        Killable owningKillable;
        RectTransform FGTransform;
        private void Awake()
        {
            owningKillable = transform.parent.GetComponent<Killable>();
            FGTransform = transform.Find("FG").GetComponent<RectTransform>();
            RefreshRendering(0, 0);
            owningKillable.TookDamage += RefreshRendering;
        }

        void SetPercentage(float percentage)
        {
            FGTransform.localScale = new Vector3(percentage, 1, 1);
        }

        void RefreshRendering(float damageApplied, float newHealth)
        {
            SetPercentage(owningKillable.GetCurrentHealth / owningKillable.MaximumHealth);
        }
    }
}