using System.Collections;
using UnityEngine;

public class BulletSlow : MonoBehaviour ,IBulletEffect, IDestroyable
{
    void IBulletEffect.ApplyEffect(Enemy enemy, float damage)
    {
        enemy.TryGetComponent<ISlowable>(out ISlowable slowable);
        slowable.SlowBehavior();
    }
    


    void IDestroyable.DestroyBehavior(Collider2D col)
    {
        Destroy(gameObject);
    }

}
