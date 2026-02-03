using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class SwimingPool : MonoBehaviour
{
    public VideoPlayer _videoPlayer;
    public MeshRenderer _quad;
    public int _requiredframeCount;
    public ParticleSystem _effect;
    public Transform _fishPoint;


    bool _completeOnce;

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
        if (_videoPlayer.frame >= 2)
        {
            _quad.enabled = true;
        }

        if (_videoPlayer.frame == _requiredframeCount)
        {
            _effect.Play();
        }
    }
}
