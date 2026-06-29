using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class ImageScanner : MonoBehaviour
{
    public List<string> foundImages = new List<string>();

    void Start()
    {
            ScanPictures();
    }

    void ScanPictures()
    {
        string picturesPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyPictures);

        string[] pngs = Directory.GetFiles(picturesPath, "*.png", SearchOption.AllDirectories);
        string[] jpgs = Directory.GetFiles(picturesPath, "*.jpg", SearchOption.AllDirectories);

        foundImages.AddRange(pngs);
        foundImages.AddRange(jpgs);

        Debug.Log($"Found {foundImages.Count} images");
    }
}