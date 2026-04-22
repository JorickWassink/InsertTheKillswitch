using TMPro;
using UnityEngine;

public class CashManager : MonoBehaviour
{
    int money = 5;
    [SerializeField] TMP_Text cashNumber;

    private void Start()
    {
        cashNumber.text = money.ToString();
    }
    public void AddCash(int _cash)
    {
        money += _cash;
        cashNumber.text = money.ToString();
    }

    public void RemoveCash(int _cash)
    {
        money -= _cash;
        cashNumber.text = money.ToString();
    }

    public bool CheckCash(int _cash)
    {
        if (money >= _cash)
        {
            return true;
        }
        else return false;
    }
}
