using System;
using System.IO;
using Proyecto26;
using UnityEngine;

namespace ImgurAPI
{
	public static class Imgur
	{
		private const string BASE_PATH = "https://api.imgur.com/3";

		public static void Init(string token)
		{
			RestClient.DefaultRequestHeaders["Authorization"] = $"Bearer {token}";
		}

		public static void Upload(string imagFilePath)
		{
			var fileStream = File.OpenRead(imagFilePath);
			var imageData = new byte[fileStream.Length];
			fileStream.Read(imageData, 0, imageData.Length);
			fileStream.Close();

			var form = new WWWForm();
			form.AddBinaryData("image", imageData);
			form.AddField("type", "file");
			form.AddField("album", "i6hAERx");

			var request = new RequestHelper
			{
				Uri = BASE_PATH + "/upload",
				FormData = form,
				EnableDebug = true
			};
			RestClient.Post<ImgurUploadResponse>(request)
				.Then(res => { Debug.Log(JsonUtility.ToJson(res, true)); })
				.Catch(err => Debug.Log(err.Message));
		}
	}

	[Serializable]
	public class ImgurUploadResponse
	{
		public Data data;
		public bool success;
		public long status;
	}

	[Serializable]
	public class Data
	{
		public string id;
		public string title;
		public string description;
		public long datetime;
		public string type;
		public bool animated;
		public long width;
		public long height;
		public long size;
		public long views;
		public long bandwidth;
		public object vote;
		public bool favorite;
		public object nsfw;
		public object section;
		public object accountUrl;
		public long accountId;
		public bool isAd;
		public bool inMostViral;
		public bool hasSound;
		public object[] tags;
		public long adType;
		public string adUrl;
		public long edited;
		public bool inGallery;
		public string deletehash;
		public string name;
		public string link;
	}
}