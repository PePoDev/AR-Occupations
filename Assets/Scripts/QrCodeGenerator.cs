using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using ZXing;
using ZXing.Common;

public class QrCodeGenerator : MonoBehaviour
{
	public RawImage rawImage;

	public Texture2D GenerateBarcode(string targetData, BarcodeFormat targetFormat)
	{
		var sizeDelta = rawImage.rectTransform.sizeDelta;
		var bitMatrix = new MultiFormatWriter().encode(targetData, targetFormat, (int)sizeDelta.x, (int)sizeDelta.y);
		var pixels = new Color[bitMatrix.Width * bitMatrix.Height];
		var pos = 0;
		for (var y = 0; y < bitMatrix.Height; y++)
		{
			for (var x = 0; x < bitMatrix.Width; x++)
			{
				pixels[pos++] = bitMatrix[x, y] ? Color.black : Color.white;
			}
		}

		var tex = new Texture2D(bitMatrix.Width, bitMatrix.Height);
		tex.SetPixels(pixels);
		tex.Apply();
		return tex;
	}
}