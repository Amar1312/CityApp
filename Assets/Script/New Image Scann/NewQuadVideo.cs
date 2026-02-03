using UnityEngine;
using UnityEngine.Video;

public class NewQuadVideo : MonoBehaviour
{

    public VideoPlayer _videoPlayer;
    public MeshRenderer _quad;

    private void OnEnable()
    {
        PlayVideo();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_videoPlayer.frame >= 2)
        {
            _quad.enabled = true;
        }
    }

    private void OnDisable()
    {
        _quad.enabled = false;
    }

    public void PlayVideo()
    {
        ChildManager.Instance.DeactivateAllExcept(gameObject);
        _videoPlayer.Play();
    }
}
