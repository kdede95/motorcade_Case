using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Damageable : MonoBehaviour
{
    public int health;
    public void TakeDamage()
    {
        health--;
        if (health<=0)
        {
            Debug.Log("" + gameObject.name + " has been destroyed.");
            Destroy(gameObject);
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("Particle hit " + gameObject.name + ".");
       
        TakeDamage();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<Traffic>()!=null)
        {
            TakeDamage();
        }
    }
}
