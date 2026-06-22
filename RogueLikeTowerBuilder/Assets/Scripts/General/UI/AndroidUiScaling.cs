using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class AndroidUiScaling : MonoBehaviour
{
    [SerializeField] List<RectTransform> scalingElements = new List<RectTransform>();
    void Start()
    {
        if(Application.platform == RuntimePlatform.Android)
        {   
            foreach(RectTransform rectTransform in scalingElements)
            {

            }
        }
    }
}
