using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityVehicle : MonoBehaviour,IDamageable
{
    public int health;
    public void TakeDamage()
    {
        health--;
        if (health<=0)
        {
            Debug.Log("" + gameObject.name + " security vehicle destroyed.");
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
