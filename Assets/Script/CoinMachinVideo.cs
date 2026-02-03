using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class CoinMachinVideo : MonoBehaviour
{
    public GameObject _coinPanel;
    [SerializeField] MeshRenderer _quad;
    [SerializeField] VideoPlayer _videoPlayer;
    public Transform _fishPoint;
    public bool _colliderSc;


    bool _completeOnce;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnEnable()
    {
        // commant first Line Code
        if (!_colliderSc)
        {
            _coinPanel = UiManager.Instance._coinPanel;
        }
        //_coinPanel = UiManager.Instance._coinPanel;

        if (_completeOnce)
        {
            ChildManager.Instance.DeactivateAllExcept(gameObject);
            _coinPanel.SetActive(true);
            UiManager.Instance.SetParentObj(_fishPoint);
        }
        _completeOnce = true;
    }


    private void OnDisable()
    {
        _coinPanel.SetActive(false);
        _quad.enabled = false;
    }


    void Update()
    {

        if (_videoPlayer.frame >= 2)
        {
            _quad.enabled = true;
        }
    }

    //Code is Comment 

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("MainCamera"))
        {
            _coinPanel.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("MainCamera"))
        {
            _coinPanel.SetActive(false);
            _quad.enabled = false;
        }
    }

}
