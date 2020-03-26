using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnDeath : MonoBehaviour
{
    private void OnDeath()
    {
        Destroy(this.gameObject);
    }

    private void Awake()
    {
        GetComponent<Killable>().WasKilled += OnDeath;
    }
}
