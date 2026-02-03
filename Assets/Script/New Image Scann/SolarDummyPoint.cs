using UnityEngine;

public class SolarDummyPoint : MonoBehaviour
{
    public Transform _targetPoint;

    private UiManager _uiManager;
    public GameObject _effect;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        if (!UiManager.Instance._solarModel.activeInHierarchy)
        {
            SetSolarPoint();
        }
        onEffect();
    }

    void SetSolarPoint()
    {
        _uiManager = UiManager.Instance;

        _uiManager._solarModel.transform.position = _targetPoint.position;

        var roat = this.transform.rotation;
        roat.x = 0f;
        roat.z = 0f;
       // roat.y = roat.y;
        _uiManager._solarModel.transform.rotation = roat;

        _uiManager.OffAllModel();
        _uiManager._solarModel.SetActive(true);

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
