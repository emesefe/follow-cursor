using UnityEngine;
using UnityEngine.InputSystem;

public class FollowCursor : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Camera camera;
    
    [Header("Settings")]
    [SerializeField, Min(0f)] private float followSpeed = 5f;

    private Vector2 mousePosition;

    private void Awake()
    {
        if (camera == null)
        {
            camera = Camera.main;
        }
    }

    private void Update()
    {
        if (Mouse.current == null || camera == null) return;

        mousePosition = Mouse.current.position.ReadValue();

        float depth = transform.position.z - camera.transform.position.z;

        Vector3 screenPosition = new Vector3(mousePosition.x, mousePosition.y, depth);

        Vector3 targetPosition = camera.ScreenToWorldPoint(screenPosition);

        targetPosition.z = transform.position.z;

        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPosition,
            followSpeed * Time.deltaTime
        );
    }
}