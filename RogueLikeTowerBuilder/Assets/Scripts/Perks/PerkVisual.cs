using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;
public class PerkVisual : MonoBehaviour
{
    [SerializeField] TMP_Text nameText;
    [SerializeField] TMP_Text descriptionText;

    public Perk perk;
    [SerializeField] GameObject descriptionHolder;
    public void Initialize()
    {
        if (perk == null) return;

        gameObject.GetComponent<Image>().sprite = perk.sprite;
    }

    public void SetDescriptionInfo(bool visible)
    {
        if (descriptionHolder == null) return;

        descriptionHolder.SetActive(visible);

        if (visible)
        {
            descriptionText.text = perk.description;
            nameText.text = perk.perkName;
        }

    }
}
