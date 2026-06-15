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


    public PerkNames[] RunPerks()
    {
        //start of setting shooting perk
        int randomNum = Random.Range(0, shootingRarity.Count);

        List<PerkNames> shootingKeys = new List<PerkNames>(shootingRarity.Keys);
        PerkNames currentShooting = shootingKeys[randomNum];

        //SetShootingPerk(currentShooting);

        //start of setting bullet perk
        randomNum = Random.Range(0, bulletRarity.Count);

        List<PerkNames> bulletKeys = new List<PerkNames>(bulletRarity.Keys);
        PerkNames currentBullet = bulletKeys[randomNum];

        //gameObject.GetComponent<BulletEnumHolder>().bullet = currentBullet;

        //start of setting targeting perk
        randomNum = Random.Range(0,targetRarity.Count);

        List<PerkNames> targetKeys = new List<PerkNames>(targetRarity.Keys);
        PerkNames currentTarget = targetKeys[randomNum];

        //SetTargetPerk(currentTarget);

        PerkNames[] chosenPerks = {currentShooting, currentTarget, currentBullet};
        return chosenPerks;
        //gameObject.GetComponent<PerkManager>().enabled = false;
    }
    public void SetPerks(PerkNames[] perks, GameObject obj)
    {
        SetShootingPerk(perks[0],obj);
        SetTargetPerk(perks[1], obj);
        obj.GetComponent<BulletEnumHolder>().bullet = perks[2];
    }
    void SetShootingPerk(PerkNames current, GameObject obj)
    {
        switch (current)
        {
            case PerkNames.doubleShooting:
                obj.AddComponent<DoubleShooting>();
                break;
            case PerkNames.machineGunShooting:
                obj.AddComponent<MachineGunShoot>();
                break;
            case PerkNames.backShooting:
                obj.AddComponent<BackShooting>();
                break;
            case PerkNames.standardShooting:
                obj.AddComponent<StandardShoot>();
                break;
            default:
                print("SOMETHING went wrong and i dont know what PLEASE help me");
                break;
        }
    }

    void SetTargetPerk(PerkNames targetNames, GameObject obj)
    {
        switch (targetNames)
        {
            case PerkNames.randomTarget:
                obj.AddComponent<RandomTarget>();
                break;
            case PerkNames.firstTarget:
                obj.AddComponent<FirstTarget>();
                break;
            case PerkNames.closestTarget:
                obj.AddComponent<ClosestTarget>();
                break;
            case PerkNames.strongestTarget:
                obj.AddComponent<StrongestTarget>();
                break;
            default:
                print("SOMETHING went wrong and i dont know what PLEASE help me");
                break;
        }
    }
    
}