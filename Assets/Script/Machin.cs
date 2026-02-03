using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class Machin : MonoBehaviour
{
    //public List<GameObject> _toothPastes;
    public GameObject _spanPoint, _spanPoint1, _spanPoint2, _toothPast;
    public GameObject[] _spawnPast;
    public MeshRenderer _quadMesh;
    public float _force;
    public VideoPlayer _videoPlayer;
    public LayerMask _layer;
    public Animation _animation;
    public Button _coinBtn;
    public GameObject _tapCoin;
    private bool _startCorou = false;
    private Vector3 _CoinPosition, _coinScal;
    public bool _colliderSc;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnEnable()
    {
        //commant code 
        if (!_colliderSc)
        {
            _coinBtn = UiManager.Instance._coinbtn;
            _tapCoin = UiManager.Instance._taptoCoin;
            _animation = UiManager.Instance._anim;
        }
        //_coinBtn = UiManager.Instance._coinbtn;
        //_tapCoin = UiManager.Instance._taptoCoin;
        //_animation = UiManager.Instance._anim;

        _coinBtn.onClick.AddListener(CoinBtnClick);
        _CoinPosition = _coinBtn.gameObject.transform.position;
        _coinScal = _coinBtn.gameObject.transform.localScale;
    }


    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity, _layer))
        //    {
        //        if (!_startCorou)
        //        {
        //            //_animation.Play();
        //            StartCoroutine(ToothPastSpan());
        //            _startCorou = true;
        //            _videoPlayer.Play();
        //            __quadMesh.enabled = true;

        //        }
        //        //Debug.Log("jaimin.....");
        //        //GameObject SpanToothPast = Instantiate(_toothPast, _spanPoint.transform.position, Quaternion.Euler(90f,0f,0f), _spanPoint.transform);
        //        //Rigidbody rb= SpanToothPast.GetComponent<Rigidbody>();
        //        //rb.AddForce(new Vector3(0f, 0f, -_force));

        //        // Off ToothPast One By One
        //        //for (int i = 0; i < _toothPastes.Count; i++)
        //        //{
        //        //    if (_toothPastes[i].activeInHierarchy)
        //        //    {
        //        //        _toothPastes[i].SetActive(false);
        //        //        break;
        //        //    }
        //        //}



        //        // On All ToothPastes When Last ToothPast is Off
        //        //if (!_toothPastes[_toothPastes.Count - 1].activeInHierarchy)
        //        //{
        //        //    for (int i = 0; i < _toothPastes.Count; i++)
        //        //    {
        //        //        _toothPastes[i].SetActive(true);
        //        //    }
        //        //}

        //    }
        //}

        //Debug.Log(_videoPlayer.frame);
    }

    void CoinBtnClick()
    {
        if (!_startCorou)
        {
            _tapCoin.SetActive(false);
            _animation.Play();
            UiManager.Instance.LookBackPanelOpen(false);
            StartCoroutine(ToothPastSpan());
            _startCorou = true;
            _videoPlayer.Play();
        }

        //__quadMesh.enabled = true;
    }
    IEnumerator ToothPastSpan()
    {
        while (!_quadMesh.gameObject.activeSelf)
        {
            //wait...;
        }

        yield return new WaitForSeconds(1f);
        //_animation.Stop();

        for (int i = 0; i < 8; i++)
        {
            int num = Random.Range(1, 100);
            int index = Random.Range(0, _spawnPast.Length);
            if (66 >= num)
            {

                GameObject SpanToothPast1 = Instantiate(_spawnPast[index], _spanPoint1.transform.position, _spanPoint.transform.rotation, _spanPoint.transform);
                SpanToothPast1.transform.Rotate(new Vector3(0f, 0f, -20f));
                Rigidbody rb1 = SpanToothPast1.GetComponent<Rigidbody>();
                rb1.AddForce(new Vector3(-30f, 0f, -_force));
            }
            else if (33 >= num)
            {
                GameObject SpanToothPast = Instantiate(_spawnPast[index], _spanPoint2.transform.position, _spanPoint.transform.rotation, _spanPoint.transform);
                SpanToothPast.transform.Rotate(new Vector3(0f, 0f, 20f));
                Rigidbody rb = SpanToothPast.GetComponent<Rigidbody>();
                rb.AddForce(new Vector3(30f, 0f, -_force));
            }
            else
            {
                GameObject SpanToothPast2 = Instantiate(_spawnPast[index], _spanPoint.transform.position, _spanPoint.transform.rotation, _spanPoint.transform);
                Rigidbody rb2 = SpanToothPast2.GetComponent<Rigidbody>();
                rb2.AddForce(new Vector3(0f, 0f, -_force));
            }
            yield return new WaitForSeconds(1f);

        }
        _startCorou = false;
        _coinBtn.transform.position = _CoinPosition;
        _coinBtn.gameObject.transform.localScale = _coinScal;
        _tapCoin.SetActive(true);
        UiManager.Instance.LookBackPanelOpen(true);
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("MainCamera"))
        {
            StopAllCoroutines();

            _tapCoin.SetActive(true);
            _coinBtn.transform.position = _CoinPosition;
            _coinBtn.gameObject.transform.localScale = _coinScal;
            _animation.Stop();
            _startCorou = false;
            _videoPlayer.Stop();
        }
    }
}

