using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class GoodBatteryCelebration : MonoBehaviour
{
    [Header("Battery Check")]
    public XRSocketInteractor batterySocket;
    public XRGrabInteractable goodBattery;

    [Header("Celebration")]
    public ParticleSystem confetti;
    public AudioSource audioSource;
    public AudioClip cheerfulSound;

    [Header("Things Fixed")]
    public GameObject buzz;
    public AudioListener player;
    public EmergencyScript es;

    private bool hasCelebrated = false;

    

    void OnEnable()
    {
        
            batterySocket.selectEntered.AddListener(OnBatteryInserted);
    }

    void OnDisable()
    {
        
            batterySocket.selectEntered.RemoveListener(OnBatteryInserted);
    }

    void OnBatteryInserted(SelectEnterEventArgs args)
    {
        

        // Only the actual good battery can trigger the celebration.
        if (hasCelebrated || goodBattery == null ||
            args.interactableObject != (IXRSelectInteractable)goodBattery)
            return;
        es.isFixed = true;
        player.enabled = true;
        buzz.SetActive(false);

        hasCelebrated = true;

        
        confetti.Play();

        
        audioSource.PlayOneShot(cheerfulSound);
    }
}
