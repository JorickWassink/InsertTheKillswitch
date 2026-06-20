using UnityEngine;
using UnityEngine.EventSystems;

public class PerkHoverEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerEnter(PointerEventData data)
    {
        GetComponent<PerkVisual>().SetDescriptionInfo(true);
    }

    public void OnPointerExit(PointerEventData data)
    {
        GetComponent<PerkVisual>().SetDescriptionInfo(false);
    }

    public void OnPointerDown(PointerEventData data)
    {
        GetComponent<PerkVisual>().SetDescriptionInfo(true);
    }

    public void OnPointerUp(PointerEventData data)
    {
        GetComponent<PerkVisual>().SetDescriptionInfo(false);
    }
}
