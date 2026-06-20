using UnityEngine;
using UnityEngine.InputSystem;

public class Plane : MonoBehaviour
{
    [SerializeField] private GameObject packagePrefab;

    private Rigidbody2D planeRigidbody2D;
    private int remainingPackage;

    private void Awake()
    {
        remainingPackage = 5;
        planeRigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame && remainingPackage > 0)
        {
            DropPackage();
        }
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

    private void DropPackage()
    {
        Vector3 spawnPosition = transform.position + new Vector3(0, -1f, 0);
        GameObject newPackage = Instantiate(packagePrefab, spawnPosition, Quaternion.identity);

        Rigidbody2D packageRigidbody2D = newPackage.GetComponent<Rigidbody2D>();
        packageRigidbody2D.linearVelocity = planeRigidbody2D.linearVelocity;

        remainingPackage--;
    }
}
