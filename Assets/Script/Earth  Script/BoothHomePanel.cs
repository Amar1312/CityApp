using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class BoothHomePanel : MonoBehaviour
{
    public Button _playBtn, _powerBtn;

    public List<GameObject> _faceSet;
    public AudioClip _audioClip;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetFace(2);
        _playBtn.onClick.AddListener(PlayBtnClick);
        _powerBtn.onClick.AddListener(PowerBtnClick);
        float Time = _audioClip.length;
        Invoke(nameof(SmaileFace), Time + 0.3f);
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    void SmaileFace()
    {
        SetFace(1);
    }

    void PlayBtnClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void PowerBtnClick()
    {
        Application.OpenURL("https://www.mixed.place/");
    }

    public void SetFace(int Index)
    {
        for (int i = 0; i < _faceSet.Count; i++)
        {
            _faceSet[i].SetActive(false);
        }
        _faceSet[Index].SetActive(true);
    }
}
