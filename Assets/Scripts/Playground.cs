using System.Collections;
using System.IO;
using ImgurAPI;
using UnityEngine;

public class Playground : MonoBehaviour
{
    private IEnumerator Start()
    {
        var path = $"{Application.dataPath}/Screenshots";
        var fileName = "123";
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        path = $@"{path}/{fileName}.png";
        
        ScreenCapture.CaptureScreenshot(path);
        
        yield return new WaitForSeconds(.5f);
        
        Imgur.Upload(path);
    }
}
