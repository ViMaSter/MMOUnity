using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killable : MonoBehaviour
{
    public delegate void wasKilledEvent();
    public event wasKilledEvent WasKilled;
    
    public delegate void tookDamageEvent(float damageApplied, float newHealth);
    public event tookDamageEvent TookDamage;

    public float GetCurrentHealth => CurrentHealth;
    public float MaximumHealth = 100;

    private float _currentHealth;
    private float CurrentHealth
    {
        get => _currentHealth;
        set
        {
            _currentHealth = Mathf.Max(0, value);
        }
    }

    private void Awake()
    {
        CurrentHealth = MaximumHealth;
    }

    public void InflictDamage(float damage, Vector2 worldSourcePosition)
    {
        CurrentHealth -= damage;
        if (TookDamage != null)
        {
            TookDamage(damage, CurrentHealth);
        }
        
        if (CurrentHealth == 0)
        {
            if (WasKilled == null)
            {
                Debug.LogWarning($"Object {gameObject.name} has died but has no 'wasKilled' event.", this);
                return;
            }
            WasKilled();
        }
    }
}
