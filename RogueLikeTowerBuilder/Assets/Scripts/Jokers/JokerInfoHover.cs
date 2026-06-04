using UnityEngine;
using UnityEngine.EventSystems;

public class JokerInfoHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData data)
    {
        GetComponent<JokerVisualEdit>().SetDescription(true);
    }

    public void OnPointerExit(PointerEventData data)
    {
        GetComponent<JokerVisualEdit>().SetDescription(false);
    }

}
