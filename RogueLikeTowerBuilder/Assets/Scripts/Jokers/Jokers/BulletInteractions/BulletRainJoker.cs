using UnityEngine;

public class BulletRainJoker : MonoBehaviour
{
    void Start()
    {
        JokerEvents.OnEnemyHit += SpawnSkyBullet;
    }

    void SpawnSkyBullet(GameObject bullet)
    {
        if(Random.Range(0,6) == 0)
        {            
            GameObject current = Instantiate(bullet, new Vector3(bullet.transform.position.x, bullet.transform.position.y + 5, 0), Quaternion.identity);

            Rigidbody2D rb = current.GetComponent<Rigidbody2D>();
            rb.AddForce(new Vector2(0,-5), ForceMode2D.Impulse);
        }
    }
}
