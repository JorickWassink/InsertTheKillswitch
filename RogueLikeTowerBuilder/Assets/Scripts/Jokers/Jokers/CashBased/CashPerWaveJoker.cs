using UnityEngine;

public class CashPerWaveJoker : MonoBehaviour
{
    int cashPerWave = 5;
    void Start()
    {
        JokerEvents.OnWaveEnd += AddCash;
    }
    
    void AddCash()
    {
        CashEvents.AddCashEvent?.Invoke(cashPerWave);
    }
}
