using UnityEngine;

public class EarthDummyPoint : MonoBehaviour
{

    public Transform _targetPoint;

    private UiManager _uiManager;
    public GameObject _effect;

    private void OnEnable()
    {
        if (!UiManager.Instance._earthModel.activeInHierarchy)
        {
            SetEarthPoint();
        }
        onEffect();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void Update()
    {
        //Debug.Log(_targetPoint.localPosition + " local");
        //Debug.Log(_targetPoint.position + " World");
    }

    void SetEarthPoint()
    {
        _uiManager = UiManager.Instance;

        _uiManager._earthModel.transform.position = _targetPoint.position;
        var roat = this.transform.rotation;
        roat.x = 0f;
        roat.z = 0f;
        _uiManager._earthModel.transform.rotation = roat;

        _uiManager.OffAllModel();
        _uiManager._earthModel.SetActive(true);

        _uiManager._videoPlayScan = false;
    }

    void onEffect()
    {
        _effect.SetActive(true);
        Invoke(nameof(OffEffect), 1.5f);
    }

    void OffEffect()
    {
        _effect.SetActive(false);
    }
}
