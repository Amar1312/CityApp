using System.Collections.Generic;
using UnityEngine;

public class PlaceModelScript : MonoBehaviour
{
    public GameObject _gamePanel;
    public Transform _robotPoint;

    public List<GameObject> _startEffect;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void OnEnable()
    {
        //var Lookat = Quaternion.LookRotation(-Camera.main.transform.forward);
        //Lookat.x = 0;
        //Lookat.z = 0;
        //this.transform.rotation = Lookat;
        UiManager.Instance._sphereFollow.NearpointSet(_robotPoint.position);
        Invoke(nameof(RobotPlay), 0f);
        Invoke(nameof(OnEffect), 3f);
    }

    void RobotPlay()
    {
        BoothAudioManager.Instance.AudioPlay(6);
        UiManager.Instance._robotAnimator.SetTrigger("PointRight");
    }

    void Start()
    {

    }

    void OnGamePanel()
    {
        //_base.SetActive(false);
        _gamePanel.SetActive(true);
    }

    void OnEffect()
    {
        for (int i = 0; i < _startEffect.Count; i++)
        {
            _startEffect[i].gameObject.SetActive(true);
        }
    }
}
