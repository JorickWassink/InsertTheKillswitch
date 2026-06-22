using UnityEngine;

public class EventHandler : MonoBehaviour
{
    public static JokerEvents.OnBulletSpawnReturn bulletSpawnReturn;
    EventHandlerDTO handlerDto;
    private void Awake()
    {
        handlerDto = new EventHandlerDTO();

        bulletSpawnReturn += EventReturnHandler;
    }

    float EventReturnHandler(GameObject obj)
    {
        JokerEvents.OnBulletSpawnINC?.Invoke(handlerDto);
        return handlerDto.number;
    }
}
