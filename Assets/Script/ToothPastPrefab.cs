using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToothPastPrefab : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.activeInHierarchy)
        {
            Invoke(nameof(Object), 3f);
        }
    }

    void Object()
    {
        Destroy(gameObject);
    }
}
