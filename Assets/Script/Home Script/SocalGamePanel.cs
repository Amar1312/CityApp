using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class SocalGamePanel : MonoBehaviour
{
    public Button _solarBtn, _endBtn;
    public Animator _baseAnimator;
    public List<Animation> _onAnimation;

    public List<GameObject> _offSolar;
    public List<GameObject> _onSolar;
    public SolarLookCube _solarLook;

    public Material targetMaterial;
    public Color startColor = Color.red;
    public Color endColor = Color.blue;
    public float duration = 2f;

    private void OnEnable()
    {
        _baseAnimator.SetBool("Remove", false);
        targetMaterial.color = startColor;

        for (int i = 0; i < _offSolar.Count; i++)
        {
            _offSolar[i].SetActive(true);
        }

        for (int i = 0; i < _onSolar.Count; i++)
        {
            _onSolar[i].SetActive(false);
        }
        _endBtn.gameObject.SetActive(false);
        _solarLook._onStart = true;
        //_solarBtn.gameObject.SetActive(true);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _solarBtn.onClick.AddListener(SolarBtnClick);
        _endBtn.onClick.AddListener(EndBtnClick);
    }
    void EndBtnClick()
    {
        UiManager.Instance._sphereFollow.BackPosition();
        BoothAudioManager.Instance.AudioPlay(1);
        UiManager.Instance._solarModel.SetActive(false);
    }

    void SolarBtnClick()
    {
        for (int i = 0; i < _offSolar.Count; i++)
        {
            _offSolar[i].SetActive(false);
        }

        for (int i = 0; i < _onSolar.Count; i++)
        {
            _onSolar[i].SetActive(true);
        }
        StartCoroutine(LerpColor());

        _solarBtn.gameObject.SetActive(false);
        _solarLook._onStart = false;
        _endBtn.gameObject.SetActive(true);
        OnAfterObjectClick();
    }

    void AnimationPlay()
    {
        for (int i = 0; i < _onAnimation.Count; i++)
        {
            _onAnimation[i].Play();
        }
    }

    void OnAfterObjectClick()
    {
        _baseAnimator.SetBool("Remove", true);
    }

    IEnumerator LerpColor()
    {
        float time = 0f;
        targetMaterial.color = startColor;

        while (time < duration)
        {
            time += Time.deltaTime;
            float t = time / duration;

            targetMaterial.color = Color.Lerp(startColor, endColor, t);
            yield return null;
        }

        // Ensure final color
        targetMaterial.color = endColor;
    }

}
