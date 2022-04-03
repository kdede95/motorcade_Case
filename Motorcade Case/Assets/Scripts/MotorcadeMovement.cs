using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorcadeMovement : MonoBehaviour
{

    public float forwardMovementSpeed = 50f;
    public float horizontalMovement;
    public float horizontalLimit;


    public float slidingSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ConstantMovement();
        HorizontalMovement();
    }
   public bool isLocked=false;

    void ConstantMovement()
    {
        if (!isLocked)
        {
            transform.Translate(0f, 0f, forwardMovementSpeed * Time.deltaTime);
        }
        
    }
    void HorizontalMovement()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (transform.position.x > -horizontalLimit )
            {
                Vector3 newPos = new Vector3(transform.position.x - horizontalMovement, transform.position.y, transform.position.z);
                transform.position = Vector3.Lerp(transform.position, newPos, slidingSpeed / Time.deltaTime);
            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (transform.position.x < horizontalLimit)
            {
                Vector3 newPos = new Vector3(transform.position.x + horizontalMovement, transform.position.y, transform.position.z);
                transform.position = Vector3.Lerp(transform.position, newPos, slidingSpeed / Time.deltaTime);
            }
            
        }

    }
    
}
