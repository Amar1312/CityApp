using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RobotPanel : MonoBehaviour
{
    public Button _animationBtn;
    public Button _faceBtn;

    public Animator _robotAnimator;
    public int _animationCount;

    public List<GameObject> _faceSet;

    private int _faceId = 0;
    private int _animationId = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _animationBtn.onClick.AddListener(AnimationBtnClick);
        _faceBtn.onClick.AddListener(FaceSetBtnClick);
    }

    void AnimationBtnClick()
    {
        _animationId += 1;
        if (_animationId == _animationCount)
        {
            _animationId = 0;
        }
        _robotAnimator.SetInteger("AnimationID", _animationId);
        _animationBtn.enabled = false;
        Invoke(nameof(ButtonOn), 3f);
    }

    void ButtonOn()
    {
        _animationBtn.enabled = true;
    }

    void FaceSetBtnClick()
    {
        _faceId += 1;
        if (_faceId == _faceSet.Count)
        {
            _faceId = 0;
        }
        for (int i = 0; i < _faceSet.Count; i++)
        {
            _faceSet[i].SetActive(false);
        }
        _faceSet[_faceId].SetActive(true);

    }
}
