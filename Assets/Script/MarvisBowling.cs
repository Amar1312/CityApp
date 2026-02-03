using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class MarvisBowling : MonoBehaviour
{
    [SerializeField] GameObject[] _spawnPoint;
    [SerializeField] GameObject _spawnObj;
    [SerializeField] float _force;
    [SerializeField] MeshRenderer _quad;
    [SerializeField] VideoPlayer _videoPlayer;
    [SerializeField] GameObject _ballPanel;
    [SerializeField] Button _ballBtn;
    [SerializeField] Animation _anim;
    public Transform _fishPoint;

    bool _completeOnce;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnEnable()
    {
        _anim = UiManager.Instance._ballBtnAnimation;
        _ballPanel = UiManager.Instance._ballPanel;
        _ballBtn = UiManager.Instance._ballBtn;
        _ballBtn.onClick.AddListener(BallBtnClick);
        if (_completeOnce)
        {
            ChildManager.Instance.DeactivateAllExcept(gameObject);
            _ballPanel.SetActive(true);
            UiManager.Instance.SetParentObj(_fishPoint);
        }
        _completeOnce = true;
    }

    private void OnDisable()
    {
        _quad.enabled = false;
        _ballPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (_videoPlayer.frame >= 2)
        {
            _quad.enabled = true;
        }
    }

    public void BallBtnClick()
    {
        UiManager.Instance.LookBackPanelOpen(false);
        _anim.Play();
        _videoPlayer.Play();
        Invoke(nameof(SpawnMarvisTube), 2);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("MainCamera"))
        {
            _ballPanel.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("MainCamera"))
        {
            _ballPanel.SetActive(false);
        }
    }

    public void SpawnMarvisTube()
    {
        for (int i = 0; i < _spawnPoint.Length; i++)
        {
            GameObject tube = Instantiate(_spawnObj, _spawnPoint[i].transform.position, _spawnPoint[i].transform.rotation, _spawnPoint[i].transform);
            Rigidbody rb = tube.GetComponent<Rigidbody>();
            rb.AddForce(rb.transform.up * _force, ForceMode.Impulse);
            Destroy(tube, 1.5f);
        }
        Invoke(nameof(LookBackpanelActive), 0.5f);
    }

    void LookBackpanelActive()
    {
        UiManager.Instance.LookBackPanelOpen(true);
    }
}
