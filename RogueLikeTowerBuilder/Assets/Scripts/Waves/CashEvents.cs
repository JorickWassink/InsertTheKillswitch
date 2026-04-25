using System;
using UnityEngine;

public class CashEvents : MonoBehaviour
{
    public static CashEvents instance { get; private set; }

    public Action<int> AddCashEvent;
    public Action<int> RemoveCashEvent;
}
