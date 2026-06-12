using UnityEngine;

public class PerkWindowVisual : MonoBehaviour
{
    /// <summary>
    /// Send through in order: shooting, targeting, bullet.
    /// </summary>
    /// <param name="perks"></param>
    public void Initialize(PerkNames[] perks)
    {
        PerkVisual[] children = transform.GetComponentsInChildren<PerkVisual>();

        for (int i = 0; i < children.Length; i++)
        {
            children[i].perk = perks[i];
        }
    }
}
