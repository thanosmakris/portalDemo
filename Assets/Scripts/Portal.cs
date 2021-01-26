using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Portal : MonoBehaviour
{
    [SerializeField]
    private Transform portalTraveller;
    public Transform GetPortalTraveller { get { return portalTraveller; } }
    [SerializeField]
    private Transform portalContentParent;
    [SerializeField]
    private List<Renderer> portalContentRenderers;
    [SerializeField]
    private GameObject portalLightsParent;

    private bool wasInFront;
    private bool inPortal;

    private void Awake()
    {
        foreach (Transform child in portalContentParent)
        {
            portalContentRenderers.Add(child.gameObject.GetComponent<Renderer>());
        }
        portalTraveller = Camera.main.transform;
    }

    private void Start()
    {
        HandleDimention(false);
    }

    public void HandleDimention(bool inside)
    {
        //ameMaster.Instance.HandleOcclusion(inside);
        //Inside portal
        if (inside == true)
        {
            foreach (Renderer renderer in portalContentRenderers)
            {
                renderer.material.SetInt("_Stencil", 6);
            }
        }
        //Out of portal
        else
        {
            foreach (Renderer renderer in portalContentRenderers)
            {
                renderer.material.SetInt("_Stencil", 3);
            }
        }
    }

    [ContextMenu("GetInPortal")]
    public void GetIn()
    {
        HandleDimention(true);
    }

    [ContextMenu("GetOutOfPortal")]
    public void GetOutOf()
    {
        HandleDimention(false);
    }

}
