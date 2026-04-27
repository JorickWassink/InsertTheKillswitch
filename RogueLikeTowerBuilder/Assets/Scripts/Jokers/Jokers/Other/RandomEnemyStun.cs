using UnityEngine;
using System.Collections;

public class RandomEnemyStun : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(StunRandomEnemy());
    }

    IEnumerator StunRandomEnemy()
    {
        while (true)
        {
            Enemy[] enemies = FindObjectsByType<Enemy>(FindObjectsSortMode.None);
            if (enemies.Length > 0)
            {
                int randomIndex = Random.Range(0, enemies.Length);
                enemies[randomIndex].Stun(1);
            }
            yield return new WaitForSeconds(2);
        }
    }
}
