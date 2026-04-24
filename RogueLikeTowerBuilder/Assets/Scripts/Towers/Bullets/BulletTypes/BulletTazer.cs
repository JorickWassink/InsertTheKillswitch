using System.Collections;
using UnityEngine;

public class BulletTazer : MonoBehaviour, IBulletEffect
{
    void IBulletEffect.ApplyEffect(Enemy enemy, float damage)
    {
        enemy.Stun(1);
    }
}
