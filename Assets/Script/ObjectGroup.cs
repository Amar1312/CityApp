using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGroup : MonoBehaviour
{
    bool _completeOnce;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnEnable()
    {
        if (_completeOnce)
        {
            //UiManager.Instance.SetParentObj();
        }
        _completeOnce = true;
    }
}
