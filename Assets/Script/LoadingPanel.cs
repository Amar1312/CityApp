using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingPanel : MonoBehaviour
{
    public float _time;
    public GameObject _mainPanel, _model;
    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(OnObject), _time);
    }

    void OnObject()
    {
        _mainPanel.SetActive(true);
        _model.SetActive(true);
        gameObject.SetActive(false);
    }

    public void openURL()
    {
        Application.OpenURL("https://www.mixed.place/");
    }
}
