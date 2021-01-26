using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalViewport : MonoBehaviour
{
    [SerializeField]
    private Portal portal;

    private int count = 0;
    private bool collided;

    private void Start()
    {
        collided = false;
    }

    private void Update()
    {
        if (collided == true)
        {
            count++;
            if (count % 2 == 1)
            {
                portal.HandleDimention(true);
            }
            else
            {
                portal.HandleDimention(false);

            }
            Debug.Log(count);
            collided = false;
        }
    }


    bool IsDeviceInFront()
    {
        Vector3 pos = transform.InverseTransformPoint(portal.GetPortalTraveller.position);
        return pos.z >= 0 ? true : false;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == portal.GetPortalTraveller)
        {
            collided = true;
        }
    }
}
