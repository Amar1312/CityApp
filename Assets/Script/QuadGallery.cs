using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuadGallery : MonoBehaviour
{
    public Image LocalProfileImage;
    public GameObject _galleryPanel;
    public Transform _fishPoint;
    public Canvas _worldCanvas;

    bool _completeOnce;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnEnable()
    {
        UiManager.Instance._quadGallery = this;
        _worldCanvas.worldCamera = Camera.main;
        _galleryPanel = UiManager.Instance._galleryPanel;
        if (_completeOnce)
        {
            ChildManager.Instance.DeactivateAllExcept(gameObject);
            _galleryPanel.SetActive(true);
            UiManager.Instance.SetParentObj(_fishPoint);
        }
        _completeOnce = true;
    }

    private void OnDisable()
    {
        _galleryPanel.SetActive(false);
    }

    

    // Button Click
    public void OpenGallery()
    {
        NativeGallery.Permission permission = NativeGallery.GetImageFromGallery((path) =>
        {
            if (path != null)
            {
                // Load the image and create a texture
                Texture2D texture = NativeGallery.LoadImageAtPath(path);
                if (texture == null)
                {
                    Debug.Log("Couldn't load texture from " + path);
                    return;
                }

                // Create a Sprite from the texture and assign it to the Image component
                Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
                LocalProfileImage.sprite = sprite;
            }
        }, "Select an image", "image/*");

        Debug.Log("Permission result: " + permission);

        UiManager.Instance.LookBackPanelOpen(true);
    }

    // Code as Commant

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("MainCamera"))
        {
            _galleryPanel.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("MainCamera"))
        {
            _galleryPanel.SetActive(false);
        }
    }
}
