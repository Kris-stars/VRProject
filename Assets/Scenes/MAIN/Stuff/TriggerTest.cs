using JetBrains.Annotations;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
public class TriggerTest : MonoBehaviour
{
    public GameObject Door;
    public GameObject thisButton;
    public GameObject otherButton;
    public UnityEvent onPress;
    public UnityEvent onRelease;
    GameObject presser;
    public bool isPressed;
    private Animator animator;
    public AnimationClip CloseDoor;
    public AnimationClip OpenDoor;
    bool isDoorOpen;
    public float rotationSpeed;
    public bool onCooldown;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isPressed = false;
        onCooldown = false;
        isDoorOpen = Door.GetComponent<DoorScript>().isOpenedDoor;
    }
    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            if (!isPressed && onCooldown == false)
            {
                thisButton.transform.localPosition = new Vector3(0, 0.0f, 0);
                presser = other.gameObject;
                onPress.Invoke();
                isPressed = true;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        thisButton.transform.localPosition = new Vector3(0, 0.05f, 0);
        onRelease.Invoke();
        isPressed = false;
    }
    public void ChangeDoorState()
    {
        Debug.Log(otherButton.GetComponent<TriggerTest>().isDoorOpen);
        if (isDoorOpen)
        {
            StartCoroutine(DoorCoroutine(-1));
            isDoorOpen = !isDoorOpen;
        }
        else if (otherButton.GetComponent<TriggerTest>().isDoorOpen == false)
        {
            StartCoroutine(DoorCoroutine(1));
            isDoorOpen = !isDoorOpen;
        }
        onCooldown = true;
        Invoke("TurnOffCooldown", 1);
    }

     public void TurnOffCooldown()
        {
            onCooldown = false;
        }
    IEnumerator DoorCoroutine(int direction)
    {
        if (isDoorOpen)
        {
            Door.GetComponent<DoorScript>().CloseDoor();
        } else
        {
            Door.GetComponent<DoorScript>().OpenDoor();
        }
        yield break;
    }
}



