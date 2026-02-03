using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JustRotate : MonoBehaviour
{

    public float rotateSpeed;

    void Update()
    {
        transform.Rotate(rotateSpeed * Vector3.forward * Time.deltaTime);
    }
}
