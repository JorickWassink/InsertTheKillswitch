using System;
using System.Collections;
using UnityEngine;

public class TowerBase : MonoBehaviour
{
    [Header("Stats")]
    public float range = 5;
    public float attackSpeed = 1;
    float baseDamage;

    [Header("References")]
    public GameObject bullet;
    IShootable shootable;
    IGetTarget getTarget;

    public Collider2D[] hits;
    Coroutine checkTargets;

    public Transform arrowIcon;
    public float orbitRadius = 1.2f;

    protected virtual void Start()
    {
        bullet = BulletHolder.bulletInstance;
        StartCoroutine(GetInterfaces());

        arrowIcon = GetComponentInChildren<TowerIndicator>().gameObject.transform;

        baseDamage = gameObject.GetComponent<IShootable>().damage;

        JokerEvents.OnJokerRefresh += UpdateDamage;
        JokerEvents.OnJokerRefresh?.Invoke();
    }

    void UpdateDamage()
    {
        gameObject.GetComponent<IShootable>().damage = baseDamage;
        gameObject.GetComponent<IShootable>().damage += EventHandler.towerSpawnReturn?.Invoke(gameObject) ?? 0;
    }

    public void RotateTowards(Vector3 targetPos)
    {
        targetPos.x -= 0.5f;
        Vector2 direction = ((Vector2)targetPos - (Vector2)transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        arrowIcon.position = (Vector2)transform.position + direction * orbitRadius;
        arrowIcon.rotation = Quaternion.Euler(0, 0, angle - 135f);
    }


    protected virtual void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    IEnumerator GetInterfaces()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            getTarget = GetComponent<IGetTarget>();
            if(getTarget != null && checkTargets == null) checkTargets = StartCoroutine(getTarget.CheckTargets(range));
        }
    }
}