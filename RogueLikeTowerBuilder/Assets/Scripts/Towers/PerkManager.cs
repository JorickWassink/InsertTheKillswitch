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
    splitShot,
    backShot,
    randomTarget,
    quadShot,
    wildSpread,
    machineGun,
    circleShot
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
        { shootingNames.randomTarget, rarities.common },
        //{ shootingNames.quadShot, rarities.rare },
        //{ shootingNames.wildSpread, rarities.rare },
        //{ shootingNames.splitShot, rarities.rare },
        //{ shootingNames.circleShot, rarities.epic }
    };

    Dictionary<bulletNames, rarities> bulletRarity = new()
    {
        { bulletNames.burn, rarities.common },
        { bulletNames.tazer, rarities.common },
        { bulletNames.piercing, rarities.common },
        { bulletNames.slow, rarities.common },
        //{ shootingNames.quadShot, rarities.rare },
        //{ shootingNames.wildSpread, rarities.rare },
        //{ shootingNames.splitShot, rarities.rare },
        //{ shootingNames.circleShot, rarities.epic }
    };

    void Start()
    {
        //do all the random stuff and assigning scripts to the object stuff
        int randomNum = Random.Range(0, shootingRarity.Count);
        var shootingKeys = new List<shootingNames>(shootingRarity.Keys);
        shootingNames currentShooting = shootingKeys[randomNum];

        //SetShootingPerk(currentShooting);




        randomNum = Random.Range(0, bulletRarity.Count);
        randomNum = 2; // test line guh


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
            case shootingNames.randomTarget:
                gameObject.AddComponent<RandomTargetShooting>();
                break;
            default:
                print("SOMETHING went wrong and i dont know what PLEASE help me");
                break;
        }
    }
    
}
