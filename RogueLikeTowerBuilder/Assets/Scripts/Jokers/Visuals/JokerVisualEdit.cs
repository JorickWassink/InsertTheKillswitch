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
    [SerializeField] TMP_Text descriptionText;

    [Header("Shop")]
    public bool store;
    [SerializeField] TMP_Text priceText;

    [Header("ScriptableObject")]
    [SerializeField] public Joker joker;

    Joker placeholderJoker;
    [SerializeField] GameObject descriptionHolder;

    private void Start()
    {
        descriptionHolder.SetActive(false);
        placeholderJoker = joker;
        if(joker != null) Setinfo();
    }

    void FixedUpdate()
    {
        if (joker != placeholderJoker && joker != null) Setinfo();
    }

    void Setinfo()
    {
        image.sprite = joker.sprite;
        nameText.text = $"{joker.jokerName}.dll";

        if (store) priceText.text = Convert.ToString(joker.price);
    }

    public void BuyJoker()
    {
        JokerManager.OnAddJoker(joker.joker);
    }

    public void SetDescription(bool visible)
    {
        if (descriptionHolder == null) return;

        descriptionHolder.SetActive(visible);

        if (visible)
            descriptionText.text = joker.description;
    }
}
