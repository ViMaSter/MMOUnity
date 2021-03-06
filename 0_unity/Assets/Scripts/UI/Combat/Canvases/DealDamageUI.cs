﻿using System;
using System.Collections.Generic;
using UnityEngine;

namespace UI.Combat.Canvases
{
    [Serializable] public class AreaOfEffectStorage : SerializableDictionary.Storage<List<Game.Data.Actions.Attacks.AreaOfEffectAttack>> {} 
    [Serializable] public class AreaOfEffectDictionary : SerializableDictionary<string, List<Game.Data.Actions.Attacks.AreaOfEffectAttack>, AreaOfEffectStorage> {} 

    public class DealDamageUI : MonoBehaviour
    {
        TargettingController targettingController;

        [SerializeField]
        Game.Data.Actions.Attacks.SingleTargetAttack[] singleTargetAttacks = default;

        [SerializeField]
        AreaOfEffectDictionary areaOfEffectAttacksByRadius = default;
        private void Awake()
        {
            targettingController = GetComponent<TargettingController>();
            GetComponent<SingleTargetSelector>().OnSelectionChanged += OnSelectionChanged;
        }

        Killable killableTarget;
        public void OnSelectionChanged(Selectable newSelection)
        {
            killableTarget = newSelection?.GetComponent<Killable>();
        }

        Action<Vector3?> ApplyAoEDamage(Game.Data.Actions.Attacks.AreaOfEffectAttack attack)
        {
            return (Vector3? position) => {
                if (!position.HasValue)
                {
                    return;
                }

                attack.TryApply(Utilities.Combat.WorldPositionToCombatPosition(position.Value), this);
            };
        }

        private void OnGUI()
        {
            {
                int column = 0;
                foreach (var entry in areaOfEffectAttacksByRadius)
                {
                    (string radius, List<Game.Data.Actions.Attacks.AreaOfEffectAttack> attacks) = entry;
                    int row = 0;
                    foreach (var attack in attacks)
                    {
                        if (GUI.Button(new Rect(250 + 200 * (column), 50 * row, 200, 50), $"[AOE] Damage: {attack.AttackValueAtCenter} | Radius: {attack.Radius}"))
                        {
                            targettingController.RetrieveAoESelectorPosition(attack.Radius, ApplyAoEDamage(attack).Invoke);
                        }
                        ++row;
                    }
                    ++column;
                }
            }

            if (killableTarget == null)
            {
                return;
            }

            for (int i = 0; i < singleTargetAttacks.Length; ++i)
            {
                if (GUI.Button(new Rect(0, 50 * i, 200, 50), $"[SINGLE] Damage: {singleTargetAttacks[i].RegularAttackValue}"))
                {
                    singleTargetAttacks[i].TryApply(killableTarget, this);
                }
            }
        }
    }
}