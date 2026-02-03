using UnityEngine;

public class VideoPanelDummyPoint : MonoBehaviour
{

    public Transform _targetPoint;

    private UiManager _uiManager;
    public GameObject _effect;

    private void OnEnable()
    {
        if (!UiManager.Instance._videoPanelModel.activeInHierarchy)
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

        _uiManager._videoPanelModel.transform.position = _targetPoint.position;
        var roat = this.transform.rotation;
        roat.x = 0f;
        roat.z = 0f;
        //roat.y = -roat.y;
        _uiManager._videoPanelModel.transform.rotation = roat;

        _uiManager.OffAllModel();
        _uiManager._videoPanelModel.SetActive(true);

        _uiManager._videoPlayScan = true;
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
