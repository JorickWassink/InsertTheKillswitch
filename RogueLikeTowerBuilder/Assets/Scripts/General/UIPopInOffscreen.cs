using System.Collections;
using UnityEngine;

public class UIPopInOffscreen : MonoBehaviour
{
    [SerializeField] float duration = 0.3f;
    [SerializeField] RectTransform target;
    [SerializeField] Transform onScreenPos;
    [SerializeField] Transform offScreenPos;

    public bool IsOnScreen { get; private set; }

    void Awake()
    {
        if (target == null) target = (RectTransform)transform;
        target.anchoredPosition = new Vector2(offScreenPos.position.x, offScreenPos.position.y);
    }

    public void PlayIn()
    {
        print("testplay");
        StopAllCoroutines();
        StartCoroutine(Move(new Vector2(offScreenPos.position.x, offScreenPos.position.y), new Vector2(onScreenPos.position.x, onScreenPos.position.y), EaseOutCubic));
    }

    public void PlayOut()
    {
        print("testplayout");
        StopAllCoroutines();
        StartCoroutine(Move(new Vector2(onScreenPos.position.x, onScreenPos.position.y), new Vector2(offScreenPos.position.x, offScreenPos.position.y), EaseInCubic));
    }

    IEnumerator Move(Vector2 from, Vector2 to, System.Func<float, float> ease)
    {
        target.anchoredPosition = from;
        float t = 0f;

        while (t < duration)
        {
            t += Time.deltaTime;
            float p = ease(t / duration);
            target.anchoredPosition = Vector2.LerpUnclamped(from, to, p);
            yield return null;
        }

        target.anchoredPosition = to;
        IsOnScreen = (to == new Vector2(onScreenPos.position.x, onScreenPos.position.y));
    }

    float EaseOutCubic(float x) => 1f - Mathf.Pow(1f - x, 3f);
    float EaseInCubic(float x) => x * x * x;
}