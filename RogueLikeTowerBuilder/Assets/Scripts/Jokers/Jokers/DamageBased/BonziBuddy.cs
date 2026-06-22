using UnityEngine;

public class BonziBuddy : MonoBehaviour
{
    float damageModifier = 1;
    void Start()
    {
        JokerEvents.OnTowerSpawnINC += IncDamage;
        JokerEvents.OnWaveEnd += OnWaveEnd;
        JokerEvents.OnJokerRefresh?.Invoke();
    }

    void IncDamage(EventHandlerDTO dto)
    {
        dto.number += damageModifier;
    }

    void OnWaveEnd()
    {
        damageModifier += .1f;
        JokerEvents.OnJokerRefresh?.Invoke();
    }
}
