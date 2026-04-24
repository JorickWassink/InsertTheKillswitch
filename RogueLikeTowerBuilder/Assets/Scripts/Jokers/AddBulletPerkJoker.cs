using UnityEngine;
public enum RiggablePerks
{
    Burn,
    Slow,
    Tazer
}

public class AddBulletPerkJoker : MonoBehaviour
{
    public RiggablePerks perk;
    void Start()
    {
        JokerEvents.OnBulletSpawn += AddBulletPerk;
    }

    void AddBulletPerk(GameObject bullet)
    {
        print("running add method");
        switch (perk)
        {
            case RiggablePerks.Burn:
                print("trying to add burn");
                if(bullet.GetComponent<BulletBurn>() == null) bullet.AddComponent<BulletBurn>();
                break;
            case RiggablePerks.Slow:
                if (bullet.GetComponent<BulletSlow>() == null) bullet.AddComponent<BulletSlow>();
                break;
            case RiggablePerks.Tazer:
                if (bullet.GetComponent<BulletTazer>() == null) bullet.AddComponent<BulletTazer>();
                break;
        }
    }
}
