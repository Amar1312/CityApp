using UnityEngine;

public class ButterflyMovement : MonoBehaviour
{
    [Header("Waypoints")]
    public Transform waypointA;
    public Transform waypointB;

    [Header("Movement")]
    public float speed = 1.5f;
    public float rotationSpeed = 0.5f;

    [Header("Flutter Effect")]
    public float flutterAmplitude = 0.3f;
    public float flutterFrequency = 2f;

    private Vector3 startPos;
    private Vector3 endPos;
    private float time;


    void Start()
    {
        startPos = waypointA.position;
        endPos = waypointB.position;
    }

    void Update()
    {

        startPos = waypointA.position;
        endPos = waypointB.position;

        // Calculate ping-pong movement
        time += Time.deltaTime * speed;
        float t = Mathf.PingPong(time, 1f);

        Vector3 basePosition = Vector3.Lerp(startPos, endPos, t);

        // Flutter motion
        float flutter = Mathf.Sin(Time.time * flutterFrequency) * flutterAmplitude;
        Vector3 targetPosition = basePosition + Vector3.up * flutter;

        // Move
        Vector3 direction = (targetPosition - transform.position).normalized;
        transform.position = targetPosition;

        // Rotate toward movement direction
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                rotationSpeed * Time.deltaTime
            );
        }
    }
}

