using UnityEngine;
using System.Collections.Generic;

public class BuildMode : MonoBehaviour
{
    [SerializeField] GameObject indicator;
    [SerializeField] GameObject PerkWindow;

    public List<Perk> perks = new List<Perk>();
    
    public void EnableBuildMode()
    {
        PerkWindow.SetActive(true);        
        PerkWindow.GetComponent<PerkWindowVisual>().Initialize(GetCurrentPerks(FindAnyObjectByType<PerkManager>().RunPerks()));
    }

    Perk[] GetCurrentPerks(PerkNames[] _perkNames)
    {
        List<Perk> chosenPerks = new List<Perk>();
        foreach(PerkNames perk in _perkNames)
        {
            for(int i = 0; i < perks.Count; i++)
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
