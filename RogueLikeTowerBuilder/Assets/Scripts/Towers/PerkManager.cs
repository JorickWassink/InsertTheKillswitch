using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public enum rarities
{
    common,
    rare,
    epic
}

//public enum shootingNames
//{
//    doubleShot,
//    backShot,
//    machineGun,
//    standard
//}

//public enum bulletNames
//{
//    burn,
//    tazer,
//    piercing,
//    slow
//}

//public enum targetNames
//{
//    random,
//    closest,
//    first,
//    strongest
//}

public enum PerkNames
{
    doubleShooting,
    backShooting,
    machineGunShooting,
    standardShooting,
    randomTarget,
    closestTarget,
    firstTarget,
    strongestTarget,
    burnBullet,
    tazerBullet,
    piercingBullet,
    slowBullet
}


public class PerkManager : MonoBehaviour
{
    Dictionary<PerkNames, rarities> shootingRarity = new()
    {
        { PerkNames.doubleShooting, rarities.common },
        { PerkNames.machineGunShooting, rarities.common },
        { PerkNames.backShooting, rarities.common },
        { PerkNames.standardShooting, rarities.common },

    };

    Dictionary<PerkNames, rarities> bulletRarity = new()
    {
        { PerkNames.burnBullet, rarities.common },
        { PerkNames.tazerBullet, rarities.common },
        { PerkNames.piercingBullet, rarities.common },
        { PerkNames.slowBullet, rarities.common }
    };

    Dictionary<PerkNames, rarities> targetRarity = new()
    {
        { PerkNames.randomTarget, rarities.common },
        { PerkNames.closestTarget, rarities.common },
        { PerkNames.firstTarget, rarities.common },
        { PerkNames.strongestTarget, rarities.common }
    };

    void Start()
    {
        //start of setting shooting perk
        int randomNum = Random.Range(0, shootingRarity.Count);

        List<PerkNames> shootingKeys = new List<PerkNames>(shootingRarity.Keys);
        PerkNames currentShooting = shootingKeys[randomNum];
        SetShootingPerk(currentShooting);

        //start of setting bullet perk
        randomNum = Random.Range(0, bulletRarity.Count);

        List<PerkNames> bulletKeys = new List<PerkNames>(bulletRarity.Keys);
        PerkNames currentBullet = bulletKeys[randomNum];

        gameObject.GetComponent<BulletEnumHolder>().bullet = currentBullet;

        //start of setting targeting perk
        randomNum = Random.Range(0,targetRarity.Count);

        List<PerkNames> targetKeys = new List<PerkNames>(targetRarity.Keys);
        PerkNames currentTarget = targetKeys[randomNum];
        SetTargetPerk(currentTarget);

        gameObject.GetComponent<PerkManager>().enabled = false;
    }

    void SetShootingPerk(PerkNames current)
    {
        switch (current)
        {
            case PerkNames.doubleShooting:
                gameObject.AddComponent<DoubleShooting>();
                break;
            case PerkNames.machineGunShooting:
                gameObject.AddComponent<MachineGunShoot>();
                break;
            case PerkNames.backShooting:
                gameObject.AddComponent<BackShooting>();
                break;
            case PerkNames.standardShooting:
                gameObject.AddComponent<StandardShoot>();
                break;
            default:
                print("SOMETHING went wrong and i dont know what PLEASE help me");
                break;
        }
    }

    void SetTargetPerk(PerkNames targetNames)
    {
        switch (targetNames)
        {
            case PerkNames.randomTarget:
                gameObject.AddComponent<RandomTarget>();
                break;
            case PerkNames.firstTarget:
                gameObject.AddComponent<FirstTarget>();
                break;
            case PerkNames.closestTarget:
                gameObject.AddComponent<ClosestTarget>();
                break;
            case PerkNames.strongestTarget:
                gameObject.AddComponent<StrongestTarget>();
                break;
            default:
                print("SOMETHING went wrong and i dont know what PLEASE help me");
                break;
        }
    }
    
}