using UnityEngine;

public class SolarLookCube : MonoBehaviour
{
    public GameObject _startBtn;
    public bool _onStart;

    private void OnEnable()
    {
        _startBtn.SetActive(false);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("MainCamera"))
        {
            if (_onStart)
            {
                _startBtn.SetActive(true);
            }
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("MainCamera"))
        {
            _startBtn.SetActive(false);
        }
    }
}
