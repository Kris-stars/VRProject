using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public Animator animator;
    public bool isOpenedDoor;
    public AudioListener player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //if (isOpenedDoor) {animator.SetTrigger("Open Door");}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenDoor()
    {
        animator.SetTrigger("Open Door");
        if (!isOpenedDoor) { player.enabled = false; }
    }
    public void CloseDoor()
    {
        animator.SetTrigger("Close Door");
        if (!isOpenedDoor) { player.enabled = true; }
    }
}

