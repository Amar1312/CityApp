using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RobotPanelMainPanel : MonoBehaviour
{
    public Button _mainBtn, _mindBtn;

    public List<Sprite> _mainSprite, _mindSprite;

    public ImageChangePanel _imageChangePanel;
    public List<GameObject> _effect;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _mainBtn.onClick.AddListener(MainBtnClick);
        _mindBtn.onClick.AddListener(MindBtnClick);
        MainBtnClick();
    }

    void MainBtnClick()
    {
        _imageChangePanel.SetNewList(_mainSprite);
        onEffect(0);
    }

    void MindBtnClick()
    {
        _imageChangePanel.SetNewList(_mindSprite);
        onEffect(1);
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
