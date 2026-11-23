
//using UnityEngine;
//using UnityEngine.XR.Interaction.Toolkit.Locomotion.Climbing;

//public class MovementGravity : MonoBehaviour
//{
//    [Header("References")]
//    public ClimbProvider climbProvider;
//    public CharacterController controller;
//    public Transform vrCamera;

//    [Header("Space Movement")]
//    public float pushMultiplier = 1.5f;
//    public float maxSpeed = 5f;
//    public float smoothing = 15f;

//    private Vector3 velocity;
//    private Vector3 lastPosition;
//    private bool wasClimbing;

//    [Header("Wall Collision")]
//    [Range(0f, 1f)]
//    public float bounceAmount = 0.5f;

//    [Range(0f, 1f)]
//    public float slideFriction = 0.1f;


//    [Header("Force Field")]
//    public Transform forceFieldCenter;
//    public float forceFieldRadius = 20f;
//    public float pullStrength = 3f;
//    public float maxPullSpeed = 8f;

//    void Start()
//    {
//        lastPosition = transform.position;
//    }

//    void Update()
//    {
//        if (climbProvider == null || controller == null)
//            return;

//        float dt = Time.deltaTime;

//        if (dt <= 0f)
//            return;

//        // Keep the CharacterController aligned with the headset.
//        if (vrCamera != null)
//        {
//            Vector3 head =
//                transform.InverseTransformPoint(vrCamera.position);

//            float height = Mathf.Clamp(head.y, 0.5f, 2.2f);

//            controller.height = height;

//            controller.center = new Vector3(
//                head.x,
//                height / 2f,
//                head.z
//            );
//        }

//        // Check if the player is currently climbing.
//        bool isClimbing =
//            climbProvider.climbAnchorInteractor != null;

//        if (isClimbing)
//        {
//            if (!wasClimbing)
//            {
//                // Stop old velocity when grabbing a wall.
//                velocity = Vector3.zero;
//            }
//            else
//            {
//                // Calculate the movement created by climbing.
//                Vector3 movement =
//                    transform.position - lastPosition;

//                Vector3 targetVelocity = movement / dt;

//                float blend =
//                    1f - Mathf.Exp(-smoothing * dt);

//                velocity = Vector3.Lerp(
//                    velocity,
//                    targetVelocity,
//                    blend
//                );
//            }
//        }
//        else
//        {
//            // Player has released the wall.
//            if (wasClimbing)
//            {
//                velocity *= pushMultiplier;

//                velocity = Vector3.ClampMagnitude(
//                    velocity,
//                    maxSpeed
//                );
//            }

//            // Apply force when outside the safe area.
//            ApplyForceField(dt);

//            // Continue floating with the current velocity.
//            Vector3 movement = velocity * dt;

//            if (movement.sqrMagnitude > 0.00000001f)
//            {
//                controller.Move(movement);
//            }
//        }

//        wasClimbing = isClimbing;
//        lastPosition = transform.position;
//    }

//    // Called when the CharacterController hits a collider.
//    void OnControllerColliderHit(ControllerColliderHit hit)
//    {
//        // Do not change velocity during climbing.
//        if (climbProvider != null &&
//            climbProvider.climbAnchorInteractor != null)
//            return;

//        Vector3 normal = hit.normal.normalized;

//        // Find how quickly we are moving into the wall.
//        float speedIntoWall =
//            Vector3.Dot(velocity, normal);

//        if (speedIntoWall >= -0.01f)
//            return;

//        // Keep movement parallel to the wall.
//        Vector3 slideVelocity =
//            Vector3.ProjectOnPlane(velocity, normal);

//        slideVelocity *= (1f - slideFriction);

//        // Bounce away from the wall.
//        Vector3 bounceVelocity =
//            -normal * speedIntoWall * bounceAmount;

//        // Combine sliding and bouncing.
//        velocity = slideVelocity + bounceVelocity;
//    }

//    void ApplyForceField(float dt)
//    {
//        if (forceFieldCenter == null)
//            return;

//        // Use the headset for player distance when available.
//        Vector3 playerPosition =
//            vrCamera != null
//            ? vrCamera.position
//            : transform.position;

//        Vector3 direction =
//            forceFieldCenter.position - playerPosition;

//        float distance = direction.magnitude;

//        // No pull inside the safe area.
//        if (distance <= forceFieldRadius)
//            return;

//        Vector3 pullDirection = direction.normalized;

//        // Accelerate the player back towards the centre.
//        velocity += pullDirection * pullStrength * dt;

//        velocity = Vector3.ClampMagnitude(
//            velocity,
//            maxPullSpeed
//        );

//    }

//    void OnDrawGizmosSelected()
//    {
//        if (forceFieldCenter == null)
//            return;

//        Gizmos.color = Color.cyan;

//        Gizmos.DrawWireSphere(
//            forceFieldCenter.position,
//            forceFieldRadius
//        );
//    }
//}

using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Locomotion.Climbing;

public class MovementGravity : MonoBehaviour
{
    [Header("References")]
    public ClimbProvider climbProvider;
    public CharacterController controller;
    public Transform vrCamera;

    [Header("Space Movement")]
    public float pushMultiplier = 1.5f;
    public float maxSpeed = 5f;
    public float smoothing = 15f;

    private Vector3 velocity;
    private Vector3 lastPosition;
    private bool wasClimbing;

    [Header("Player Gravity (UI Button)")]
    public bool playerGravityEnabled = false;
    public float gravityAcceleration = 9.81f;
    public float groundStickSpeed = 0.5f;

    // Add this function as a SECOND action in your existing button's On Click().
    public void TogglePlayerGravity()
    {
        playerGravityEnabled = !playerGravityEnabled;

        // Stop old drift when switching between floating and falling.
        velocity = Vector3.zero;
        Debug.Log("Player gravity: " + (playerGravityEnabled ? "ON" : "OFF"));
    }

    [Header("Wall Collision")]
    [Range(0f, 1f)]
    public float bounceAmount = 0.5f;

    [Range(0f, 1f)]
    public float slideFriction = 0.1f;


    [Header("Force Field")]
    public Transform forceFieldCenter;
    public float forceFieldRadius = 20f;
    public float pullStrength = 3f;
    public float maxPullSpeed = 8f;

    void Start()
    {
        lastPosition = transform.position;
    }

    void Update()
    {
        if (climbProvider == null || controller == null)
            return;

        float dt = Time.deltaTime;

        if (dt <= 0f)
            return;

        // Keep the CharacterController aligned with the headset.
        if (vrCamera != null)
        {
            Vector3 head =
                transform.InverseTransformPoint(vrCamera.position);

            float height = Mathf.Clamp(head.y, 0.5f, 2.2f);

            controller.height = height;

            controller.center = new Vector3(
                head.x,
                height / 2f,
                head.z
            );
        }

        // Check if the player is currently climbing.
        bool isClimbing =
            climbProvider.climbAnchorInteractor != null;

        if (isClimbing)
        {
            if (!wasClimbing)
            {
                // Stop old velocity when grabbing a wall.
                velocity = Vector3.zero;
            }
            else
            {
                // Calculate the movement created by climbing.
                Vector3 movement =
                    transform.position - lastPosition;

                Vector3 targetVelocity = movement / dt;

                float blend =
                    1f - Mathf.Exp(-smoothing * dt);

                velocity = Vector3.Lerp(
                    velocity,
                    targetVelocity,
                    blend
                );
            }
        }
        else
        {
            // Player has released the wall.
            if (wasClimbing)
            {
                velocity *= pushMultiplier;

                velocity = Vector3.ClampMagnitude(
                    velocity,
                    maxSpeed
                );
            }

            // Apply force when outside the safe area.
            ApplyForceField(dt);

            // A CharacterController does not fall automatically.
            // Apply gravity only when the button has enabled it.
            if (playerGravityEnabled)
            {
                if (controller.isGrounded && velocity.y < 0f)
                {
                    // Keep feet touching the floor without building fall speed.
                    velocity.y = -groundStickSpeed;
                }
                else
                {
                    velocity.y -= gravityAcceleration * dt;
                }
            }

            // Continue moving with the current velocity.
            Vector3 movement = velocity * dt;

            if (movement.sqrMagnitude > 0.00000001f)
            {
                controller.Move(movement);
            }
        }

        wasClimbing = isClimbing;
        lastPosition = transform.position;
    }
    // Called when the CharacterController hits a collider.
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // Do not change velocity during climbing.
        if (climbProvider != null &&
            climbProvider.climbAnchorInteractor != null)
            return;

        Vector3 normal = hit.normal.normalized;

        // With gravity enabled, land instead of bouncing off the floor.
        if (playerGravityEnabled && normal.y > 0.5f && velocity.y < 0f)
        {
            velocity.y = -groundStickSpeed;
            return;
        }

        // Find how quickly we are moving into the wall.
        float speedIntoWall =
            Vector3.Dot(velocity, normal);

        if (speedIntoWall >= -0.01f)
            return;

        // Keep movement parallel to the wall.
        Vector3 slideVelocity =
            Vector3.ProjectOnPlane(velocity, normal);

        slideVelocity *= (1f - slideFriction);

        // Bounce away from the wall.
        Vector3 bounceVelocity =
            -normal * speedIntoWall * bounceAmount;

        // Combine sliding and bouncing.
        velocity = slideVelocity + bounceVelocity;
    }
    void ApplyForceField(float dt)
    {
        if (forceFieldCenter == null)
            return;

        // Use the headset for player distance when available.
        Vector3 playerPosition =
            vrCamera != null
            ? vrCamera.position
            : transform.position;

        Vector3 direction =
            forceFieldCenter.position - playerPosition;

        float distance = direction.magnitude;

        // No pull inside the safe area.
        if (distance <= forceFieldRadius)
            return;

        Vector3 pullDirection = direction.normalized;

        // Accelerate the player back towards the centre.
        velocity += pullDirection * pullStrength * dt;

        velocity = Vector3.ClampMagnitude(
            velocity,
            maxPullSpeed
        );

    }

    void OnDrawGizmosSelected()
    {
        if (forceFieldCenter == null)
            return;

        Gizmos.color = Color.cyan;

        Gizmos.DrawWireSphere(
            forceFieldCenter.position,
            forceFieldRadius
        );
    }
}

