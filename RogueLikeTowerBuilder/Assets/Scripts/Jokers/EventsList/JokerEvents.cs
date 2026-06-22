using System;
using UnityEngine;

public static class JokerEvents
{
    //events are going to be used to let the jokers influence the towers and enemies without having references
    //every event is going to be working as a "trigger" that the joker can use
    public delegate float OnTowerSpawnReturn(GameObject gameobject);
    public static Action<GameObject> OnBulletSpawn;
    public static Action<GameObject> OnEnemyHit;
    public static Action OnWaveEnd;
    public static Action OnEnemyDamage;

    //Events that will be ran by the eventhandler to use when joker needs to increase damage
    public static Action<EventHandlerDTO> OnTowerSpawnINC;

    //Events not used by jokers but used by other systems to interact with jokers
    public static Action OnJokerRefresh;
}
