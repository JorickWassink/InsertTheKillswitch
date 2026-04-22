using UnityEngine;

public class BulletPierce : MonoBehaviour, IBulletEffect, IDestroyable
{
    void IBulletEffect.ApplyEffect(Enemy enemy, float damage)
    {
        //nothing special but should still be here incase of null reference which i might change later if it effects performance or some shi HELP charlie kirk
    }

    void IDestroyable.DestroyBehavior(Collider2D col)
    {
        if(col.TryGetComponent<MapBoundary>(out MapBoundary bounds))
        {
            Destroy(gameObject);
        }

    }
}
