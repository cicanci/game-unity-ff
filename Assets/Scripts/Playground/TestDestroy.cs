using UnityEngine;
using System.Collections;

public class TestDestroy : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        Rigidbody piece = GetComponent<Rigidbody>();
        piece.AddForce(collision.impulse);
    }
}
