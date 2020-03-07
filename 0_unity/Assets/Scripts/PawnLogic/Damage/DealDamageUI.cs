using UnityEngine;

public class DealDamageUI : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Selector>().OnSelectionChanged += OnSelectionChanged;
    }

    Killable killableTarget;
    public void OnSelectionChanged(Selectable newSelection)
    {
        killableTarget = newSelection?.GetComponent<Killable>();
    }

    private void OnGUI()
    {
        if (killableTarget == null)
        {
            return;
        }

        int[] damageIntervals = new int[] {10, 20, 50, 100};
        for (int i = 0; i < damageIntervals.Length; i++)
        {
            if (GUI.Button(new Rect(0, 50 * i, 200, 50), $"Deal {damageIntervals[i]} damage"))
            {
                killableTarget.InflictDamage(damageIntervals[i]);
            }
        }
    }
}
