using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarvisPasteFish : MonoBehaviour
{
    [SerializeField] MeshRenderer _tube, _cap;
    [SerializeField] Material[] _mtube, _mcap;

    // Start is called before the first frame update
    void Start()
    {
        Setmaterial();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Setmaterial()
    {
        int n = Random.Range(0, _mtube.Length);

        _tube.material = _mtube[n];
        _cap.material = _mcap[n];
    }
}
