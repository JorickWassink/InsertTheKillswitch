using UnityEngine;

public class BackShooting : BaseShoot
{
    public override void Shoot(Vector3 target)
    {
        GameObject current = Instantiate(GetComponent<TowerBase>().bullet, transform.position, Quaternion.identity);

        SetBulletInfo(current);

        current.GetComponent<Bullet>().damage = damage;

        Rigidbody2D rb = current.GetComponent<Rigidbody2D>();
        Vector2 direction = (target - transform.position).normalized;

        rb.AddForce(direction * bulletSpeed, ForceMode2D.Impulse);


        GameObject currentTwo = Instantiate(GetComponent<TowerBase>().bullet, transform.position, Quaternion.identity);

        SetBulletInfo(currentTwo);

        currentTwo.GetComponent<Bullet>().damage = damage;

        Rigidbody2D rbTwo = currentTwo.GetComponent<Rigidbody2D>();
        Vector2 directionTwo = -(target - transform.position).normalized;

        rbTwo.AddForce(directionTwo * bulletSpeed, ForceMode2D.Impulse);
    }
}
