using UnityEditor.Rendering;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;

    IDestroyable destroyable = null;
    private void Start()
    {
        JokerEvents.OnBulletSpawn?.Invoke(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.TryGetComponent<Bullet>(out Bullet bullet) || collision.TryGetComponent<BaseManager>(out BaseManager manager) || collision.TryGetComponent<Road>(out Road road))
        {
            return;
        }



        if (collision.TryGetComponent<Enemy>(out Enemy enemy))
        {
            if (collision.TryGetComponent<IDamagable>(out IDamagable damagable))
            {
                damagable.TakeDamage(damage,Color.white);


                IBulletEffect[] effects = GetComponents<IBulletEffect>();
                foreach(IBulletEffect effect in effects)
                {
                    if(enemy != null) effect.ApplyEffect(enemy, damage);
                }

            }


            gameObject.TryGetComponent<IDestroyable>(out destroyable);
            if(destroyable != null) destroyable.DestroyBehavior(collision);
            else Destroy(gameObject);
            return;
        }


        gameObject.TryGetComponent<IDestroyable>(out destroyable);
        if (destroyable != null) destroyable.DestroyBehavior(collision);
        else Destroy(gameObject);


    }
}
