using UnityEngine;

public class JokerMenuButtons : MonoBehaviour
{
    [SerializeField] Transform openTransform;
    [SerializeField] Transform closedTransform;

    GameObject target;
    Transform currentTarget = null;
    private void Start()
    {
        target = FindAnyObjectByType<JokerManager>().gameObject;
    }
    public void ToggleMenu()
    {
        currentTarget = (currentTarget == openTransform) ? closedTransform : openTransform;
    }

    private void MoveMenu()
    {
        if (target.transform == currentTarget || currentTarget == null) return;

        target.transform.position = Vector3.MoveTowards(target.transform.position, currentTarget.position, .1f);

    }

    private void FixedUpdate()
    {
        MoveMenu();
    }
}
