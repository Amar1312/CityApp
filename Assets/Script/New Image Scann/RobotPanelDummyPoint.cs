using UnityEngine;

public class RobotPanelDummyPoint : MonoBehaviour
{
    public Transform _targetPoint;

    private UiManager _uiManager;
    public GameObject _effect;

    private void OnEnable()
    {
        if (!UiManager.Instance._robotPanelModel.activeInHierarchy)
        {
            SetVideoPanelPoint();
        }
        onEffect();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void SetVideoPanelPoint()
    {
        _uiManager = UiManager.Instance;

        _uiManager._robotPanelModel.transform.position = _targetPoint.position;
        var roat = this.transform.rotation;
        roat.x = 0f;
        roat.z = 0f;
        //roat.y = -roat.y;
        _uiManager._robotPanelModel.transform.rotation = roat;

        _uiManager.OffAllModel();
        _uiManager._robotPanelModel.SetActive(true);

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
