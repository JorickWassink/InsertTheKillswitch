using UnityEngine;

public class EnableChildren : MonoBehaviour
{
    
    void Awake()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);  
        }    
    }
}
