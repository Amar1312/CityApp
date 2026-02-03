using UnityEngine;
using UnityEngine.UI;

public class EarthPanelGamePanel : MonoBehaviour
{
    public Button _endBtn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _endBtn.onClick.AddListener(EndBtnClick);
    }

    void EndBtnClick()
    {
        UiManager.Instance._earthPanelModel.SetActive(false);
    }
}
