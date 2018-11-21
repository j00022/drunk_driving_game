using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    public float turnSpeed = 60f;
    public float _Velocity = 0.0f; //Current speed
    public float _MaxVelocity = 1.5f; //Max speed
    public float _MaxReverse = -0.75f; //Max reverse speed
    public float _Accelerate = 0.01f; //Accelerate more
    public float _Decelerate = -0.005f; //Decrease speed and reverse
    public float _Friction = 0.0001f;

	// Update is called once per frame
	void Update () {
        Debug.Log("In Update");
        if (Input.GetKey(KeyCode.W))    //Accelerate
            _Velocity += _Accelerate;
        else if (Input.GetKey(KeyCode.S))    //Decelerate
            _Velocity += _Decelerate;
        else {                           //Naturally return to 0 if no input
            while (_Velocity < 0) {
                _Velocity += _Friction;
                if (_Velocity > 0)
                    _Velocity = 0;
            }
            while (_Velocity > 0) {
                _Velocity -= _Friction;
                if (_Velocity < 0)
                    _Velocity = 0;
            }
        }
        if (Input.GetKey(KeyCode.A))    //Turn left
            transform.Rotate(Vector3.forward, turnSpeed * _Velocity * Time.deltaTime);
        if (Input.GetKey(KeyCode.D))    //Turn right
            transform.Rotate(Vector3.forward, -turnSpeed * _Velocity * Time.deltaTime);

        if (_Velocity > _MaxVelocity) //Speed limits
            _Velocity = _MaxVelocity;
        else if (_Velocity < _MaxReverse)
            _Velocity = _MaxReverse;

        transform.Translate(Vector3.up * _Velocity * Time.deltaTime); //Move the car
    }
}
