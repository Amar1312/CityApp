using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MarvisPaste : MonoBehaviour
{
    public Vector3 /*_defaultScale,*/ _pos1, _pos2;
    [SerializeField] Vector3 _scale, _minScale;
    //[SerializeField] GameObject _mesh;
    [SerializeField] GameObject _spawnobj;
    public MeshRenderer _tubeMesh;
    public PasteGroup _pasteGroup;

    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnEnable()
    {
        _pasteGroup = transform.parent.GetComponent<PasteGroup>();
        ScaleAndSpawn();
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(SpawnPaste));
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ScaleAndSpawn()
    {
        Invoke(nameof(SpawnPaste), 1.325f);

        //transform.DOScale(new Vector3(0.25f, 0.25f, 0.25f), 1f)
        transform.DOScale(_scale, 1f)
            .SetEase(Ease.Linear).SetDelay(0.5f);
        //.OnComplete(() => StartCoroutine(IenumPasteOff()));

        transform.DOLocalMove(_pos1, 1f).SetEase(Ease.Linear);

        transform.DOLocalMove(_pos2, 1f).SetEase(Ease.Linear).SetDelay(1f).OnComplete(PasteOff);

    }


    void SpawnPaste()
    {
        //GameObject _paste = Instantiate(_spawnobj, transform.position, _spawnobj.transform.rotation, _pasteGroup.transform);
        GameObject _paste = Instantiate(_spawnobj, _pasteGroup._spawnPoint.position, _spawnobj.transform.rotation, _pasteGroup.transform);
        _paste.name = "MarvisPaste";
        //_paste.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
        //_paste.transform.localScale = new Vector3(0.065f, 0.065f, 0.065f);
        _paste.transform.localScale = _minScale;

        if (_paste.TryGetComponent(out MarvisPaste marvisPaste))
        {
            marvisPaste._pos1 = _pasteGroup._pos1;
            marvisPaste._pos2 = _pasteGroup._pos2;
            marvisPaste._tubeMesh.material = _pasteGroup.SetMaterial();
        }
    }

    void PasteOff()
    {
        gameObject.SetActive(false);
        Destroy(gameObject, 2);
    }



}
