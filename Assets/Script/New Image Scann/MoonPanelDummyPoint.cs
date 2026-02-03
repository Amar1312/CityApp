using UnityEngine;

public class MoonPanelDummyPoint : MonoBehaviour
{
    public Transform _targetPoint;

    private UiManager _uiManager;
    public GameObject _effect;
    private void OnEnable()
    {
        if (!UiManager.Instance._moonPanelModel.activeInHierarchy)
        {
            SetMoonPanelPoint();
        }
        onEffect();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    void SetMoonPanelPoint()
    {
        _uiManager = UiManager.Instance;

        _uiManager._moonPanelModel.transform.position = _targetPoint.position;
        var roat = this.transform.rotation;
        roat.x = 0f;
        roat.z = 0f;
        //roat.y = -roat.y;
        _uiManager._moonPanelModel.transform.rotation = roat;

        _uiManager.OffAllModel();
        _uiManager._moonPanelModel.SetActive(true);

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
