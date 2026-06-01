using UnityEngine;

[System.Serializable]
public class AddSlowJoker : IJoker
{

    public void Initialize(MonoBehaviour owner)
    {
        JokerEvents.OnBulletSpawn += AddBulletPerk;
    }

    void AddBulletPerk(GameObject bullet)
    {


        if (bullet.GetComponent<BulletSlow>() == null) bullet.AddComponent<BulletSlow>();

    }
}
