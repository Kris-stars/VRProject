using UnityEngine;

public class SpiningRec : MonoBehaviour
{
    public float rotateSpeed;
    public GameObject rec;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rotateSpeed = Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        rec.transform.Rotate(0, rotateSpeed*20, 0, Space.World);
    }
}
