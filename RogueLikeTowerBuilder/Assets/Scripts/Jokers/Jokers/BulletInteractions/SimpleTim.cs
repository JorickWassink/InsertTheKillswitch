using UnityEngine;

public class SimpleTim : MonoBehaviour, IJoker
{
    
    void Start()
    {
        JokerEvents.OnBulletSpawnINC += Effect;
    }
    
    void Effect(EventHandlerDTO handlerDto)
    {
        handlerDto.number += 2;
    }
}
