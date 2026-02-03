using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoPanel : MonoBehaviour
{
    [SerializeField] Button _closeBtn;
    [SerializeField] GameObject _startPanel;
    [SerializeField] TrackingManager _trackingManager;


    // Start is called before the first frame update
    void Start()
    {
        _closeBtn.onClick.AddListener(CloseBtnClick);

    }

    void CloseBtnClick()
    {
        _startPanel.SetActive(true);
        _trackingManager.enabled = true;
        gameObject.SetActive(false);
    }
}
