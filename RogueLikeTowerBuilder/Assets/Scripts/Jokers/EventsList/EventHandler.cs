using UnityEngine;

public class EventHandler : MonoBehaviour
{
    public static JokerEvents.OnEnemyHitReturn enemyHitReturn = null;
    public static float number;
    private void Awake()
    {
        JokerEvents.OnEnemyHitReturn enemyHitReturn = null;
        enemyHitReturn += EventReturnHandler;
    }

    float EventReturnHandler()
    {
        return 0;
    }
}
