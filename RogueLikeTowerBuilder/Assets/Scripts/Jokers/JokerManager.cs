using System;
using System.Collections.Generic;
using UnityEngine;

public class JokerManager : MonoBehaviour
{
    public static Action<JokerEnum> OnAddJoker;

    [SerializeField] Transform columnOne;
    [SerializeField] Transform columnTwo;
    [SerializeField] GameObject jokerPrefab;
    [SerializeField] List<Joker> scrObjects = new List<Joker>();

    int jokerCount;
    void Start()
    {
        OnAddJoker += OrderJokers;
    }

    void OrderJokers(JokerEnum _joker)
    {
        Joker current = CheckObject(_joker);
        if (current == null) return;
        if (jokerCount % 2 == 1 || jokerCount == 0)
        {
            Instantiate(jokerPrefab, columnOne).GetComponent<JokerVisualEdit>().joker = current;
        }
        else
        {
            Instantiate(jokerPrefab, columnTwo).GetComponent<JokerVisualEdit>().joker = current;
        }
        BuyJoker(_joker);

        jokerCount++;
    }

    Joker CheckObject(JokerEnum _joker)
    {
        foreach (Joker joker in scrObjects)
        {
            if (joker.joker == _joker) return joker;
        }
        return null;
    }

    void BuyJoker(JokerEnum _joker)
    {
        GameObject target = FindAnyObjectByType<JokerHolderObject>().gameObject;
        switch (_joker)
        {
            case JokerEnum.CashPerWave:
                if (target.GetComponent<CashPerWaveJoker>() == null) target.AddComponent<CashPerWaveJoker>();
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
