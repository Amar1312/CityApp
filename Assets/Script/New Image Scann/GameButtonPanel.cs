using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameButtonPanel : MonoBehaviour
{
    public Button _earthBtn, _solarBtn, _moonBtn, _closeBtn;

    public GameObject _earthModel, _solarModel, _moonModel;
    public GameObject _targetObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _earthBtn.onClick.AddListener(EarthBtnClick);
        _solarBtn.onClick.AddListener(SolarBtnClick);
        _moonBtn.onClick.AddListener(MoonBtnClick);
        _closeBtn.onClick.AddListener(CloseBtnClick);

    }

    void EarthBtnClick()
    {
        _solarModel.SetActive(false);
        _moonModel.SetActive(false);

        _earthModel.transform.position = _targetObject.transform.position;
        _earthModel.transform.rotation = _targetObject.transform.rotation;
        _earthModel.SetActive(true);
    }

    void SolarBtnClick()
    {
        _earthModel.SetActive(false);
        _moonModel.SetActive(false);

        _solarModel.transform.position = _targetObject.transform.position;
        _solarModel.transform.rotation = _targetObject.transform.rotation;
        _solarModel.SetActive(true);
    }

    void MoonBtnClick()
    {
        _solarModel.SetActive(false);
        _earthModel.SetActive(false);

        _moonModel.transform.position = _targetObject.transform.position;
        _moonModel.transform.rotation = _targetObject.transform.rotation;
        _moonModel.SetActive(true);
    }

    void CloseBtnClick()
    {
        if (_earthBtn.gameObject.activeInHierarchy)
        {
            _earthBtn.gameObject.SetActive(false);
            _solarBtn.gameObject.SetActive(false);
            _moonBtn.gameObject.SetActive(false);
            //_closeBtn.GetComponentInChildren<Text>().text = "Open";
        }
        else
        {
            _earthBtn.gameObject.SetActive(true);
            _solarBtn.gameObject.SetActive(true);
            _moonBtn.gameObject.SetActive(true);
            //_closeBtn.GetComponentInChildren<Text>().text = "Close";
        }
    }

}
