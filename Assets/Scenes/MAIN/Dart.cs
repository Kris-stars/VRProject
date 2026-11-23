using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Dart : MonoBehaviour
{
    [Header("Shockwave")]
    public float explosionRadius = 4f;
    public float explosionForce = 60f;
    public LayerMask affectedLayers;
    
    [Header("Impact Sound")]
    public AudioClip impactSound;
    [Range(0f, 1f)] public float soundVolume = 0.6f;

    [Header("Explosion Sphere")]
    public Material sphereMaterial;
    public Color sphereColor;
    public float sphereStartSize = 0.1f;
    public float sphereEndSize = 1f;
    public float sphereDuration = 0.25f;

    [Header("Optional")]
    public bool explodeOnTriggers = false;

    private Rigidbody dartRb;
    private bool exploded;

    void Awake()
    {
        dartRb = GetComponent<Rigidbody>();
        dartRb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (exploded) return;

        Vector3 hitPoint = collision.contactCount > 0
            ? collision.GetContact(0).point
            : transform.position;

        Explode(hitPoint);
    }

    void OnTriggerEnter(Collider other)
    {
        if (!explodeOnTriggers || exploded) return;
        Explode(transform.position);
    }

    void Explode(Vector3 position)
    {
        exploded = true;

        // Sound keeps playing after the dart is removed.
        
            AudioSource.PlayClipAtPoint(impactSound, position, soundVolume);

        // Push each nearby Rigidbody only once, even if it has many colliders.
        Collider[] nearby = Physics.OverlapSphere(
            position, explosionRadius, affectedLayers, QueryTriggerInteraction.Ignore);

        HashSet<Rigidbody> pushed = new HashSet<Rigidbody>();
        foreach (Collider hit in nearby)
        {
            Rigidbody target = hit.attachedRigidbody;
            if (target == null || target == dartRb || target.isKinematic || !pushed.Add(target))
                continue;

            target.AddExplosionForce(
                explosionForce, position, explosionRadius, 0f, ForceMode.Impulse);
        }

        // Stop and hide the dart while the visual effect finishes.
        dartRb.linearVelocity = Vector3.zero;
        dartRb.angularVelocity = Vector3.zero;
        dartRb.isKinematic = true;
        dartRb.detectCollisions = false;

        StartCoroutine(ShowExplosionSphere(position));
    }

    IEnumerator ShowExplosionSphere(Vector3 position)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.name = "Dart Shockwave";
        sphere.transform.position = position;

        // Apply the material to the sphere
        Renderer sphereRenderer = sphere.GetComponent<Renderer>();
        sphereRenderer.material = sphereMaterial;

        // Visual only: no collider
        Collider sphereCollider = sphere.GetComponent<Collider>();
        sphereCollider.enabled = false;
        Destroy(sphereCollider);





        float time = 0f;
        float duration = Mathf.Max(0.01f, sphereDuration);
        while (time < duration)
        {
            time += Time.deltaTime;
            float t = Mathf.Clamp01(time / duration);
            float diameter = Mathf.Lerp(sphereStartSize, sphereEndSize, t);
            sphere.transform.localScale = Vector3.one * diameter;
            yield return null;
        }

        Destroy(sphere);
        
            
        Destroy(gameObject);
    }
}
