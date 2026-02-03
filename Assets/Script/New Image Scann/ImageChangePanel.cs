using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ImageChangePanel : MonoBehaviour
{
    public Button _nextBtn, _backBtn;
    public Image _changeImage;
    public List<Sprite> _spriteList;

    private int currentIndex = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _nextBtn.onClick.AddListener(NextSprite);
        _backBtn.onClick.AddListener(PreviousSprite);
    }

    void NextSprite()
    {
        if (currentIndex < _spriteList.Count - 1)
        {
            currentIndex++;
            UpdateUI();
        }
    }

    void PreviousSprite()
    {
        if (currentIndex > 0)
        {
            currentIndex--;
            UpdateUI();
        }
    }

    void UpdateUI()
    {
        // Update image
        _changeImage.sprite = _spriteList[currentIndex];

        // Enable / Disable buttons
        _backBtn.gameObject.SetActive(currentIndex > 0);
        _nextBtn.gameObject.SetActive(currentIndex < _spriteList.Count - 1);
    }

    public void SetNewList(List<Sprite> _sprite)
    {
        _spriteList.Clear();
        for (int i = 0; i < _sprite.Count; i++)
        {
            _spriteList.Add(_sprite[i]);
        }
        currentIndex = 0;
        UpdateUI();
    }
}
