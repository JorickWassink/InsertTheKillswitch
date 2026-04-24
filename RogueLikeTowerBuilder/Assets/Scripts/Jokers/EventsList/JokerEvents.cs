using System;
using UnityEngine;

public class JokerEvents : MonoBehaviour
{
    //events are going to be used to let the jokers influence the towers and enemies without having references
    //every event is going to be working as a "trigger" that the joker can use
    public static Action<GameObject> OnBulletSpawn;
    public static Action OnEnemyHit;
    public static Action OnWaveEnd;
    public static Action OnEnemyDamage;
}
