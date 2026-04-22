using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;

    IDestroyable destroyable = null;

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


                IBulletEffect effect = GetComponent<IBulletEffect>();
                effect.ApplyEffect(enemy,damage);
                
            }


            gameObject.TryGetComponent<IDestroyable>(out destroyable);
            destroyable.DestroyBehavior(collision);
            return;
        }


        gameObject.TryGetComponent<IDestroyable>(out destroyable);
        destroyable.DestroyBehavior(collision);


    }
}
