using UnityEngine;

public class PlaceTower : MonoBehaviour
{
    [Header("tower instatiate stuff")]
    [SerializeField] GameObject tower;
    [SerializeField] GameObject towerParent;
    [SerializeField] GameObject indicator;

    CashManager cash;

    public PerkNames[] perks;

    private void Start()
    {
        InputManager.PlaceTower += Place;
    }

    void Place(Vector2 pos)
    {
        if (!indicator.activeSelf) return;

        Collider2D hit = Physics2D.OverlapPoint(pos);

        if (CheckPlace(hit)) return;




        GameObject current = Instantiate(tower, pos, Quaternion.identity, towerParent.transform);
        FindAnyObjectByType<PerkManager>().SetPerks(perks, current);
        this.enabled = false;
        indicator.SetActive(false);

    }

    bool CheckPlace(Collider2D _hit)
    {
        if(_hit == null) return false;
        if(_hit.TryGetComponent<Road>(out _)) return true;
        if(_hit.TryGetComponent<UIElement>(out _)) return true;

        return false;
    }


}
