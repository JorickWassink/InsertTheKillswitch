using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public abstract class BaseTarget : MonoBehaviour, IGetTarget
{
    public Collider2D[] hits;
    public virtual Vector3 GetTarget(Collider2D[] targets)
    {
        float targetDistance = Mathf.Infinity;
        Vector3 target = Vector3.zero;

        foreach (var hit in targets)
        {
            Enemy enemy = hit.GetComponent<Enemy>();
            if (enemy == null) continue;

            float distance = Vector3.Distance(transform.position, enemy.bulletTarget.transform.position);

            if (distance < targetDistance)
            {
                targetDistance = distance;
                target = enemy.bulletTarget.transform.position;
            }

            GetComponent<TowerBase>().RotateTowards(enemy.bulletTarget.transform.position);
        }

        return target;
    }

    public virtual IEnumerator CheckTargets(float range)
    {
        while (true)
        {
            hits = Physics2D.OverlapCircleAll(transform.position, range);

            Vector3 target = ((IGetTarget)this).GetTarget(hits);
            if (target != Vector3.zero)
            {
                GetComponent<IShootable>().Shoot(target);
            }

            yield return new WaitForSeconds(GetComponent<TowerBase>().attackSpeed);
        }
    }
}
