using System.Collections;
using UnityEngine;

public class BulletBurn : MonoBehaviour, IBulletEffect
{
    void IBulletEffect.ApplyEffect(Enemy enemy, float damage)
    { 
        DOTManager manager = FindAnyObjectByType<DOTManager>();
        manager.CheckDOTEffect(enemy, DOT.Burn, damage, 6, .5f);
    }


}
