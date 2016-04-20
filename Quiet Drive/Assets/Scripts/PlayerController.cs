using UnityEngine;
using System.Collections.Generic;


public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float engineForce = 10;
    private float turnForce = 5;

    void Start()
    {

    }

    private Vector3 inputToForce()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        return new Vector3();
    }

    public float speed;
    public float tilt;
    public Boundary boundary;

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rigidbody.velocity = movement * speed;

        rigidbody.position = new Vector3
        (
            Mathf.Clamp(rigidbody.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rigidbody.position.z, boundary.zMin, boundary.zMax)
        );

        rigidbody.rotation = Quaternion.Euler(0.0f, 0.0f, rigidbody.velocity.x * -tilt);
    }

void Update()
    {

    }
}
