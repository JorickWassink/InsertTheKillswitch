using System;
using System.Collections.Generic;
using UnityEngine;

public class JokerManager : MonoBehaviour
{
    public static Action<JokerEnum> OnAddJoker;

    [SerializeField] Transform jokerContainer;

    [SerializeField] GameObject jokerPrefab;
    [SerializeField] List<Joker> scrObjects = new List<Joker>();

    int jokerCount;
    void Start()
    {
        OnAddJoker += OrderJokers;
    }

    List<JokerVisualEdit> jokerVisuals = new List<JokerVisualEdit>();
    int currentJokerIndex = 0;

    void OrderJokers(JokerEnum _joker)
    {
        Joker current = CheckObject(_joker);
        if (current == null) return;

        JokerVisualEdit newVisual = Instantiate(jokerPrefab, jokerContainer).GetComponent<JokerVisualEdit>();
        newVisual.joker = current;
        jokerVisuals.Add(newVisual);

        BuyJoker(_joker);

        jokerCount++;

        currentJokerIndex = jokerVisuals.Count - 1;
        UpdateJokerVisibility();
    }

    void UpdateJokerVisibility()
    {
        for (int i = 0; i < jokerVisuals.Count; i++)
        {
            jokerVisuals[i].gameObject.SetActive(i == currentJokerIndex);
        }
    }

    public void NextJoker()
    {
        if (jokerVisuals.Count == 0) return;
        currentJokerIndex = (currentJokerIndex + 1) % jokerVisuals.Count;
        UpdateJokerVisibility();
    }

    public void PreviousJoker()
    {
        if (jokerVisuals.Count == 0) return;
        currentJokerIndex = (currentJokerIndex - 1 + jokerVisuals.Count) % jokerVisuals.Count;
        UpdateJokerVisibility();
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
                target.AddComponent<CashPerWaveJoker>();
                break;
            case JokerEnum.BulletRain:
                target.AddComponent<BulletRainJoker>();
                break;
            case JokerEnum.AddBurn:
                target.AddComponent<AddBurnJoker>();
                break;
            case JokerEnum.AddTazer:
                target.AddComponent<AddTazerJoker>();
                break;
            case JokerEnum.AddSlow:
                target.AddComponent<AddSlowJoker>();
                break;
            case JokerEnum.RandomEnemyStun:
                target.AddComponent<RandomEnemyStun>();
                break;
            case JokerEnum.SimpleTim:
                target.AddComponent<SimpleTim>();
                break;
        }
    }
}
