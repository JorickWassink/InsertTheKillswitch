using UnityEngine;

[System.Serializable]
public class AddBurnJoker : IJoker
{

    public void Initialize(MonoBehaviour owner)
    {
        JokerEvents.OnBulletSpawn += AddBulletPerk;
    }

    void AddBulletPerk(GameObject bullet)
    {


        if (bullet.GetComponent<BulletBurn>() == null) bullet.AddComponent<BulletBurn>();

    }
}
