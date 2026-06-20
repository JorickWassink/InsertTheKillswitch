using UnityEngine;
using UnityEngine.EventSystems;

public class JokerInfoHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerEnter(PointerEventData data)
    {
        GetComponent<JokerVisualEdit>().SetDescription(true);
    }

    public void OnPointerExit(PointerEventData data)
    {
        GetComponent<JokerVisualEdit>().SetDescription(false);
    }

    public void OnPointerDown(PointerEventData data)
    {
        GetComponent<JokerVisualEdit>().SetDescription(true);
    }

    public void OnPointerUp(PointerEventData data)
    {
        GetComponent<JokerVisualEdit>().SetDescription(false);
    }
}
