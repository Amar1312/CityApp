using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public static UiManager Instance;

    public GameObject _coinPanel, _galleryPanel, _ballPanel;
    public Button _ballBtn, _galleryBtn;
    public GameObject _pasteGroup;
    public Animation _ballBtnAnimation;
    public GameObject _startPanel, _lookBackPanel;

    [Header("Coin")]
    public Button _coinbtn;
    public Animation _anim;
    public GameObject _taptoCoin;


    [Header("GalleryImage")]
    public QuadGallery _quadGallery;

    [Space]
    public UseBefore _useBeforePanel;

    public SphereFollow _sphereFollow;
    public Animator _robotAnimator;

    public GameObject _earthModel;
    public GameObject _solarModel;
    public GameObject _moonModel;
    public GameObject _earthPanelModel;
    public GameObject _moonPanelModel;
    public GameObject _videoPanelModel;
    public GameObject _robotPanelModel;

    public bool _videoPlayScan;

    

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

    // Start is called before the first frame update
    void Start()
    {
        _galleryBtn.onClick.AddListener(GalleryBtnClick);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("parent pos" + _parentobj.transform.position);
    }

    public void GalleryBtnClick()
    {
        _quadGallery.OpenGallery();
    }

    public void SetParentObj(Transform target)
    {
       
        //if (!_parentobj.activeSelf && !_spawnFishTypeModel)
        //{
        //    Debug.Log("set positon");
        //    _spawnFishTypeModel = true;
        //    _parentobj.transform.position = new Vector3(target.position.x,
        //           _parentobj.transform.position.y,
        //           target.position.z);
        //    Debug.Log("set possss" + _parentobj.transform.position);

        //    _parentobj.SetActive(true);
        //    _startPanel.SetActive(false);
        //    Invoke(nameof(OpenLookBackPanel), 2.5f);
        //}
    }

    public void LookBackPanelOpen(bool value)
    {
        //_lookBackPanel.SetActive(value);
    }

    void OpenLookBackPanel()
    {
        _lookBackPanel.SetActive(true);
    }

    public void OffAllModel()
    {
        _earthModel.SetActive(false);
        _moonModel.SetActive(false);
        _solarModel.SetActive(false);
        _moonPanelModel.SetActive(false);
        _earthPanelModel.SetActive(false);
        _videoPanelModel.SetActive(false);
        _robotPanelModel.SetActive(false);
    }

}

