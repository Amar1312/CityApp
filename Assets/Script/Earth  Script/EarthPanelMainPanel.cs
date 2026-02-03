using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EarthPanelMainPanel : MonoBehaviour
{
    public Button _mainBtn, _whatBtn, _heutaBtn, _hybBtn;

    public List<Sprite> _mainSprite, _whatSprite, _heutaSprite, _hybSprite;

    public ImageChangePanel _imageChangePanel;

    public List<GameObject> _effect;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _mainBtn.onClick.AddListener(MainBtnClick);
        _whatBtn.onClick.AddListener(WhatBtnClick);
        _heutaBtn.onClick.AddListener(HeutaBtnClick);
        _hybBtn.onClick.AddListener(HybBtnClick);
        MainBtnClick();
    }

    void MainBtnClick()
    {
        _imageChangePanel.SetNewList(_mainSprite);
        onEffect(0);
    }

    void WhatBtnClick()
    {
        _imageChangePanel.SetNewList(_whatSprite);
        onEffect(1);
    }

    void HeutaBtnClick()
    {
        _imageChangePanel.SetNewList(_heutaSprite);
        onEffect(2);
    }

    void HybBtnClick()
    {
        _imageChangePanel.SetNewList(_hybSprite);
        onEffect(3);
    }

    void onEffect(int Index)
    {
        _effect[Index].SetActive(true);
        Invoke(nameof(OffEffect), 1f);
    }

    void OffEffect()
    {
        for (int i = 0; i < _effect.Count; i++)
        {
            _effect[i].SetActive(false);
        }
    }
}
