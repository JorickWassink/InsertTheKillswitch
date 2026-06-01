using UnityEngine;

[System.Serializable]
public class BulletRainJoker : IJoker
{
    public void Initialize(MonoBehaviour owner)
    {
        JokerEvents.OnEnemyHit += SpawnSkyBullet;
    }

    void SpawnSkyBullet(GameObject bullet)
    {
        if(Random.Range(0,6) == 0)
        {            
            GameObject current = Object.Instantiate(bullet, new Vector3(bullet.transform.position.x, bullet.transform.position.y + 5, 0), Quaternion.identity);

            Rigidbody2D rb = current.GetComponent<Rigidbody2D>();
            rb.AddForce(new Vector2(0,-5), ForceMode2D.Impulse);
        }
    }
}
