using UnityEngine;
using UnityEngine.UI;

public class RobotPanelGamePanel : MonoBehaviour
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
        UiManager.Instance._robotPanelModel.SetActive(false);
    }
}
