using UnityEngine;

public class SimpleTim : MonoBehaviour, IJoker
{
    
    void Start()
    {
        JokerEvents.OnTowerSpawnINC += Effect;
        JokerEvents.OnJokerRefresh?.Invoke();
    }

    void Effect(EventHandlerDTO handlerDto)
    {
        handlerDto.number += 2;
    }
}
