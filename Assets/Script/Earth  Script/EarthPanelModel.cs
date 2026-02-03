using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class EarthPanelModel : MonoBehaviour
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
