using ImgurAPI;
using UnityEngine;

public class Playground : MonoBehaviour
{
    private void Start()
    {
        var fileName = "123";
        ScreenCapture.CaptureScreenshot($@"{Application.dataPath}/screenshots/{fileName}.png");
        // Imgur.Upload(@"C:\Users\PePoDev\Pictures\Wallpaper\apple-ipad-pro-2018-stock-4k-46-1920x1080.jpg");
    }
}
