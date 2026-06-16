using System.Collections.Generic;
using UnityEngine;

public class BuildMode : MonoBehaviour
{
    [SerializeField] GameObject indicator;
    [SerializeField] GameObject PerkWindow;

    public List<Perk> perks = new List<Perk>();
    CashManager cash;
    int towerCost = 5;

    private void Start()
    {
        cash = FindAnyObjectByType<CashManager>();
    }
    public void EnableBuildMode()
    {
        if (!cash.CheckCash(towerCost)) return;
        CashEvents.RemoveCashEvent?.Invoke(towerCost);
        PerkWindow.SetActive(true);
        PerkWindow.GetComponent<PerkWindowVisual>().Initialize(GetCurrentPerks(FindAnyObjectByType<PerkManager>().RunPerks()));
    }

    Perk[] GetCurrentPerks(PerkNames[] _perkNames)
    {
        FindAnyObjectByType<PlaceTower>().perks = _perkNames;
        List<Perk> chosenPerks = new List<Perk>();
        foreach (PerkNames perk in _perkNames)
        {
            for (int i = 0; i < perks.Count; i++)
            {
                if (perk == perks[i].perk) chosenPerks.Add(perks[i]);
            }
        }
        return chosenPerks.ToArray();
    }

    public void StartPlacing()
    {
        indicator.SetActive(true);
        gameObject.GetComponent<PlaceTower>().enabled = true;
    }
}
