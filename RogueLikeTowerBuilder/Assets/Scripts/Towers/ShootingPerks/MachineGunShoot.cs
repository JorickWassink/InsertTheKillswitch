using UnityEngine;

public class MachineGunShoot : BaseShoot
{
    void Start()
    {
        GetComponent<TowerBase>().attackSpeed = .1f;
        damage = .1f;
    }
}
