using UnityEngine;

[System.Serializable]
public class CashPerWaveJoker : IJoker
{
    int cashPerWave = 5;
    public void Initialize(MonoBehaviour owner)
    {
        JokerEvents.OnWaveEnd += AddCash;
    }
    
    void AddCash()
    {
        CashEvents.AddCashEvent?.Invoke(cashPerWave);
    }
}
