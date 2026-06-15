using UnityEngine;

public class JokerMenuButtons : MonoBehaviour
{
    [SerializeField] GameObject target;

    public void ToggleMenu()
    {
        if (target.activeSelf) target.GetComponent<UIPopIn>().PlayOut();
        else target.SetActive(true);
    }
}
