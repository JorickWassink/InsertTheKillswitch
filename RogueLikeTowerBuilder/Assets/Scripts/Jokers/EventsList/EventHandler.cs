using UnityEngine;

public class EventHandler : MonoBehaviour
{
    public static JokerEvents.OnTowerSpawnReturn towerSpawnReturn;
    EventHandlerDTO handlerDto;
    private void Awake()
    {
        handlerDto = new EventHandlerDTO();

        towerSpawnReturn += EventReturnHandler;
    }

    float EventReturnHandler(GameObject obj)
    {
        handlerDto.number = 0;
        JokerEvents.OnTowerSpawnINC?.Invoke(handlerDto);
        return handlerDto.number;
    }
}
