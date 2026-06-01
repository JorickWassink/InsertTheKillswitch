using UnityEngine;

public class AddSlowJoker : MonoBehaviour, IJoker
{


    private void Start()
    {
        JokerEvents.OnBulletSpawn += AddBulletPerk;
    }

    void AddBulletPerk(GameObject bullet)
    {


        if (bullet.GetComponent<BulletSlow>() == null) bullet.AddComponent<BulletSlow>();

    }
}
