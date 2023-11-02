using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonBall : MonoBehaviour
{
    //variables

    private Rigidbody rb;
    public float upForce = 10f;
    public float forwardForce = 10f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.up * upForce + Vector3.forward * forwardForce, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
