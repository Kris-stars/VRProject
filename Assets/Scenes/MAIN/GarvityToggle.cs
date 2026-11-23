using TMPro;
using UnityEngine;

public class GarvityToggle : MonoBehaviour
{
    public TMP_Text buttonText;

    private bool gravityOn = false;

    void Start()
    {
        Physics.gravity = Vector3.zero;
    }

    public void ToggleGravity()
    {
        gravityOn = !gravityOn;

        if (gravityOn)
        {
            // Turn normal gravity ON.
            Physics.gravity = new Vector3(0, -9.81f, 0);

            buttonText.text = "see not fun want 0 gravity back ?";
        }
        else
        {
            // Turn gravity OFF.
            Physics.gravity = Vector3.zero;

            buttonText.text = "Turn Gravity ON";
        }
    }
}
