using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PaseteLooping : MonoBehaviour
{

    [SerializeField] GameObject _pasetGroup;
    //public VideoPlayer _videoPlayer;
    [SerializeField] MeshRenderer _quad;
    public Transform _fishPoint;
    bool _completeOnce;
    public bool _colliderSc;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnEnable()
    {
        //Commant code
        if (!_colliderSc)
        {
            _pasetGroup = UiManager.Instance._pasteGroup;
        }
        //_pasetGroup = UiManager.Instance._pasteGroup;
        _quad.enabled = true;
        if (_completeOnce)
        {
            ChildManager.Instance.DeactivateAllExcept(gameObject);
            _pasetGroup.SetActive(true);
            UiManager.Instance.SetParentObj(_fishPoint);
        }
        _completeOnce = true;
    }

    private void OnDisable()
    {
        _quad.enabled = false;
        _pasetGroup.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("MainCamera"))
        {
            _quad.enabled = true;
            _pasetGroup.SetActive(true);
        }
        else
        {
            _quad.enabled = false;
            _pasetGroup.SetActive(false);
        }
    }

    // Add code

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("MainCamera"))
        {
            _quad.enabled = false;
            _pasetGroup.SetActive(false);
        }
        
    }


}
