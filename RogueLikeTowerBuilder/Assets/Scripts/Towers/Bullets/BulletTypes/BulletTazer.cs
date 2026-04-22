using System.Collections;
using UnityEngine;

public class BulletTazer : MonoBehaviour, IBulletEffect, IDestroyable
{
    void IBulletEffect.ApplyEffect(Enemy enemy, float damage)
    {
        enemy.Stun(1);
    }

    void IDestroyable.DestroyBehavior(Collider2D col)
    {
        Destroy(gameObject);
    }
}
