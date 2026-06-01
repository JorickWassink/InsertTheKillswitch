using UnityEngine;


public class CashPerWaveJoker : MonoBehaviour, IJoker
{
    int cashPerWave = 5;
    private void Start()
    {
        JokerEvents.OnWaveEnd += AddCash;
    }

    void AddCash()
    {
        CashEvents.AddCashEvent?.Invoke(cashPerWave);
    }
}
