using UnityEngine;

public class BuildMode : MonoBehaviour
{
    [SerializeField] GameObject indicator;
    public void EnableBuildMode()
    {
        indicator.SetActive(true);
        gameObject.GetComponent<PlaceTower>().enabled = true;
    }
}
