using UnityEngine;

public class EarthMove : MonoBehaviour
{
    public Vector3 rotationSpeed = new Vector3(0f, 50f, 0f);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating(nameof(RotateEarth), 2f, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RotateEarth()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
