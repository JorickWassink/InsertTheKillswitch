using System.Collections;
using UnityEngine;

public class BulletSlow : MonoBehaviour ,IBulletEffect
{
    void IBulletEffect.ApplyEffect(Enemy enemy, float damage)
    {
        enemy.TryGetComponent<ISlowable>(out ISlowable slowable);
        slowable.SlowBehavior();
    }
    




}
