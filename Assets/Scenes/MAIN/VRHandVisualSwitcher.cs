using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using UnityEngine.XR.Interaction.Toolkit.Locomotion.Climbing;

// Put this on a controller object that stays active, NOT on the hand model.
public class VRHandVisualSwitcher : MonoBehaviour
{
    [Header("References for this hand")]
    public XRBaseInteractor grabInteractor;
    public GameObject handModel;
    public GameObject climbSphere;

    void Update()
    {
        bool holdingSomething = false;
        bool grippingClimbSurface = false;

       
        
        foreach (var selected in grabInteractor.interactablesSelected)
        {
            if (selected == null)
            continue;

            holdingSomething = true;

            // This checks the actual XR Climb Interactable used by your walls.
            if (selected is ClimbInteractable)
            {
            grippingClimbSurface = true;
            break;
            }
        }
        

        // No grab: hand on, sphere off.
        // Ordinary object: hand off, sphere off.
        // Climb surface: hand off, sphere on.
        if (handModel.activeSelf == holdingSomething)
            handModel.SetActive(!holdingSomething);

        if (climbSphere.activeSelf != grippingClimbSurface)
            climbSphere.SetActive(grippingClimbSurface);
    }
}
