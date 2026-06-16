using UnityEngine;

public class JokerMenuButtons : MonoBehaviour
{
    [SerializeField] GameObject target;

    public void ToggleMenu()
    {
        if (target.GetComponent<UIPopInOffscreen>().IsOnScreen) target.GetComponent<UIPopInOffscreen>().PlayOut();
        else target.GetComponent<UIPopInOffscreen>().PlayIn();
    }
}
