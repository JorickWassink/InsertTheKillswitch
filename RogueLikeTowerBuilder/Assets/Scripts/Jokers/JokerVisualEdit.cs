using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using Unity.VisualScripting;

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
        joker.joker.Initialize(this);
    }
}
