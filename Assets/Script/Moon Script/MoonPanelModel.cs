using UnityEngine;

public class MoonPanelModel : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnDisable()
    {
        UiManager.Instance._sphereFollow.BackPosition();
    }
}
