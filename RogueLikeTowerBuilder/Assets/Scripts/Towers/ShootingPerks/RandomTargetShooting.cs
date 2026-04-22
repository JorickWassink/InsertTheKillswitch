using UnityEngine;

public class RandomTargetShooting : TowerBase
{
    //protected override void Start()
    //{
    //    attackSpeed = .5f;
    //    base.Start();
    //}

    //protected override Vector3 GetTarget()
    //{
    //    Vector3 target = Vector3.zero;
    //    int targetNum = 0;

    //    foreach (var hit in hits)
    //    {
    //        Enemy enemy = hit.GetComponent<Enemy>();
    //        if (enemy == null) continue;


    //        int randomNum = Random.Range(0, 10000);
    //        if(randomNum > targetNum)
    //        {
    //            targetNum = randomNum;
    //            target = enemy.bulletTarget.transform.position;
    //        }

    //        RotateTowards(target);

    //    }
    //    return target;
    //}

    //protected override void Shoot(Vector3 target)
    //{
    //    base.Shoot(target);
    //}
}
