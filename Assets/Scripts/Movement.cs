using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private AudioSource _audioSource;

    [SerializeField] private float forwardThrust = 1000f;

    [SerializeField] private float rotationThrust = 2f;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _rigidbody.AddRelativeForce(Vector3.up * (forwardThrust * Time.deltaTime));
            if (!_audioSource.isPlaying)
                _audioSource.Play();
        }
        else
        {
            _audioSource.Stop();
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
            ApplyRotation(rotationThrust);
        else if (Input.GetKey(KeyCode.D))
            ApplyRotation(-rotationThrust);
    }

    void ApplyRotation(float rotationThisFrame)
    {
        _rigidbody.freezeRotation = true;
        transform.Rotate(Vector3.forward * (rotationThisFrame * Time.deltaTime));
        _rigidbody.freezeRotation = false;
    }
}
