using UnityEngine;

public class ClockHand : MonoBehaviour
{
    public float rotateSpeed;
    public GameObject secHand;
    public GameObject minHand;
    public GameObject hourHand;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rotateSpeed = Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        secHand.transform.Rotate(0, 0, rotateSpeed, Space.World);
        minHand.transform.Rotate(0, 0, rotateSpeed/60, Space.World);
        hourHand.transform.Rotate(0, 0, rotateSpeed/3600, Space.World);
    }
}
