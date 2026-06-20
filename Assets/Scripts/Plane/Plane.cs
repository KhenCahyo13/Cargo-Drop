using UnityEngine;
using UnityEngine.InputSystem;

public class Plane : MonoBehaviour
{
    private Rigidbody2D planeRigidbody2D;

    private void Awake()
    {
        planeRigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float moveSpeed = 10f;

        if (Keyboard.current.upArrowKey.isPressed)
        {
            float force = 500f;
            planeRigidbody2D.AddForce(force * Time.deltaTime * transform.up);
        }

        if (Keyboard.current.leftArrowKey.isPressed)
        {
            planeRigidbody2D.AddForce(Vector2.left * moveSpeed);
        }

        if (Keyboard.current.rightArrowKey.isPressed)
        {
            planeRigidbody2D.AddForce(Vector2.right * moveSpeed);
        }
    }
}
