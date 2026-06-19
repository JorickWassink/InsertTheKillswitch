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
    [SerializeField] Joker purchasedJoker;
    [SerializeField] GameObject descriptionHolder;
    CashManager cash;

    private void Start()
    {
        cash = FindAnyObjectByType<CashManager>();
        if(descriptionHolder != null) descriptionHolder.SetActive(false);
        placeholderJoker = joker;
        if(joker != null) Setinfo();
    }

    void FixedUpdate()
    {
        if (joker != placeholderJoker && joker != null) Setinfo();
    }

    void Setinfo()
    {
        Material instanceMaterial = new Material(image.material);
        image.material = instanceMaterial;
        instanceMaterial.SetTexture("_Texture", joker.sprite.texture);

        image.sprite = joker.sprite;
        nameText.text = $"{joker.jokerName}.dll";

        if (store) priceText.text = Convert.ToString(joker.price);
        placeholderJoker = joker;
    }

    public void BuyJoker()
    {
        if (joker == purchasedJoker) return;
        if (!cash.CheckCash(5)) return;
        CashEvents.RemoveCashEvent(5);
        JokerManager.OnAddJoker(joker.joker);
        joker = purchasedJoker;
    }

    public void SetDescription(bool visible)
    {
        if (descriptionHolder == null) return;

        descriptionHolder.SetActive(visible);

        if (visible)
            descriptionText.text = joker.description;
    }
}
