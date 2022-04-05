using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traffic : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    void Update()
    {
        ForwardMovement();
    }

    void ForwardMovement()
    {
        transform.Translate(0f, 0f, movementSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Hit " + other.gameObject.name);
        if (other.gameObject.GetComponent<Damageable>() != null)
        {
            Destroy(this.gameObject);
        }
    }
}
