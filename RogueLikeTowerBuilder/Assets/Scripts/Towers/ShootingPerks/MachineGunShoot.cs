using UnityEngine;

public class MachineGunShoot : BaseShoot
{
    void Awake()
    {
        GetComponent<TowerBase>().attackSpeed = .1f;
        damage = .1f;
    }
}
