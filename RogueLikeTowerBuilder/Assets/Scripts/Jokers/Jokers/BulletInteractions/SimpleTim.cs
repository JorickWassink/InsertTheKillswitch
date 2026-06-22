using UnityEngine;

public class SimpleTim : MonoBehaviour, IJoker
{
    
    void Start()
    {
        JokerEvents.OnJokerRefresh?.Invoke();
        JokerEvents.OnTowerSpawnINC += Effect;
    }
    
    void Effect(EventHandlerDTO handlerDto)
    {
        handlerDto.number += 2;
    }
}
