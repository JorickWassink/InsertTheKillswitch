using System.Collections;
using UnityEngine;

public class BulletBurn : MonoBehaviour, IBulletEffect, IDestroyable
{
    void IBulletEffect.ApplyEffect(Enemy enemy, float damage)
    { 
        DOTManager manager = FindAnyObjectByType<DOTManager>();
        manager.CheckDOTEffect(enemy, DOT.Burn, damage, 6, .5f);
    }

    void IDestroyable.DestroyBehavior(Collider2D col)
    {
        Destroy(gameObject);
    }
}
