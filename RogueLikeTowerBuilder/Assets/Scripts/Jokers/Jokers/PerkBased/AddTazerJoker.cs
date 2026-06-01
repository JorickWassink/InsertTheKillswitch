using UnityEngine;

[System.Serializable]
public class AddTazerJoker : IJoker
{

    public void Initialize(MonoBehaviour owner)
    {
        JokerEvents.OnBulletSpawn += AddBulletPerk;
    }

    void AddBulletPerk(GameObject bullet)
    {


        if (bullet.GetComponent<BulletTazer>() == null) bullet.AddComponent<BulletTazer>();

    }
}
