using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public int currentWave = 1;
    float spaceBetween = 2;
    float currency;

    [Header("EnemyParent")]
    [SerializeField] Transform parent;
    [Header("EnemyPrefabs")]
    [SerializeField] List<GameObject> enemies = new List<GameObject>();
    [Header("Text")]
    [SerializeField] TMP_Text waveNumber;

    private void FixedUpdate()
    {
        Enemy[] enemies = FindObjectsByType<Enemy>(FindObjectsSortMode.None);
        if (enemies.Length == 0)
        {
            if(currentWave != 1) JokerEvents.OnWaveEnd?.Invoke();
            StartWave();
        }
    }
    bool found = false;
    void StartWave()
    {
        currency = currentWave;
        GameObject spawnable = null;

        int spaceIndicator = 1;

        waveNumber.text = Convert.ToString(currentWave);
        do
        {
            do
            {
                int randomNum = UnityEngine.Random.Range(0, enemies.Count);
                if (enemies[randomNum].GetComponent<Enemy>().value <= currency)
                {
                    spawnable = enemies[randomNum];
                    currency -= enemies[randomNum].GetComponent<Enemy>().value;
                    found = true;
                }

            } while (!found);

            found = false;

            GameObject currentEnemy = Instantiate(spawnable, new Vector2(parent.position.x - spaceIndicator * spaceBetween, parent.position.y), Quaternion.identity, parent);
            currentEnemy.GetComponent<Enemy>().hp = currentWave * currentEnemy.GetComponent<Enemy>().hp;
            spaceIndicator++;

        } while (currency != 0);
            
        currentWave++;
    }
}
