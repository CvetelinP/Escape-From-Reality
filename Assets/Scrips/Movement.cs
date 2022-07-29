using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float speed = 100f;
    [SerializeField] float rotationSpeed = 1f;
    AudioSource _audioSource;
    [SerializeField] AudioClip clip;
    [SerializeField] ParticleSystem flame;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        ProcessingRotation();
        ProcessingUp();
    }

    public void ProcessingUp()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * speed * Time.deltaTime);

            if (!flame.isPlaying)
            {
                flame.Play();
            } 

            if (!_audioSource.isPlaying)
            {
                _audioSource.PlayOneShot(clip);
            }

        }
        else
        {
            _audioSource.Stop();
            flame.Stop();
        }
    }

    public void ProcessingRotation()
    {

        if (Input.GetKey(KeyCode.A))
        {
            rb.freezeRotation = true;
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
            rb.freezeRotation = false;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.freezeRotation = true;
            transform.Rotate(-Vector3.forward * rotationSpeed * Time.deltaTime);
            rb.freezeRotation = false;
        }

    }
}
