using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class AllSpritePanel : MonoBehaviour
{
    public Button _mainBtn, _ecoSteamBtn, _hydrelixBtn, _hybBtn, _magSaveBtn;

    public List<Sprite> _mainSprite, _ecoSteamSprite, _hydrelixSprite, _hybSprite, _magSaveSprite;

    public ImageChangePanel _imageChangePanel;
    public List<GameObject> _effect;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _ecoSteamBtn.onClick.AddListener(EcoStemBtnClick);
        _hydrelixBtn.onClick.AddListener(HydrelixBtnClick);
        _hybBtn.onClick.AddListener(HybBtnClick);
        _magSaveBtn.onClick.AddListener(MagSaveBtnClick);
        _mainBtn.onClick.AddListener(MainBtnClick);
        MainBtnClick();
    }

    void MainBtnClick()
    {
        _imageChangePanel.SetNewList(_mainSprite);
        onEffect(0);
    }

    void EcoStemBtnClick()
    {
        _imageChangePanel.SetNewList(_ecoSteamSprite);
        onEffect(1);
    }

    void HydrelixBtnClick()
    {
        _imageChangePanel.SetNewList(_hydrelixSprite);
        onEffect(2);
    }

    void HybBtnClick()
    {
        _imageChangePanel.SetNewList(_hybSprite);
        onEffect(3);
    }

    void MagSaveBtnClick()
    {
        _imageChangePanel.SetNewList(_magSaveSprite);
        onEffect(4);
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
