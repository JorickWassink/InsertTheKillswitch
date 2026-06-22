using System.Collections;
using UnityEngine;

public class UIPopIn : MonoBehaviour
{
    [SerializeField] float duration = 0.3f;
    [SerializeField] bool playOnEnable = true;

    void OnEnable()
    {
        if (playOnEnable) StartCoroutine(PopIn());
    }

    public void PlayIn() => StartCoroutine(PopIn());
    public void PlayOut() => StartCoroutine(PopOut());

    IEnumerator PopIn()
    {
        transform.localScale = Vector3.zero;
        float t = 0f;

        while (t < duration)
        {
            t += Time.deltaTime;
            float p = t / duration;
            transform.localScale = Vector3.one * EaseOutCubic(p);
            yield return null;
        }

        transform.localScale = Vector3.one;
    }

    IEnumerator PopOut()
    {
        transform.localScale = Vector3.one;
        float t = 0f;

        while (t < duration)
        {
            t += Time.deltaTime;
            float p = t / duration;
            transform.localScale = Vector3.one * (1f - EaseInCubic(p));
            yield return null;
        }

        transform.localScale = Vector3.zero;
        gameObject.SetActive(false);
    }

    float EaseOutCubic(float x) => 1f - Mathf.Pow(1f - x, 3f);
    float EaseInCubic(float x) => x * x * x;
}