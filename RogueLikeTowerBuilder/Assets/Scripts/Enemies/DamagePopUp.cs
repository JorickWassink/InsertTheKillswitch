using TMPro;
using UnityEngine;

public class DamagePopUp : MonoBehaviour
{
    TMP_Text damageText;

    [SerializeField] float minSpeed = 2f;
    [SerializeField] float maxSpeed = 4f;
    [SerializeField] float gravity = -9.8f;

    [SerializeField] float lifeTime = 1f;
    [SerializeField] float fadeStartTime = 0.5f;
    [SerializeField] float fadeSpeed = 2f;

    Vector2 velocity;
    float timer;

    void Start()
    {
        damageText = GetComponent<TMP_Text>();

        float angle = Random.Range(60f, 120f) * Mathf.Deg2Rad;
        float speed = Random.Range(minSpeed, maxSpeed);
        velocity = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * speed;
    }

    void Update()
    {
        timer += Time.deltaTime;

        velocity.y += gravity * Time.deltaTime;
        transform.position += (Vector3)(velocity * Time.deltaTime);

        if (timer > fadeStartTime)
        {
            damageText.alpha -= fadeSpeed * Time.deltaTime;
            if (damageText.alpha <= 0f) Destroy(gameObject);
        }
    }
}
