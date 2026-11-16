using System.Collections;
using UnityEngine;

public class EmergencyScript : MonoBehaviour
{
    public GameObject[] lights;
    public bool isFixed;
    public GameObject Door;
    public float AlarmDelay;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
            lights = GameObject.FindGameObjectsWithTag("Light");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Door.GetComponent<DoorScript>().OpenDoor();
        GetComponent<BoxCollider>().enabled = false;
        StartCoroutine(Flash());
    }
    public void FlashRed()
    {
        foreach (var light in lights)
        {
            light.GetComponent<Light>().color = Color.red;
            light.GetComponent<AudioSource>().Play();
        }
    }
    public void FlashWhite()
    {
        foreach (var light in lights)
        {
            light.GetComponent<Light>().color = Color.white;
        }
    }
    IEnumerator Flash()
    {
        while (!isFixed)
        {
            yield return new WaitForSeconds(AlarmDelay);
            if (!isFixed)
            {
                FlashRed();

            }
            yield return new WaitForSeconds(AlarmDelay);
            FlashWhite();
        }
    }
}
