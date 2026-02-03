using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseBefore : MonoBehaviour
{
    [SerializeField] Button _yesbtn, _nobtn;
    public QuadVideo _quadVideo;


    // Start is called before the first frame update
    void Start()
    {
        _yesbtn.onClick.AddListener(YesBtnClick);
        _nobtn.onClick.AddListener(NoBtnClick);
    }

    void YesBtnClick()
    {
        gameObject.SetActive(false);
        _quadVideo.PlayVideo();
        _quadVideo._questionComplete = true;
    }

    void NoBtnClick()
    {
        gameObject.SetActive(false);
        _quadVideo.PlayVideo();
        _quadVideo._questionComplete = true;

    }



}
