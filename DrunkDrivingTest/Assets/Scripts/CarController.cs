using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {

    Rigidbody2D rb_car;
    public float turnSpeed = .45f;
    public float _Velocity = 0.0f; //Current speed
    public float _MaxVelocity = 2.75f; //Max speed
    public float _MaxReverse = -1.5f; //Max reverse speed
    public Animator animator;

    // Use this for initialization
    void Start() {
        rb_car = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update () {
        Debug.Log("In Update");
        _Velocity = Input.GetAxis("Vertical") * _MaxVelocity;
        animator.SetFloat("Speed", _Velocity);

        if (Input.GetKey(KeyCode.A))    //Turn left
            transform.Rotate(Vector3.forward, turnSpeed * _Velocity);
        if (Input.GetKey(KeyCode.D))    //Turn right
            transform.Rotate(Vector3.forward, -turnSpeed * _Velocity);

        if (Input.GetKeyDown(KeyCode.Space)) {
            _MaxVelocity = 0;
            GetComponent<Rigidbody2D>().drag = 5;
        }
        if (Input.GetKeyUp(KeyCode.Space)) {
            _MaxVelocity = 2.75f;
            GetComponent<Rigidbody2D>().drag = 3;
        }

        rb_car.AddRelativeForce(Vector2.up * _Velocity);

        if (_Velocity < _MaxReverse)
            _Velocity = _MaxReverse;
    }
}
