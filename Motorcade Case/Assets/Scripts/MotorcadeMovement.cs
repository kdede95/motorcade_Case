using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorcadeMovement : MonoBehaviour
{

    [SerializeField] bool isLocked = false;

    bool pressedA = false;
    bool pressedD = false;


    [SerializeField] float forwardMovementSpeed = 50f;
    [SerializeField] float horizontalMovement;
    [SerializeField] float horizontalLimit;
    [SerializeField] Vector3 newPos;

    [SerializeField] float slidingSpeed;

    void Update()
    {
        Movement();
       
    }

    void Movement()
    {

        if (isLocked)
        {
            return;
        }
        if ((Input.GetAxis("Horizontal")<0||pressedA) && !pressedD)
        {
            if (!pressedA)
            {
                newPos = new Vector3(transform.position.x - horizontalMovement, transform.position.y, transform.position.z);
            }
            if (transform.position.x >= newPos.x && newPos.x > -horizontalLimit)
            {

                pressedA = true;
                transform.Translate(Vector3.left * slidingSpeed * Time.deltaTime);
            }
            if (transform.position.x - newPos.x < 0.1f)
            {

                transform.position = new Vector3(newPos.x, transform.position.y, transform.position.z);
                pressedA = false;
            }
        }
        else if ((Input.GetAxis("Horizontal") > 0 || pressedD) && !pressedA )
        {
            if (!pressedD)
            {
                newPos = new Vector3(transform.position.x + horizontalMovement, transform.position.y, transform.position.z);
            }
            if (transform.position.x <= newPos.x && newPos.x < horizontalLimit)
            {

                pressedD = true;
                transform.Translate(Vector3.right * slidingSpeed * Time.deltaTime);
            }
            if (newPos.x - transform.position.x < 0.1f)
            {

                transform.position = new Vector3(newPos.x, transform.position.y, transform.position.z);
                pressedD = false;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z + 1f), Time.deltaTime * forwardMovementSpeed);

    }
}

    

