using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideColum : MonoBehaviour
{
    private SphereFollow _sperefollw;
    public Transform _robotPoint;
    // Start is called before the first frame update
    void Start()
    {
        _sperefollw = UiManager.Instance._sphereFollow;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("MainCamera"))
        {
            UiManager.Instance._sphereFollow.NearpointSet(_robotPoint.position);
        }
    }
}
