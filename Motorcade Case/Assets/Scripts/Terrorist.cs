using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terrorist : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] ParticleSystem projectileParticles;
    [SerializeField] float range = 15f;
    [SerializeField] Transform target;
    [SerializeField] Limousine limo;
    private void Start()
    {
        FindTheLimousine();
    }

    void Update()
    {
        AimWeapon();
    }

    private void FindTheLimousine()
    {
        limo = FindObjectOfType<Limousine>();
        if (limo!=null)
        {
            target = limo.transform;
        }
       
    }

    private void AimWeapon()
    {

        if (target!=null)
        {

            float targetDistance = Vector3.Distance(transform.position, target.position);

            transform.LookAt(target);

            if (targetDistance < range && limo.isActiveAndEnabled)
            {
                Attack(true);
            }
            else
            {
                Attack(false);
            }
        }
    }

    void Attack(bool isActive)
    {

        var emissionModule = projectileParticles.emission;
        emissionModule.enabled = isActive;

    }

}
