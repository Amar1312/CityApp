using UnityEngine;
using UnityEngine.UI;

public class VideoPanelGamePanel : MonoBehaviour
{
    public Button _endBtn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _endBtn.onClick.AddListener(EndBtnClick);
    }

    void EndBtnClick()
    {
        BoothAudioManager.Instance.AudioPlay(1);
        UiManager.Instance._videoPanelModel.SetActive(false);
    }
}
