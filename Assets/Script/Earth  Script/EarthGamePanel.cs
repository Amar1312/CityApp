using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class EarthGamePanel : MonoBehaviour
{
    public Button _stopBtn;
    public GameObject _earthObj;
    public GameObject _centerSatellite;
    public GameObject _satelliteObj;

    public Animator _animator;

    public List<GameObject> _onObject;
    public List<GameObject> _offObject;
    public GameObject _parentSatellite;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _stopBtn.onClick.AddListener(StopBtnClick);
    }

    void StopBtnClick()
    {
        Debug.Log("Stop Call");
        _animator.enabled = false;

        _centerSatellite.transform.SetParent(_earthObj.transform);
        _stopBtn.gameObject.SetActive(false);

        for (int i = 0; i < _onObject.Count; i++)
        {
            _onObject[i].SetActive(true);
        }
        for (int i = 0; i < _offObject.Count; i++)
        {
            _offObject[i].SetActive(false);
        }
    }

    public void ResetData()
    {
        _stopBtn.gameObject.SetActive(true);
        _centerSatellite.transform.SetParent(_parentSatellite.transform);
        _centerSatellite.transform.SetSiblingIndex(1);
        for (int i = 0; i < _onObject.Count; i++)
        {
            _onObject[i].SetActive(false);
        }
        for (int i = 0; i < _offObject.Count; i++)
        {
            _offObject[i].SetActive(true);
        }
    }

   
}