using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

    Rigidbody2D rb_car;

    float acceleration = 2.5f;
    float steering = 1f;
    float steeringAmt, velocity, direction;

    public void Start() {
        rb_car = GetComponent<Rigidbody2D>();
    }

    public void Update() {
        steeringAmt = -Input.GetAxis("Horizontal");
        velocity = Input.GetAxis("Vertical") * acceleration;
        direction = Mathf.Sign(Vector2.Dot(rb_car.velocity, rb_car.GetRelativeVector(Vector2.up)));
        rb_car.rotation += steeringAmt * steering * rb_car.velocity.magnitude * direction;

        if (Input.GetKeyDown(KeyCode.Space))
            GetComponent<Rigidbody2D>().drag = 20;
        if (Input.GetKeyUp(KeyCode.Space))
            GetComponent<Rigidbody2D>().drag = 2;

        rb_car.AddRelativeForce(Vector2.up * velocity);

        rb_car.AddRelativeForce(-Vector2.right * rb_car.velocity.magnitude * steeringAmt / 2);
    }
}
