using UnityEngine;

public interface IShootable
{
    public void Shoot(Vector3 target);

    public float damage { get; set; }
}
