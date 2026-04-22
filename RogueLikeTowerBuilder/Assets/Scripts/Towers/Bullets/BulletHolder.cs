using UnityEngine;

public class BulletHolder : MonoBehaviour
{
    public static GameObject bulletInstance;

    [SerializeField] GameObject bullet;
    void Start()
    {
        bulletInstance = bullet;
    }


}
