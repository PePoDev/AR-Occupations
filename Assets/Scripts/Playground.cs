using System.IO;
using ImgurAPI;
using UnityEngine;

public class Playground : MonoBehaviour
{
    private void Start()
    {
        var path = $"{Application.dataPath}/screenshots";
        var fileName = "123";
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        ScreenCapture.CaptureScreenshot($@"{path}/{fileName}.png");
        // Imgur.Upload(@"C:\Users\PePoDev\Pictures\Wallpaper\apple-ipad-pro-2018-stock-4k-46-1920x1080.jpg");
    }
}
