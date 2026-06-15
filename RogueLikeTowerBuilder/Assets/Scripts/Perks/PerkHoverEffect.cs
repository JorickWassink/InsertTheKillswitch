using UnityEngine;
using UnityEngine.EventSystems;

public class PerkHoverEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData data)
    {
        GetComponent<PerkVisual>().SetDescriptionInfo(true);
    }

    public void OnPointerExit(PointerEventData data)
    {
        GetComponent<PerkVisual>().SetDescriptionInfo(false);
    }
}
