using UnityEngine;

public class AddTazerJoker : MonoBehaviour, IJoker
{

    private void Start()
    {
        JokerEvents.OnBulletSpawn += AddBulletPerk;
    }

    void AddBulletPerk(GameObject bullet)
    {


        if (bullet.GetComponent<BulletTazer>() == null) bullet.AddComponent<BulletTazer>();

    }
}
