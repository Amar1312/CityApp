using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PasteGroup : MonoBehaviour
{
    public int _counter;
    public Material[] _allmaterial;
    public Material[] _allBackgroundMaterial;

    [SerializeField] MeshRenderer _backGroundQuad;
    [SerializeField] internal Transform _spawnPoint;
    [SerializeField] GameObject _spawnObj;

    public Vector3 _pos1, _pos2;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnDisable()
    {
        ResetAll();
    }


    public Material SetMaterial()
    {
        _counter++;
        if (_counter < _allmaterial.Length)
        {
            _backGroundQuad.material = _allBackgroundMaterial[_counter];
            return _allmaterial[_counter];
        }
        else
        {
            _counter = 0;
            _backGroundQuad.material = _allBackgroundMaterial[_counter];
            return _allmaterial[_counter];
        }


    }


    void ResetAll()
    {
        _counter = 0;
        _backGroundQuad.material = _allBackgroundMaterial[0];

        GameObject past = Instantiate(_spawnObj, _spawnPoint.position, _spawnPoint.rotation, transform);
        past.name = "0";
        if (past.TryGetComponent(out MarvisPaste marvisPaste))
        {
            marvisPaste._pos1 = _pos1;
            marvisPaste._pos2 = _pos2;
        }
        //past.transform.SetSiblingIndex(1);

        for (int i = transform.childCount - 1; i > 1; i--)
        {
            if (transform.GetChild(i).name != "0")
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }
    }
}
