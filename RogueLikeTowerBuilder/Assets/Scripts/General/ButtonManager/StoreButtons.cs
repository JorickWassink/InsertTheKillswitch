using UnityEngine;
using UnityEngine.UIElements;
using System;
using TMPro;
using Unity.VisualScripting;

public class StoreButtons : MonoBehaviour
{
    [SerializeField] Transform openTransform;
    [SerializeField] Transform closedTransform;

    [SerializeField] TMP_Text rerollPriceText;
    int rerollPrice = 5;

    GameObject target;
    Transform currentTarget = null;

    CashManager cash;
    private void Start()
    {
        cash = FindAnyObjectByType<CashManager>();
        target = FindAnyObjectByType<StoreManager>().gameObject;
    }
    public void ToggleStore()
    {
        currentTarget = (currentTarget == openTransform) ? closedTransform : openTransform;
    }

    public void Rerollstore()
    {
        //do money stuff or something lmao
        if(!cash.CheckCash(rerollPrice)) return;
        CashEvents.RemoveCashEvent(rerollPrice);
        rerollPrice += 5;
        StoreEvents.InitStore();
    }

    private void MoveStoreMenu()
    {
        if (target.transform == currentTarget || currentTarget == null) return;

        target.transform.position = Vector3.MoveTowards(target.transform.position, currentTarget.position, .2f);
        
    }

    private void FixedUpdate()
    {
        rerollPriceText.text = Convert.ToString(rerollPrice);
        MoveStoreMenu();
    }
}
