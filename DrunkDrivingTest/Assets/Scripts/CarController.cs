﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {

    Rigidbody2D rb_car;
    private float turnSpeed;
    public float _Velocity; //Current speed
    private float _MaxVelocity; //Max speed
    private float _MaxReverse; //Max reverse speed
    public float mag;
    public Animator animator;

    private float direction() {
        return Mathf.Sign(transform.InverseTransformDirection(rb_car.velocity).y); //1 if pos or zero, -1 if neg.
    }

    // Use this for initialization
    void Start() {
        rb_car = GetComponent<Rigidbody2D>();
        turnSpeed = .25f;
        _Velocity = 0.0f; //Current speed
        _MaxVelocity = 4f; //Max speed
        _MaxReverse = -1.5f; //Max reverse speed

        GetComponent<Rigidbody2D>().drag = 1;
        GetComponent<Rigidbody2D>().mass = 5;
        GetComponent<Rigidbody2D>().angularDrag = 1000;
}

    // Update is called once per frame
    void Update () {
        Debug.Log("In Update");
        mag = rb_car.velocity.magnitude;
        animator.SetFloat("Speed", mag);    //Allows animate when moving

        _Velocity = Input.GetAxis("Vertical") * _MaxVelocity; //Forward & Backward

        if (Input.GetKey(KeyCode.A)) {    //Turn left
            transform.Rotate(Vector3.forward, turnSpeed * _Velocity);
            rb_car.velocity = transform.up * mag * direction(); //Prevents drifting
        }
        if (Input.GetKey(KeyCode.D)) {   //Turn right
            transform.Rotate(Vector3.forward, -turnSpeed * _Velocity);
            rb_car.velocity = transform.up * mag * direction(); //Prevents drifting
    }
        if (Input.GetKeyDown(KeyCode.Space)) { //Brakes
            _MaxVelocity = 0;
            GetComponent<Rigidbody2D>().drag = 5;
        }
        if (Input.GetKeyUp(KeyCode.Space)) {
            _MaxVelocity = 3.5f;
            GetComponent<Rigidbody2D>().drag = 1;
        }

        rb_car.AddRelativeForce(Vector2.up * _Velocity);

        if (_Velocity < _MaxReverse)
            _Velocity = _MaxReverse;
    }
}
