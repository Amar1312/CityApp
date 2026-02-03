using UnityEngine;

public class LightMove : MonoBehaviour
{
    [Header("Movement Points")]
    public Transform startPoint;
    public Transform endPoint;

    [Header("Movement Settings")]
    public float speed = 2f;

    void Start()
    {
        // Ensure object starts at the first position
        //transform.position = startPoint.position;
    }

    void Update()
    {
        // Move from start to end
        transform.position = Vector3.MoveTowards(
            transform.position,
            endPoint.position,
            speed * Time.deltaTime
        );

        // If reached the end point, teleport back to start
        if (Vector3.Distance(transform.position, endPoint.position) < 0.01f)
        {
            transform.position = startPoint.position;
        }
    }
}
