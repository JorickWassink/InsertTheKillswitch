using UnityEngine;
using TMPro;

public class DamagePopUp : MonoBehaviour
{
    TMP_Text damageText;
    private void Start()
    {
        damageText = GetComponent<TMP_Text>();
    }
    void FixedUpdate()
    {
        if (damageText.alpha <= 0) Destroy(this);
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, transform.position.y + .05f),.1f);
        damageText.alpha -= .05f;
    }
}
