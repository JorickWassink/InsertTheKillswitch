using UnityEngine;

public class AddBurnJoker : MonoBehaviour, IJoker
{


    private void Start()
    {
        JokerEvents.OnBulletSpawn += AddBulletPerk;
    }

    void AddBulletPerk(GameObject bullet)
    {


        if (bullet.GetComponent<BulletBurn>() == null) bullet.AddComponent<BulletBurn>();

    }
}
