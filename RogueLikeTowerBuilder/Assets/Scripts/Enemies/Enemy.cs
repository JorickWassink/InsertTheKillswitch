using System.Collections;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamagable, ISlowable
{
    public float hp = 5;
    public float speed = 1;
    public int value = 1;
    public GameObject bulletTarget;

    [SerializeField] GameObject textHolder;
    [SerializeField] GameObject textPos;

    public bool stunCooldown = false;

    CashManager cash;

    bool slowed = false;
    private void Start()
    {
        cash = FindAnyObjectByType<CashManager>();
    }

    void IDamagable.TakeDamage(float damage, Color color)
    {
        hp -= damage;
        DamagePopUp(damage, color);

        if (hp <= 0)
        {
            CashEvents.AddCashEvent?.Invoke(value);
            Destroy(gameObject);
        }
    }

    void DamagePopUp(float damage, Color color)
    {
        GameObject current = Instantiate(textHolder, textPos.transform);
        current.GetComponent<TMP_Text>().text = damage.ToString();
        current.GetComponent<TMP_Text>().color = color;
    }

    void ISlowable.SlowBehavior()
    {
        if(!slowed) StartCoroutine(SlowEnemy());
    }
    IEnumerator SlowEnemy()
    {
        slowed = true;
        speed /= 2;
        yield return new WaitForSeconds(10);
        slowed = false;
        speed *= 2;
    }

    public void Stun(float time)
    {
        if (stunCooldown) return;
        StartCoroutine(StartStun(time));
    }
    public IEnumerator StartStun(float time)
    {
        PathFinding path = gameObject.GetComponent<PathFinding>();
        path.enabled = false;
        yield return new WaitForSeconds(time);
        path.enabled = true;
        StartCoroutine(EnableStunCooldown());

    }

    private IEnumerator EnableStunCooldown()
    {
        stunCooldown = true;
        yield return new WaitForSeconds(6);
        stunCooldown = false;
    }
}
