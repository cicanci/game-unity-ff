using UnityEngine;
using System.Collections;

namespace Playground
{
    public class TestDestroy : MonoBehaviour
    {
        void Start ()
        {
            Debug.LogWarning ("Playground::TestDestroy script is in use by " + gameObject.name);
        }

        //void OnCollisionEnter(Collision collision)
        //{
        //    Rigidbody piece = GetComponent<Rigidbody>();
        //    piece.AddForce(collision.impulse);
        //}
    }
}
