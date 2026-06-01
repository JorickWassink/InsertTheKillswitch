using UnityEngine;
using System.Collections;

[System.Serializable]
public class RandomEnemyStun : IJoker
{
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Initialize(MonoBehaviour owner)
    {
        owner.StartCoroutine(StunRandomEnemy());
    }

    IEnumerator StunRandomEnemy()
    {
        while (true)
        {
            Enemy[] enemies = Object.FindObjectsByType<Enemy>(FindObjectsSortMode.None);
            if (enemies.Length > 0)
            {
                int randomIndex = Random.Range(0, enemies.Length);
                enemies[randomIndex].Stun(1);
            }
            yield return new WaitForSeconds(2);
        }
    }
}
