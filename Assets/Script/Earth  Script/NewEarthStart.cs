using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewEarthStart : MonoBehaviour
{
    public Vector3 rotationSpeed = new Vector3(0f, 50f, 0f);
    public GameObject _earthObj;

    public GameObject _gamePanel;

    public Button _startBtn, _endBtn;
    //public GameObject _startPanel;
    public Animator _animator;
    public List<GameObject> _earthEffect;
    public List<GameObject> _onStartEffect;
    public GameObject _maskBox;

    public Transform _robotPoint;
    public EarthGamePanel _earthGamePanel;

    public EarthLookCube _earthLookCude;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _earthObj.SetActive(false);
        _startBtn.onClick.AddListener(StartBtnClick);
        _endBtn.onClick.AddListener(EndBtnClick);
    }


    private void OnEnable()
    {
        //var Lookat = Quaternion.LookRotation(Camera.main.transform.forward);
        //Lookat.x = 0;
        //Lookat.z = 0;
        //this.transform.rotation = Lookat;
        _animator.enabled = true;
        UiManager.Instance._sphereFollow.NearpointSet(_robotPoint.position);
        Invoke(nameof(RobotSpack), 0f);

        //_startBtn.gameObject.SetActive(true);
        _earthLookCude._onStart = true;
        _endBtn.gameObject.SetActive(false);
    }

    void RobotSpack()
    {
        UiManager.Instance._robotAnimator.SetTrigger("PointRight");
        BoothAudioManager.Instance.AudioPlay(4);
    }

    void EndBtnClick()
    {
        UiManager.Instance._sphereFollow.BackPosition();
        BoothAudioManager.Instance.AudioPlay(1);
        UiManager.Instance._earthModel.SetActive(false);
    }

    void StartBtnClick()
    {
        _earthObj.SetActive(true);
        _animator.SetTrigger("StartPlay");
        InvokeRepeating(nameof(RotateEarth), 7f, 0.001f);
        Invoke(nameof(GamePanelON), 15f);
        Invoke(nameof(ONEarthEffect), 5f);
        ONStartEffect(true);
        _startBtn.gameObject.SetActive(false);
        _earthLookCude._onStart = false;
        _endBtn.gameObject.SetActive(true);
    }

    void RotateEarth()
    {
        _earthObj.transform.Rotate(rotationSpeed * Time.deltaTime);
    }

    void GamePanelON()
    {
        _gamePanel.SetActive(true);
        OffMaskBox();
    }

    void ONEarthEffect()
    {
        for (int i = 0; i < _earthEffect.Count; i++)
        {
            _earthEffect[i].SetActive(true);
        }
    }

    void ONStartEffect(bool On)
    {
        for (int i = 0; i < _onStartEffect.Count; i++)
        {
            _onStartEffect[i].SetActive(On);
        }
    }

    void OffMaskBox()
    {
        //_maskBox.SetActive(false);
    }

    private void OnDisable()
    {
        ResetAllData();
    }

    void ResetAllData()
    {

        _earthGamePanel.ResetData();
        _earthObj.SetActive(false);
        //_startBtn.gameObject.SetActive(true);
        _earthLookCude._onStart = true;
        CancelInvoke(nameof(RotateEarth));
        _gamePanel.SetActive(false);
        //_maskBox.SetActive(true);

        for (int i = 0; i < _earthEffect.Count; i++)
        {
            _earthEffect[i].SetActive(false);
        }

        ONStartEffect(false);

        //_animator.enabled = true;
        //_animator.speed = -1f;
        //_animator.Play("NewEarthClip", 0, 1f);

        //_animator.enabled = false;
    }

}
