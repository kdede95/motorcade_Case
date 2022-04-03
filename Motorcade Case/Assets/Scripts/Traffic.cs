using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traffic : MonoBehaviour
{
    public float movementSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
        if (other.gameObject.GetComponent<IDamageable>() != null)
        {
            IDamageable dmg = other.gameObject.GetComponent<IDamageable>();
            Debug.Log("Security car hit!");
            dmg.TakeDamage();
            Destroy(this.gameObject);
        }
    }
}
