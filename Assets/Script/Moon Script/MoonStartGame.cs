using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MoonStartGame : MonoBehaviour
{
    public Button _startBtn, _endBtn;
    public Animator _moonAnimator;
    public Animator _alianAnimator;
    public List<GameObject> _startOnObj;

    public List<GameObject> _panelEffect;

    public TextMeshProUGUI _countText;

    public Transform _robotPoint;
    public Transform _mainObject;

    public MoonLookCude _moonLook;

    private void OnEnable()
    {
        //var Lookat = Quaternion.LookRotation(Camera.main.transform.forward);
        //Lookat.x = 0;
        //Lookat.z = 0;
        //_mainObject.rotation = Lookat;
        UiManager.Instance._sphereFollow.NearpointSet(_robotPoint.position);
        for (int i = 0; i < _startOnObj.Count; i++)
        {
            _startOnObj[i].SetActive(false);
        }
        _countText.text = "";
        _moonAnimator.speed = 1f;
        Invoke(nameof(RobotPlay), 0f);
        //_startBtn.gameObject.SetActive(true);
        _moonLook._onStart = true;
        _endBtn.gameObject.SetActive(false);
        _alianAnimator.gameObject.SetActive(false);
    }


    void RobotPlay()
    {
        UiManager.Instance._robotAnimator.SetTrigger("PointLeft");
        BoothAudioManager.Instance.AudioPlay(2);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _startBtn.onClick.AddListener(StartBtnClick);
        _endBtn.onClick.AddListener(EndBtnClick);
        Invoke(nameof(PanelEffectON), 3f);
    }
    void EndBtnClick()
    {
        UiManager.Instance._sphereFollow.BackPosition();
        BoothAudioManager.Instance.AudioPlay(1);
        UiManager.Instance._moonModel.SetActive(false);
    }

    void StartBtnClick()
    {
        for (int i = 0; i < _startOnObj.Count; i++)
        {
            _startOnObj[i].SetActive(true);
        }
        _startBtn.gameObject.SetActive(false);
        _moonLook._onStart = false;
        _endBtn.gameObject.SetActive(true);
        _moonAnimator.SetTrigger("StartPlay");
    }

    
    void PanelEffectON()
    {
        for (int i = 0; i < _panelEffect.Count; i++)
        {
            _panelEffect[i].SetActive(true);
        }
    }

    //Call Event From Animator
    public void AnimatoarPause()
    {
        _moonAnimator.speed = 0f;

        StartCoroutine(CountText());
    }

    //Call Event From Animator
    public void AlianGO()
    {
        _alianAnimator.gameObject.SetActive(true);
        _alianAnimator.gameObject.transform.localScale = Vector3.zero;
        _alianAnimator.SetTrigger("AlianGo");
        
    }

    public void AnimatorResume()
    {
        _moonAnimator.speed = 1f;
        _countText.text = "";
    }

    IEnumerator CountText()
    {
        yield return new WaitForSeconds(0.5f);
        for (int i = 2026; i < 2127; i++)
        {
            _countText.text = i.ToString();
            yield return new WaitForSeconds(0.05f);
        }

        yield return new WaitForSeconds(1.5f);
        AnimatorResume();
    }
}
