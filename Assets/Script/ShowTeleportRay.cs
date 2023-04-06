using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ShowTeleportRay : MonoBehaviour
{
    [SerializeField] private GameObject reticle;
    [SerializeField] private XRInteractorLineVisual teleportRay;
 

 
    public void ActivateTeleportRay()
    {
        reticle.SetActive(true);
        teleportRay.enabled = true;
    }

    public void DeactivateTeleportRay()
    {
        reticle.SetActive(false);
        teleportRay.enabled = false;
        
    }
}
