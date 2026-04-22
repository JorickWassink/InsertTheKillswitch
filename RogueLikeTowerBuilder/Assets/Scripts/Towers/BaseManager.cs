using UnityEngine;
using TMPro;

public class BaseManager : MonoBehaviour
{
    [SerializeField] TMP_Text healthNumber;
    int health = 3;
    private void Start()
    {
        HealthCheck();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.TryGetComponent<Enemy>(out Enemy enemy);

        if(enemy != null)
        {
            Destroy(enemy.gameObject);
            health -= 1;
            HealthCheck();
        }
    }

    void HealthCheck()
    {
        if (health <= 0)
        {
            print("you lowkey should be dead rn");
        }

        healthNumber.text = health.ToString();
    }
}
