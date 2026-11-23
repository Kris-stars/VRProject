using System.Collections;
using UnityEngine;

public class EmergencyScript : MonoBehaviour
{
    public GameObject[] lights;
    public bool isFixed;
    public GameObject Door;
    public float AlarmDelay;

    public GameObject Text;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
            lights = GameObject.FindGameObjectsWithTag("Light");
    }

  
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.CompareTag("Player"))
        {
            Door.GetComponent<DoorScript>().OpenDoor();
            GetComponent<BoxCollider>().enabled = false;
            StartCoroutine(Flash());
            Text.SetActive(true);
        }
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
