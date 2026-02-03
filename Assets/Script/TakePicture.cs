using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Amar
{
	public class TakePicture : MonoBehaviour
	{
		public GameObject Screeshot;
		public RawImage _image;
		public GameObject _DeactiveCanvas;

		// Start is called before the first frame update
		void Start()
		{

		}

		// Update is called once per frame
		void Update()
		{

		}

		public void LoadHome()
        {
			SceneManager.LoadScene(0);
        }

		public void TakeCameraPicture()
		{
			/*			//ScreenshotHandler.TakeScreenshot_Static(Screen.width, Screen.height);
			#if UNITY_ANDROID
						if (!Permission.HasUserAuthorizedPermission(Permission.ExternalStorageWrite))
						{
							Permission.RequestUserPermission(Permission.ExternalStorageWrite);
						}
			#endif
						//NativeToolkit.SaveScreenshot(DateTime.Now.ToString(CultureInfo.InvariantCulture), Application.productName);*/



			//	StartCoroutine(Screenshotsceen());
			StartCoroutine(TakeScreenshotAndSave());
		}

		private IEnumerator TakeScreenshotAndSave()
		{
			_DeactiveCanvas.SetActive(false);
			yield return new WaitForSeconds(0.5f);
			yield return new WaitForEndOfFrame();

			Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
			ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
			ss.Apply();
			_image.texture = ss;

			StartCoroutine(IenumStartScreenshot());
			NativeGallery.SaveImageToGallery(ss, "Toll", "Toll.png");
			_image.texture = ss;

			// Save the screenshot to Gallery/Photos
			//Debug.Log("Permission result: " + NativeGallery.SaveImageToGallery(ss, "GalleryTest", "Image.png"));
	
			yield return new WaitForSeconds(5.0f);
			// To avoid memory leaks
			Destroy(ss);
		}


		IEnumerator IenumStartScreenshot()
		{
			
			Screeshot.SetActive(true);
			yield return new WaitForSeconds(2.0f);
			Screeshot.SetActive(false);
			_DeactiveCanvas.SetActive(true);

		}
	}
}

