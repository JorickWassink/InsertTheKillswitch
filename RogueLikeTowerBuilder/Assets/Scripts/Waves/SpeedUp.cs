using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    public void ToggleSpeedUp()
    {
        if(Time.timeScale == 2) Time.timeScale = 1;
        else Time.timeScale = 2;
    }
}
