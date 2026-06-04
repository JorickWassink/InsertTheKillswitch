using UnityEngine;
using UnityEngine.EventSystems;

public class JokerInfoHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData data)
    {
        data.pointerEnter.GetComponent<JokerVisualEdit>().ToggleDescription();
    }

    public void OnPointerExit(PointerEventData data)
    {
        data.pointerEnter.GetComponent<JokerVisualEdit>().ToggleDescription();
    }

}
