using System;
using UnityEngine;

public class DealDamageUI : MonoBehaviour
{
    PlayerController playerController;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        GetComponent<SingleTargetSelector>().OnSelectionChanged += OnSelectionChanged;
    }

    Killable killableTarget;
    public void OnSelectionChanged(Selectable newSelection)
    {
        killableTarget = newSelection?.GetComponent<Killable>();
    }

    Action<Vector3?, RaycastHit[]> ApplyAoEDamage(float damage)
    {
        return (Vector3? position, RaycastHit[] targets) => {
            foreach(var target in targets)
            {
                target.transform.GetComponent<Killable>().InflictDamage(damage);
            }
            return;
        };
    }
    private void OnGUI()
    {
        int[] damageIntervals = new int[] {10, 20, 50, 100};
        for (int damageIndex = 0; damageIndex < damageIntervals.Length; damageIndex++)
        {
            int[] sizes = new int [] {1, 2, 5, 10};
            for (int sizeIndex = 0; sizeIndex < sizes.Length; sizeIndex++)
            {
                if (GUI.Button(new Rect(50 + 200 * (sizeIndex + 1), 50 * damageIndex, 200, 50), $"[AOE] Deal {damageIntervals[damageIndex]} damage (size {sizes[sizeIndex]})"))
                {
                    playerController.RetrieveAoESelectorPosition(sizes[sizeIndex], ApplyAoEDamage(damageIntervals[damageIndex]).Invoke);
                }
            }
            if (killableTarget != null)
            {
                if (GUI.Button(new Rect(0, 50 * damageIndex, 200, 50), $"[SINGLE] Deal {damageIntervals[damageIndex]} damage"))
                {
                    killableTarget.InflictDamage(damageIntervals[damageIndex]);
                }
            }
        }
    }
}
