using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeFollow : MonoBehaviour
{

    public bool continuecheck;
    public TrackingManager _trackingManager;

    private void OnEnable()
    {
        if (!continuecheck)
        {
            this.transform.position = new Vector3(Camera.main.transform.position.x,
        this.transform.position.y,
        Camera.main.transform.position.z);

            var Lookat = Quaternion.LookRotation(Camera.main.transform.forward);
            Lookat.x = 0;
            Lookat.z = 0;
            this.transform.rotation = Lookat;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        if (_trackingManager != null)
        {
            Invoke(nameof(onTracking), 2f);
        }
    
    }

    void onTracking()
    {
        _trackingManager.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetRobotPos()
    {
        this.transform.position = new Vector3(Camera.main.transform.position.x,
this.transform.position.y,
Camera.main.transform.position.z);

        var Lookat = Quaternion.LookRotation(Camera.main.transform.forward);
        Lookat.x = 0;
        Lookat.z = 0;
        this.transform.rotation = Lookat;
        Debug.Log("this rotation 12");
    }
}
