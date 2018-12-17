using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoFollowPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 offsetThird = new Vector3(0, 1, -5);
    public float turnSpeed = 4.0f;
    public float FirstPersonTurnSpeed = 10.0f;

    public bool fp = true;

    private Vector3 offsetPlayer = new Vector3(0, 0, 0);
    private Vector3 offsetFirst = new Vector3(0, 0.4f, 0);


    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F11))
        {
            if (fp)
            {
                fp = false;
            }
            else
            {
                fp = true;
            }
        }
    }

    private void LateUpdate()
    {
        if (!fp)
        {
            offsetThird = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offsetThird;
            transform.position = player.position + offsetThird;
            transform.LookAt(player.position);
            player.Rotate(0, Input.GetAxis("Mouse X") * turnSpeed, 0);
        }
        else
        {
            transform.position = player.position + offsetFirst;
       
            transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0) * Time.deltaTime * FirstPersonTurnSpeed);
            //transform.rotation = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up);
            //player.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0) * Time.deltaTime * FirstPersonTurnSpeed);
            //player.rotation = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up);
            //player.Translate(transform.TransformDirection(offsetFirst));
        }
    }
}
