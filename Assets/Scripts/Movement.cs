using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Movement : MonoBehaviour
{
    private Rigidbody rb;
    private AudioSource audioSource;
    [SerializeField] float ThrustSpeed = 1f;
    [SerializeField] float RotationSpeed = 1f;
    [SerializeField] AudioClip audioEngine;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space)) {
            rb.AddRelativeForce(0,ThrustSpeed*Time.deltaTime,0);
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(audioEngine);
            }
        }else
        {
            audioSource.Stop();
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 mov = Vector3.forward * RotationSpeed * Time.deltaTime;
            ApplyRotation(mov);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 mov = Vector3.back * RotationSpeed * Time.deltaTime;
            ApplyRotation(mov);
        }
    }

    void ApplyRotation(Vector3 mov)
    {
        rb.freezeRotation = true;
        transform.Rotate(mov);
        rb.freezeRotation = false;

    }
}
