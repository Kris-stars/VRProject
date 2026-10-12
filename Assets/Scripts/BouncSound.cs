using UnityEngine;

public class BouncSound : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip impact;
    Rigidbody rb;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        float speed = rb.linearVelocity.magnitude;
        

        audioSource.PlayOneShot(impact, speed);
    }
}
