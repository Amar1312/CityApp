using UnityEngine;

public class MoonDummyPoint : MonoBehaviour
{
    public Transform _targetPoint;

    private UiManager _uiManager;
    public GameObject _effect;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnEnable()
    {
        if (!UiManager.Instance._moonModel.activeInHierarchy)
        {
            SetMoonPoint();
        }
        onEffect();
    }

    void SetMoonPoint()
    {
        _uiManager = UiManager.Instance;

        _uiManager._moonModel.transform.position = _targetPoint.position;
        var roat = this.transform.rotation;
        roat.x = 0f;
        roat.z = 0f;
        _uiManager._moonModel.transform.rotation = roat;

        _uiManager.OffAllModel();
        _uiManager._moonModel.SetActive(true);

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
