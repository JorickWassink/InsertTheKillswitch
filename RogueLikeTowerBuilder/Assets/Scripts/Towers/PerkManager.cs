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

public enum targetNames
{
    random,
    closest,
    first,
    strongest
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

    Dictionary<targetNames, rarities> targetRarity = new()
    {
        { targetNames.random, rarities.common },
        { targetNames.closest, rarities.common },
        { targetNames.first, rarities.common },
        { targetNames.strongest, rarities.common }
    };

    void Start()
    {
        //start of setting shooting perk
        int randomNum = Random.Range(0, shootingRarity.Count);

        List<shootingNames> shootingKeys = new List<shootingNames>(shootingRarity.Keys);
        shootingNames currentShooting = shootingKeys[randomNum];
        SetShootingPerk(currentShooting);

        //start of setting bullet perk
        randomNum = Random.Range(0, bulletRarity.Count);

        List<bulletNames> bulletKeys = new List<bulletNames>(bulletRarity.Keys);
        bulletNames currentBullet = bulletKeys[randomNum];

        gameObject.GetComponent<BulletEnumHolder>().bullet = currentBullet;

        //start of setting targeting perk
        randomNum = Random.Range(0,targetRarity.Count);

        List<targetNames> targetKeys = new List<targetNames>(targetRarity.Keys);
        targetNames currentTarget = targetKeys[randomNum];
        SetTargetPerk(currentTarget);

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

    void SetTargetPerk(targetNames targetNames)
    {
        switch (targetNames)
        {
            case targetNames.random:
                gameObject.AddComponent<RandomTarget>();
                break;
            case targetNames.first:
                gameObject.AddComponent<FirstTarget>();
                break;
            case targetNames.closest:
                gameObject.AddComponent<ClosestTarget>();
                break;
            case targetNames.strongest:
                gameObject.AddComponent<StrongestTarget>();
                break;
            default:
                print("SOMETHING went wrong and i dont know what PLEASE help me");
                break;
        }
    }
    
}