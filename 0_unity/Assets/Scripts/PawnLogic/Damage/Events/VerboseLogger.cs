using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerboseLogger : MonoBehaviour
{
    private void OnDamage(float damage, float newHealth)
    {
        Debug.Log($"'{gameObject.name}' took '{damage}' damage and is now at '{newHealth}' health.");
    }

    private void OnDeath()
    {
        Debug.Log($"'{gameObject.name}' has died!");
    }

    private void Awake()
    {
        GetComponent<Killable>().tookDamage += OnDamage;
        GetComponent<Killable>().wasKilled += OnDeath;
    }
}
