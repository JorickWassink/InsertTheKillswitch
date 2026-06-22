using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class RandomTitle : MonoBehaviour
{
    [SerializeField] List<Sprite> titles = new List<Sprite>();
    void Start()
    {
        GetComponent<Image>().sprite = titles[Random.Range(0,titles.Count)];
    }

}
