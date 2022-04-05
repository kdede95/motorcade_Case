using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorcadeMovement : MonoBehaviour
{

    public float forwardMovementSpeed = 50f;
    public float horizontalMovement;
    public float horizontalLimit;
    public Vector3 newPos;

    public float slidingSpeed;

    // Start is called before the first frame update
    void Start()
    {
       // StartCoroutine(FollowPath());
    }

    // Update is called once per frame
    void Update()
    {
        //if (transform.position.x >= newPos.x)
        //{

        //    transform.Translate(Vector3.left*slidingSpeed*Time.deltaTime);
        //}
        //ConstantMovement();
        // Movement();
        // Vector3 newPos = new Vector3(transform.position.x - horizontalMovement, transform.position.y, transform.position.z);
        // transform.position = Vector3.Lerp(transform.position, newPos, slidingSpeed / Time.deltaTime);

        // var from = transform.position;

        //// var newPosition = Vector3.MoveTowards(from, newPos, Time.deltaTime * slidingSpeed);
        // transform.position = newPosition;
        // if (Vector3.Distance(transform.position, newPos) < 0.15f)
        // {
        //     // Swap the position of the cylinder.
        //     transform.position=newPos;
        // }
        Movement();
       
    }
   public bool isLocked=false;
    public float laneChangeDuration;

    void ConstantMovement()
    {
        if (!isLocked)
        {
            transform.Translate(transform.position.x, transform.position.y, forwardMovementSpeed * Time.deltaTime);
        }
        
    }
    public bool pressedA = false;
    public bool pressedD = false;
    void Movement()
    {

        if (isLocked)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.A)||pressedA && !pressedD)
        {
            if (!pressedA)
            {
                newPos = new Vector3(transform.position.x - horizontalMovement, transform.position.y, transform.position.z);
            }
            if (transform.position.x >= newPos.x && newPos.x > -horizontalLimit)
            {

                pressedA = true;
                transform.Translate(Vector3.left * slidingSpeed * Time.deltaTime);
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z + 1f), Time.deltaTime * forwardMovementSpeed);
            }
            if (transform.position.x - newPos.x < 0.2f)
            {

                transform.position = new Vector3(newPos.x, transform.position.y, transform.position.z);
                pressedA = false;
            }
        }
        else if (Input.GetKeyDown(KeyCode.D)||pressedD && !pressedA )
        {
            if (!pressedD)
            {
                newPos = new Vector3(transform.position.x + horizontalMovement, transform.position.y, transform.position.z);
            }
            if (transform.position.x <= newPos.x && newPos.x < horizontalLimit)
            {

                pressedD = true;
                transform.Translate(Vector3.right * slidingSpeed * Time.deltaTime);
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z + 1f), Time.deltaTime * forwardMovementSpeed);
            }
            if (newPos.x - transform.position.x < 0.2f)
            {

                transform.position = new Vector3(newPos.x, transform.position.y, transform.position.z);
                pressedD = false;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z + 1f), Time.deltaTime * forwardMovementSpeed);
        }

    }
}

    

