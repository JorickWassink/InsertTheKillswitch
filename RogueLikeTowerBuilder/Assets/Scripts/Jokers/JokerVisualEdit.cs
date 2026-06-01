using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

public class JokerVisualEdit : MonoBehaviour
{
    [Header("Regular")]
    [SerializeField] Image image;
    [SerializeField] TMP_Text nameText;

    [Header("Shop")]
    public bool store;
    [SerializeField] TMP_Text priceText;

    [Header("ScriptableObject")]
    [SerializeField] Joker joker;

    Joker placeholderJoker;

    private void Start()
    {
        placeholderJoker = joker;
        Setinfo();
    }

    void FixedUpdate()
    {
        if (joker != placeholderJoker) Setinfo();
    }

    void Setinfo()
    {
        image.sprite = joker.sprite;
        nameText.text = $"{joker.jokerName}.dll";

        if (store) priceText.text = Convert.ToString(joker.price);
    }

    public void BuyJoker()
    {
        GameObject target = FindAnyObjectByType<JokerHolderObject>().gameObject;
        switch (joker.joker)
        {
            case JokerEnum.CashPerWave:
                
                if(target.GetComponent<CashPerWaveJoker>() == null) target.AddComponent<CashPerWaveJoker>();
                break;
            case JokerEnum.BulletRain:
                if (target.GetComponent<BulletRainJoker>() == null) target.AddComponent<BulletRainJoker>();
                break;
            case JokerEnum.AddBurn:
                if (target.GetComponent<AddBurnJoker>() == null) target.AddComponent<AddBurnJoker>();
                break;
            case JokerEnum.AddTazer:
                if (target.GetComponent<AddTazerJoker>() == null) target.AddComponent<AddTazerJoker>();
                break;
            case JokerEnum.AddSlow:
                if (target.GetComponent<AddSlowJoker>() == null) target.AddComponent<AddSlowJoker>();
                break;
            case JokerEnum.RandomEnemyStun:
                if (target.GetComponent<RandomEnemyStun>() == null) target.AddComponent<RandomEnemyStun>();
                break;
        }
    }
}
