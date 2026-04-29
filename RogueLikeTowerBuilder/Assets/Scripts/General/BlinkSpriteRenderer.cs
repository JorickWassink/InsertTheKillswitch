using UnityEngine;
using System.Collections;

public class BlinkSpriteRenderer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Blink());
    }

    IEnumerator Blink()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        while (true)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled;
            yield return new WaitForSeconds(0.5f);
        }
    }
}
