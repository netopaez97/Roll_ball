using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : MonoBehaviour
{
    [SerializeField]
    public float bouncePower = 200;

    void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
        PlayerController pc = collision.gameObject.GetComponent<PlayerController>();

        //Vamos a hacer que rebote mediante el vector3 con su metodo reflect
        Vector3 bounce = Vector3.Reflect(pc.lastVelocity, collision.contacts[0].normal);

        //Se usa cuando no sepa que esta pasando. Es como un print en Dart breakpoint.
        //Debug.Log("Velocity: " + pc.lastVelocity);
        //Debug.Log("Bounce: " + bounce * bouncePower);

        rb.AddForce(bounce.normalized * bouncePower);
    }
}
