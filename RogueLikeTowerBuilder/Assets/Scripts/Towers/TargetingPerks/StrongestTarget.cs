using UnityEngine;

public class StrongestTarget : BaseTarget
{
    public override Vector3 GetTarget(Collider2D[] targets)
    {
        float highestHP = 0;
        Vector3 target = Vector3.zero;

        foreach (var hit in hits)
        {
            Enemy enemy = hit.GetComponent<Enemy>();
            if (enemy == null) continue;

            if(enemy.hp > highestHP)
            {
                highestHP = enemy.hp;
                target = enemy.bulletTarget.transform.position;
            }

            GetComponent<TowerBase>().RotateTowards(enemy.bulletTarget.transform.position);
        }

        return target;
    }
}
