using UnityEngine;

public class DoubleShooting : BaseShoot
{
    //protected override void Start()
    //{
    //    damage = .5f;
    //    base.Start();
    //}

    public override void Shoot(Vector3 target)
    {
        print("test");
        GameObject current = Instantiate(GetComponent<TowerBase>().bullet, new Vector2(transform.position.x + .1f, transform.position.y + .1f), Quaternion.identity);

        SetBulletInfo(current);

        current.GetComponent<Bullet>().damage = damage;

        Rigidbody2D rb = current.GetComponent<Rigidbody2D>();
        Vector2 direction = (target - transform.position).normalized;

        rb.AddForce(direction * bulletSpeed, ForceMode2D.Impulse);

        //second bullet
        GameObject currentTwo = Instantiate(GetComponent<TowerBase>().bullet, new Vector2(transform.position.x - .1f, transform.position.y - .1f), Quaternion.identity);

        currentTwo.GetComponent<Bullet>().damage = damage;

        Rigidbody2D rbTwo = currentTwo.GetComponent<Rigidbody2D>();
        Vector2 directionTwo = (target - transform.position).normalized;

        rbTwo.AddForce(directionTwo * bulletSpeed, ForceMode2D.Impulse);

    }
}
