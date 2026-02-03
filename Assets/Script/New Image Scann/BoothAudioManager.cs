using System.Collections.Generic;
using UnityEngine;

public class BoothAudioManager : MonoBehaviour
{
    public static BoothAudioManager Instance;

    public AudioSource _audioSource;

    public List<AudioClip> _audioClip;

    public List<GameObject> _faceSet;
    public int _audioIndex;

    private void Awake()
    {
        if (Instance != this && Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke(nameof(PlayHii), 1.5f);
    }

    void PlayHii()
    {
        UiManager.Instance._robotAnimator.SetTrigger("Hiii");
        AudioPlay(0);
    }

    public void AudioPlay(int audioIndex)
    {

        CancelInvoke(nameof(SmaileFace));
        CancelInvoke(nameof(SecondAudio));

        _audioIndex = audioIndex;

        SetFace(2);
        _audioSource.Stop();
        _audioSource.clip = _audioClip[audioIndex];
        _audioSource.Play();

        float Length = _audioSource.clip.length;
        Invoke(nameof(SmaileFace), Length);
        Invoke(nameof(SecondAudio), Length + 1f);
    }

    void SecondAudio()
    {
        switch (_audioIndex)
        {
            case 2:
                AudioPlay(3);
                break;

            case 4:
                AudioPlay(5);
                break;

            case 6:
                AudioPlay(7);
                break;

            case 8:
                AudioPlay(9);
                break;

            case 10:
                AudioPlay(11);
                break;

            default:
                break;
        }
    }

    void SmaileFace()
    {
        SetFace(1);
    }

    public void SetFace(int Index)
    {
        for (int i = 0; i < _faceSet.Count; i++)
        {
            _faceSet[i].SetActive(false);
        }
        _faceSet[Index].SetActive(true);
    }
}
