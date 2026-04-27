using UnityEngine;

public class PlaceTower : MonoBehaviour
{
    [Header("tower instatiate stuff")]
    [SerializeField] GameObject tower;
    [SerializeField] GameObject towerParent;
    [SerializeField] GameObject indicator;

    CashManager cash;

    int towerCost = 5;

    private void Start()
    {
        InputManager.PlaceTower += Place;
        cash = FindAnyObjectByType<CashManager>();
    }

    void Place(Vector2 pos)
    {
        if (!indicator.activeSelf) return;

        Collider2D hit = Physics2D.OverlapPoint(pos);

        if (hit != null && hit.isTrigger && hit.TryGetComponent<Road>(out _))
            return;

        if (cash.CheckCash(towerCost))
        {
            CashEvents.RemoveCashEvent?.Invoke(towerCost);
            Instantiate(tower, pos, Quaternion.identity, towerParent.transform);
            this.enabled = false;
            indicator.SetActive(false);
        }
    }
}
