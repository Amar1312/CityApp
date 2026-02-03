using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    public static VideoManager instance;

    public List<VideoClip> _videoclips;
    public List<MeshRenderer> _quads;
    public List<ParticleSystem> _effect;
    VideoPlayer _player;
    int framecount;
    bool _isplaying;
    Coroutine ActiveQuad;
    public int _id;
    public int _requiredframeCount;

    //public bool a, b, c;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        _player = GetComponent<VideoPlayer>();
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    // Update is called once per frame
    void Update()
    {
        if (_id == 1)
        {
            if (_player.frame == _requiredframeCount)
            {
                _effect[_id].Play();
            }


            //if (_player.frame >= 15 && _player.frame <= 30 && !a)
            //{
            //    a = true;
            //    b = false;
            //    c = false;
            //    _effect[_id].Play();
            //    Debug.Log(_player.frame);
            //}
            //else if (_player.frame >= 60 && _player.frame <= 75 && !b)
            //{
            //    b = true;
            //    c = false;
            //    a = false;
            //    _effect[_id].Play();
            //    Debug.Log(_player.frame);
            //}
            //else if (_player.frame >= 105 && _player.frame <= 120 && !c)
            //{
            //    c = true;
            //    a = false;
            //    b = false;
            //    _effect[_id].Play();
            //    Debug.Log(_player.frame);
            //}

            Debug.Log(_player.frame);
        }

    }

    public void PlayVideo(int id)
    {
        _id = id;
        _player.clip = _videoclips[id];
        _player.Play();
        _player.targetMaterialRenderer = _quads[id];
        ActiveQuad = StartCoroutine(IenuActiveQuad(id));
        //_effect[_id].Play();
    }

    public void StopVideo(int id)
    {
        _quads[id].enabled = false;
        _player.Stop();
        //_effect[_id].Stop();
    }

    IEnumerator IenuActiveQuad(int id)
    {
        yield return new WaitUntil(() => (int)_player.frame > 2);
        _quads[id].enabled = true;
    }
}
