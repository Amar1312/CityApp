using UnityEngine;

public class EarthPanelDummyPoint : MonoBehaviour
{

    public Transform _targetPoint;

    private UiManager _uiManager;
    public GameObject _effect;

    private void OnEnable()
    {
        if (!UiManager.Instance._earthPanelModel.activeInHierarchy)
        {
            SetEarthPanelPoint();
        }
        onEffect();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    void SetEarthPanelPoint()
    {
        _uiManager = UiManager.Instance;

        _uiManager._earthPanelModel.transform.position = _targetPoint.position;
        var roat = this.transform.rotation;
        roat.x = 0f;
        roat.z = 0f;
        //roat.y = -roat.y;
        _uiManager._earthPanelModel.transform.rotation = roat;

        _uiManager.OffAllModel();
        _uiManager._earthPanelModel.SetActive(true);

        _uiManager._videoPlayScan = false;
    }

    void onEffect()
    {
        _effect.SetActive(true);
        Invoke(nameof(OffEffect), 1f);
    }

    void OffEffect()
    {
        _effect.SetActive(false);
    }
}
