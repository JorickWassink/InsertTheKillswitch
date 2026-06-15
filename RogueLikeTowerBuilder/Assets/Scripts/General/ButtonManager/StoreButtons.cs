using System;
using TMPro;
using UnityEngine;

public class StoreButtons : MonoBehaviour
{
    [SerializeField] TMP_Text rerollPriceText;
    int rerollPrice = 5;

    [SerializeField] GameObject target;

    CashManager cash;
    private void Start()
    {

        cash = FindAnyObjectByType<CashManager>();
    }
    public void ToggleStore()
    {
        if (target.activeSelf) target.GetComponent<UIPopIn>().PlayOut();
        else target.SetActive(true);
    }

    public void Rerollstore()
    {
        //do money stuff or something lmao
        if (!cash.CheckCash(rerollPrice)) return;
        CashEvents.RemoveCashEvent(rerollPrice);
        rerollPrice += 5;
        StoreEvents.InitStore();
    }


    private void FixedUpdate()
    {
        rerollPriceText.text = Convert.ToString(rerollPrice);
    }
}
