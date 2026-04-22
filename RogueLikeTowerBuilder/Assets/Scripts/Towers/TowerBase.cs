using UnityEngine;

public class TowerBase : MonoBehaviour
{
    [Header("Stats")]
    public float range = 5;
    public float attackSpeed = 1;


    [Header("References")]
    public GameObject bullet;

    public Collider2D[] hits;

    protected virtual void Start()
    {
        bullet = BulletHolder.bulletInstance;

        IGetTarget getTarget = GetComponent<IGetTarget>();
        IShootable shootable = GetComponent<IShootable>();

        StartCoroutine(getTarget.CheckTargets(range));
    }


    public void RotateTowards(Vector3 targetPos)
    {
        Vector2 direction = (targetPos - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }



    protected virtual void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}