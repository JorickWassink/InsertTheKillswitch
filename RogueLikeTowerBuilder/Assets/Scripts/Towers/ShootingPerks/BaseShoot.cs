using UnityEngine;

public abstract class BaseShoot : MonoBehaviour, IShootable
{
    public float damage { get; set; } = 1;
    public float bulletSpeed = 5;
    public virtual void Shoot(Vector3 target)
    {
        GameObject current = Instantiate(GetComponent<TowerBase>().bullet, transform.position, Quaternion.identity);

        SetBulletInfo(current);

        current.GetComponent<Bullet>().damage = damage;

        Rigidbody2D rb = current.GetComponent<Rigidbody2D>();
        Vector2 direction = (target - transform.position).normalized;

        rb.AddForce(direction * bulletSpeed, ForceMode2D.Impulse);
    }

    public virtual void SetBulletInfo(GameObject _bullet)
    {
        switch (gameObject.GetComponent<BulletEnumHolder>().bullet)
        {
            case PerkNames.burnBullet:
                _bullet.AddComponent<BulletBurn>();
                break;
            case PerkNames.tazerBullet:
                _bullet.AddComponent<BulletTazer>();
                break;
            case PerkNames.piercingBullet:
                _bullet.AddComponent<BulletPierce>();
                break;
            case PerkNames.slowBullet:
                _bullet.AddComponent<BulletSlow>();
                break;
        }
    }
}
