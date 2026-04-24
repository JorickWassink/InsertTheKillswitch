using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongestTarget : BaseTarget
{
    Enemy enemy = null;
    public override Vector3 GetTarget(Collider2D[] targets)
    {
        Vector3 target = Vector3.zero;


        List<Enemy> enemies = new List<Enemy>();
        foreach (Collider2D hit in targets)
        {
            if (hit.GetComponent<Enemy>() != null) enemies.Add(hit.GetComponent<Enemy>());
        }

        if (enemies.Count != 0)
        {
            float highestHealth = 0;
            foreach(Enemy enemy in enemies)
            {
                if(enemy.hp > highestHealth)
                {
                    highestHealth = enemy.hp;
                    target = enemy.bulletTarget.transform.position;
                }
            }
            enemy = enemies[0];
            target = enemy.bulletTarget.transform.position;
        }

        if (enemy != null) GetComponent<TowerBase>().RotateTowards(enemy.bulletTarget.transform.position);

        return target;
    }

    public override IEnumerator CheckTargets(float range)
    {
        return base.CheckTargets(range);
    }
}
