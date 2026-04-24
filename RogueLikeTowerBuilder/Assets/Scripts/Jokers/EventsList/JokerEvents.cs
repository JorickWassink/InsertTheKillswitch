using System;
using UnityEngine;

public class JokerEvents : MonoBehaviour
{
    public static JokerEvents instance { get; private set; }
    //events are going to be used to let the jokers influence the towers and enemies without having references
    //every event is going to be working as a "trigger" that the joker can use
    public  Action<GameObject> OnBulletSpawn;
    public  Action OnEnemyHit;
    public  Action OnWaveEnd;
    public  Action OnEnemyDamage;
}
