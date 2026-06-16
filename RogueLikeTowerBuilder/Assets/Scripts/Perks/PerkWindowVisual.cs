using UnityEngine;

public class PerkWindowVisual : MonoBehaviour
{
    /// <summary>
    /// Send through in order: shooting, targeting, bullet.
    /// </summary>
    /// <param name="perks"></param>
    public void Initialize(Perk[] perks)
    {
        PerkVisual[] children = transform.GetComponentsInChildren<PerkVisual>();

        for (int i = 0; i < children.Length; i++)
        {
            children[i].perk = perks[i];
        }
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    //private void OnEnable()
    //{
    //    Time.timeScale = 0;
    //}

    //private void OnDisable()
    //{
    //    Time.timeScale = 1f;
    //}
}
