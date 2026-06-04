using UnityEngine;
using UnityEngine.UIElements;

public class StoreButtons : MonoBehaviour
{
    [SerializeField] Transform openTransform;
    [SerializeField] Transform closedTransform;

    GameObject target;
    Transform currentTarget = null;
    private void Start()
    {
        target = FindAnyObjectByType<StoreManager>().gameObject;
    }
    public void ToggleStore()
    {
        currentTarget = (currentTarget == openTransform) ? closedTransform : openTransform;
    }

    private void MoveStoreMenu()
    {
        if (target.transform == currentTarget || currentTarget == null) return;

        target.transform.position = Vector3.MoveTowards(target.transform.position, currentTarget.position, .2f);
        
    }

    private void FixedUpdate()
    {
        MoveStoreMenu();
    }
}
