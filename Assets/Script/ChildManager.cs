using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildManager : MonoBehaviour
{
    public static ChildManager Instance;

    public List<GameObject> _allChild = new List<GameObject>();


    private void Awake()
    {
        if (Instance != this && Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }



    public void DeactivateAllExcept(GameObject activeObject)
    {
        foreach (GameObject obj in _allChild)
        {
            if (obj != activeObject)
            {
                obj.SetActive(false);
            }
        }
    }
}
