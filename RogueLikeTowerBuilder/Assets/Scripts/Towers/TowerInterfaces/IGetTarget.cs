using UnityEngine;
using System.Collections;

public interface IGetTarget
{
    IEnumerator CheckTargets(float range);
    Vector3 GetTarget(Collider2D[] targets);
}
