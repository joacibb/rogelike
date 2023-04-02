using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed;
    public Vector3 offset;

    public PlayerController player;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    void LateUpdate()
    {
        transform.position =
            new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPos;
    }
}