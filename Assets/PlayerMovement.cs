using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Vector3 velocity = new Vector3(100f, 400f, 100f);
    public Rigidbody rb;
    public Transform camera;
    private float yaw = 0.0f;
    private float pitch = 0.0f;
    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private bool spacePressed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
            rb.AddForce(-velocity.x * Time.deltaTime, 0, 0);
        if (Input.GetKey(KeyCode.D))
            rb.AddForce(velocity.x * Time.deltaTime, 0, 0);
        if (Input.GetKey(KeyCode.W))
            rb.AddForce(0, 0, velocity.z * Time.deltaTime);
        if (Input.GetKey(KeyCode.S))
            rb.AddForce(0, 0, -velocity.z * Time.deltaTime);

        if (Input.GetKeyUp(KeyCode.Space))
            spacePressed = false;

        if (Input.GetKeyDown(KeyCode.Space) && !spacePressed)
        {
            rb.AddForce(0, velocity.y * Time.deltaTime, 0);
            spacePressed = true;
        }

        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0) * Time.deltaTime * speedH);
    }
}
