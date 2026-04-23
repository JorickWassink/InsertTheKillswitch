using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public enum rarities
{
    common,
    rare,
    epic
}

public enum shootingNames
{
    doubleShot,
    backShot,
    machineGun,
    standard
}

public enum bulletNames
{
    burn,
    tazer,
    piercing,
    slow
}


public class PerkManager : MonoBehaviour
{
    Dictionary<shootingNames, rarities> shootingRarity = new()
    {
        { shootingNames.doubleShot, rarities.common },
        { shootingNames.machineGun, rarities.common },
        { shootingNames.backShot, rarities.common },
        { shootingNames.standard, rarities.common },

    };

    Dictionary<bulletNames, rarities> bulletRarity = new()
    {
        { bulletNames.burn, rarities.common },
        { bulletNames.tazer, rarities.common },
        { bulletNames.piercing, rarities.common },
        { bulletNames.slow, rarities.common }
    };

    void Start()
    {
        //do all the random stuff and assigning scripts to the object stuff
        int randomNum = Random.Range(0, shootingRarity.Count);
        var shootingKeys = new List<shootingNames>(shootingRarity.Keys);
        shootingNames currentShooting = shootingKeys[randomNum];

        SetShootingPerk(currentShooting);




        randomNum = Random.Range(0, bulletRarity.Count);


        var bulletKeys = new List<bulletNames>(bulletRarity.Keys);
        bulletNames currentBullet = bulletKeys[randomNum];

        gameObject.GetComponent<BulletEnumHolder>().bullet = currentBullet;

        gameObject.GetComponent<PerkManager>().enabled = false;
    }

    void SetShootingPerk(shootingNames current)
    {
        switch (current)
        {
            case shootingNames.doubleShot:
                gameObject.AddComponent<DoubleShooting>();
                break;
            case shootingNames.machineGun:
                gameObject.AddComponent<MachineGunShoot>();
                break;
            case shootingNames.backShot:
                gameObject.AddComponent<BackShooting>();
                break;
            case shootingNames.standard:
                gameObject.AddComponent<StandardShoot>();
                break;
            default:
                print("SOMETHING went wrong and i dont know what PLEASE help me");
                break;
        }
    }
    
}