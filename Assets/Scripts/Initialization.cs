using ImgurAPI;
using UnityEngine;

public class Initialization : MonoBehaviour
{
    private void Awake()
    {
        Imgur.Init("4d7df76f84ab6ba442105ab432bf5abf0c5100a2");
    }
}
