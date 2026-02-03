using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoonPanelMainPanel : MonoBehaviour
{
    public Button _mainBtn, _hybBtn, _hyb2Btn;

    public List<Sprite> _mainSprite, _hybSprite, _hyb2Sprite;

    public ImageChangePanel _imageChangePanel;

    public List<GameObject> _effect;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _mainBtn.onClick.AddListener(MainBtnClick);
        _hybBtn.onClick.AddListener(HybBtnClick);
        _hyb2Btn.onClick.AddListener(Hyb2BtnClick);
        MainBtnClick();
    }

    void MainBtnClick()
    {
        _imageChangePanel.SetNewList(_mainSprite);
        onEffect(0);
    }

    void HybBtnClick()
    {
        _imageChangePanel.SetNewList(_hybSprite);
        onEffect(1);
    }

    void Hyb2BtnClick()
    {
        _imageChangePanel.SetNewList(_hyb2Sprite);
        onEffect(2);
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
