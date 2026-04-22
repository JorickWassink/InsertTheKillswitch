using System.Collections;
using UnityEngine;

public class DOTEffect : MonoBehaviour
{
    public DOT type;
    Enemy target;
    public float damage;
    int ticks;
    float tickSpeed;

    Coroutine current;

    public void Initialize(Enemy _target, DOT _type, float _damage, int _ticks, float _tickSpeed)
    {
        type = _type;
        target = _target;
        damage = _damage;
        ticks = _ticks;
        tickSpeed = _tickSpeed;


        if (current != null) StopCoroutine(current);
        current = StartCoroutine(ApplyDOTEffect());
    }

    private IEnumerator ApplyDOTEffect()
    {
        for (int i = 0; i < ticks; i++)
        {
            target.TryGetComponent<IDamagable>(out IDamagable damage);

            damage.TakeDamage(this.damage / 10, Color.red);

            yield return new WaitForSeconds(tickSpeed);
        }

        Destroy(this);
    }
}
