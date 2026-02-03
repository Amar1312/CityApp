using UnityEngine;

public class VideoPanelModel : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnEnable()
    {
        Invoke(nameof(RobotPlay), 0f);
    }
    void RobotPlay()
    {
        BoothAudioManager.Instance.AudioPlay(8);
        UiManager.Instance._robotAnimator.SetTrigger("Spach");
    }

    private void OnDisable()
    {
        UiManager.Instance._sphereFollow.BackPosition();
    }
}
