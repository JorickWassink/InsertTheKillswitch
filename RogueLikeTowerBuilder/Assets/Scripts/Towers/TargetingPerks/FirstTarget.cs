using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstTarget : BaseTarget
{
    Enemy enemy = null;
    public override Vector3 GetTarget(Collider2D[] targets)
    {
        Vector3 target = Vector3.zero;


        List<Enemy> enemies = new List<Enemy>();
        foreach(Collider2D hit in targets)
        {
            if(hit.GetComponent<Enemy>() != null) enemies.Add(hit.GetComponent<Enemy>());
        }

        if (enemies.Count != 0)
        {
            enemy = enemies[0];
            target = enemy.bulletTarget.transform.position;
        }

        if(enemy != null) GetComponent<TowerBase>().RotateTowards(enemy.bulletTarget.transform.position);

        return target;
    }

    public override IEnumerator CheckTargets(float range)
    {
        return base.CheckTargets(range);
    }
}
