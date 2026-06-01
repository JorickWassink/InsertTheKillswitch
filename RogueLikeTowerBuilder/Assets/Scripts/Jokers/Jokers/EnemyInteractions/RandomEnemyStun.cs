using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class RandomEnemyStun : MonoBehaviour, IJoker
{
    private void Start()
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
