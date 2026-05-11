using UnityEngine;
using System.Collections.Generic;

public class TowerSpriteGiver : MonoBehaviour
{
    [SerializeField]
    public List<Sprite> towerSprites;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = towerSprites[Random.Range(0, towerSprites.Count)];
    }
}
