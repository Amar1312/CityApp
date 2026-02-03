using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class QuadVideo : MonoBehaviour
{
    public VideoPlayer _videoPlayer;
    public MeshRenderer _quad;
    public GameObject _activeObjects;
    public Transform _fishPoint;
    public bool _questionComplete;
    public Transform _robotPoint;
    public Button _robotButton;
    public List<GameObject> _sidePanel;
    public GameObject _canvas;

    public int _audioIndex;

    bool _completeOnce;
    bool _onSidePanel = false;
    // Start is called before the first frame update
    void Start()
    {
        _robotButton.onClick.AddListener(RobotBtnClick);
    }

    private void OnEnable()
    {
        //UiManager.Instance._useBeforePanel._quadVideo = this;
        //if (_completeOnce)
        //{
        //    if (_questionComplete)
        //    {
        //        PlayVideo();
        //    }
        //    else
        //    {
        //        UiManager.Instance._useBeforePanel.gameObject.SetActive(true);
        //    }
        //}
        //_completeOnce = true;
        if (UiManager.Instance._videoPlayScan)
        {
            _canvas.SetActive(true);
            PlayVideo();
            if (_robotPoint != null)
            {
                UiManager.Instance._sphereFollow.SetRobotpoint(_robotPoint.position);
            }
        }

    }

    private void OnDisable()
    {
        _quad.enabled = false;
        UiManager.Instance._sphereFollow.BackPosition();
        _canvas.SetActive(false);
        _activeObjects.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (_videoPlayer.frame >= 2)
        {
            _activeObjects.SetActive(true);
            _quad.enabled = true;
        }
    }

    public void SetVideoClip()
    {

    }

    public void PlayVideo()
    {
       // ChildManager.Instance.DeactivateAllExcept(gameObject);
        _videoPlayer.Play();
        //UiManager.Instance.SetParentObj(_fishPoint);
        //BoothAudioManager.Instance.AudioPlay(_audioIndex);
    }

    void RobotBtnClick()
    {
        _onSidePanel = !_onSidePanel;
        for (int i = 0; i < _sidePanel.Count; i++)
        {
            _sidePanel[i].SetActive(_onSidePanel);
        }
    }

}
