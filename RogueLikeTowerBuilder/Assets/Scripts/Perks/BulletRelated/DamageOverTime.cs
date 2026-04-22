using UnityEngine;
using System.Collections;
using UnityEditor.ShaderGraph.Internal;

public class DamageOverTime : MonoBehaviour
{
    bool activeDOT = false;
    public void DealDamageOverTime(Enemy targetEnemy, float damage, int ticks, float tickSpeed)
    {
        targetEnemy.TryGetComponent<IDamagable>(out IDamagable damageable);

        StartCoroutine(BurnTick(targetEnemy, damage, tickSpeed));  
    }

    private IEnumerator BurnTick(Enemy _enemy, float _damage, float _tickSpeed)
    {
        activeDOT = true;
        for (int i = 0; i < 6; i++)
        {
            _enemy.TryGetComponent<IDamagable>(out IDamagable damage);

            damage.TakeDamage(_damage / 10, Color.red);

            yield return new WaitForSeconds(_tickSpeed);

        }
    }
}
