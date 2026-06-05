using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using UnityEngine;
using static UnityEngine.LowLevelPhysics2D.PhysicsShape;

public class StoreManager : MonoBehaviour
{
    [SerializeField] List<Joker> jokers = new List<Joker>();
    private void Start()
    {
        Initialize();
        StoreEvents.InitStore += Initialize;
    }

    private void Initialize()
    {
        JokerVisualEdit[] storeSlots = transform.GetComponentsInChildren<JokerVisualEdit>();

        List<Joker> shuffled = jokers.OrderBy(_ => Random.value).ToList();

        for (int i = 0; i < storeSlots.Length; i++)
        {
            storeSlots[i].joker = shuffled[i];
        }
    }
}
