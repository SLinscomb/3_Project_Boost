using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{

    [SerializeField] float rcsThrust = 10000f;
    [SerializeField] float mainThrust = 1f;

    Rigidbody rigidBody;
    AudioSource audioSource;



	// Use this for initialization
	void Start ()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

	}
	
	// Update is called once per frame
	void Update ()
    {
        Thrust();
        Rotate();
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                // do nothing
                break;
            case "Fuel":
                break;
            default:
                //kill player
                break;
        }
    }

    private void Thrust()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rigidBody.AddRelativeForce(Vector3.up * mainThrust);
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }

            else
            {
                audioSource.Stop();
            }


        }
    }

    private void Rotate()
    {
        rigidBody.freezeRotation = true;

        float rotationThisFrame = rcsThrust * Time.deltaTime;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.forward * rotationThisFrame);

        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(-Vector3.forward);
        }

        rigidBody.freezeRotation = false;

    }


}
