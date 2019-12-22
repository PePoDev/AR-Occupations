using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FancyScrollView.Example01;
using ImgurAPI;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using ZXing;

public class GameManager : MonoBehaviour
{
	public Image target;
	public Sprite[] occupations;

	public ScrollView scrollView = default;

	public Canvas main;
	public Canvas loading;
	
	[Header("Custom")] public Canvas custom;

	[Header("Result")] public Canvas result;
	public RawImage photo;
	public RawImage qrCode;

	private int m_currentSelection;
	private QrCodeGenerator m_qrGen;

	private void Awake()
	{
		Imgur.Init("4d7df76f84ab6ba442105ab432bf5abf0c5100a2");
	}

	private void Start()
	{
		result.gameObject.SetActive(false);
		var items = Enumerable.Range(0, occupations.Length)
			.Select(i => new ItemData(occupations[i]))
			.ToArray();

		scrollView.UpdateData(items);

		m_qrGen = qrCode.GetComponent<QrCodeGenerator>();
		scrollView.scroller.OnSelectionChanged(id => { m_currentSelection = id; });
	}

	public void ChangeOccupation()
	{
		target.overrideSprite = occupations[m_currentSelection];
	}

	public void Capture()
	{
		main.gameObject.SetActive(false);
		StartCoroutine(CaptureScreenAndUpload());

		IEnumerator CaptureScreenAndUpload()
		{
			var path = $"{Application.dataPath}/Screenshots";
			var fileName = $"screenshot-{DateTime.Now:MM-dd-HH-mm-ss-fffffff}";
			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}

			path = $@"{path}/{fileName}.png";

			ScreenCapture.CaptureScreenshot(path);
			yield return new WaitForSeconds(.5f);
			main.gameObject.SetActive(true);
			loading.gameObject.SetActive(true);

			var fileStream = File.OpenRead(path);
			var imageData = new byte[fileStream.Length];
			fileStream.Read(imageData, 0, imageData.Length);
			fileStream.Close();
			var texture = new Texture2D(64, 64, TextureFormat.ARGB32, false);
			texture.LoadImage(imageData);
			texture.name = Path.GetFileNameWithoutExtension(path);
			photo.texture = texture;

			Imgur.Upload(path)
				.Then(res =>
				{
					var tex = m_qrGen.GenerateBarcode(res.data.link, BarcodeFormat.QR_CODE);
					qrCode.texture = tex;
					qrCode.rectTransform.sizeDelta = new Vector2(tex.width, tex.height);

					result.gameObject.SetActive(true);
					loading.gameObject.SetActive(false);
				})
				.Catch(err => Debug.Log(err.Message));
		}
	}
}