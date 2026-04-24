using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTarget : BaseTarget
{
    public override Vector3 GetTarget(Collider2D[] targets)
    {
        Vector3 target = Vector3.zero;
        Enemy enemy = null;

        List<Enemy> enemies = new List<Enemy>();
        foreach(Collider2D hit in targets)
        {
            if(hit.GetComponent<Enemy>() != null) enemies.Add(hit.GetComponent<Enemy>());
        }

        if(enemies.Count != 0)
        {
            enemy = enemies[Random.Range(0, enemies.Count)].GetComponent<Enemy>();
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
