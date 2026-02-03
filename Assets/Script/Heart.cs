using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using DG.Tweening;

public class Heart : MonoBehaviour
{
    public VideoPlayer _videoPlayer;
    public MeshRenderer _quad;
    public int _requiredframeCount;
    public Transform _position1, _position2, _position3;
    public GameObject _heart;
    public Transform _fishPoint;
    bool _completeOnce;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnEnable()
    {
        if (_completeOnce)
        {
            ChildManager.Instance.DeactivateAllExcept(gameObject);
            UiManager.Instance.SetParentObj(_fishPoint);
        }
        _completeOnce = true;
    }

    private void OnDisable()
    {
        _quad.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_videoPlayer.frame >= 1)
        {
            _quad.enabled = true;
        }
        if (_videoPlayer.frame == _requiredframeCount)
        {
            DisplayHeart();
        }
    }


    void DisplayHeart()
    {
        _heart.SetActive(true);
        _heart.transform.DOScale(Vector3.one * 1.2f, 1f)
           .SetEase(Ease.Linear);
        _heart.transform.DOLocalMove(_position2.localPosition, 1f).SetEase(Ease.Linear);
        _heart.transform.DOLocalMove(_position3.localPosition, 1f).SetEase(Ease.Linear).SetDelay(1f).OnComplete(HeartOff);
    }

    void HeartOff()
    {
        _heart.SetActive(false);
        _heart.transform.localPosition = _position1.localPosition;
        _heart.transform.localScale = Vector3.one * 0.5f;
    }
}
