using UnityEngine;

public class EnemyEnabler : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.GetComponent<Enemy>().enabled = true;
    }
}
