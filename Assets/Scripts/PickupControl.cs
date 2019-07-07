using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupControl : MonoBehaviour
{
    GameObject mainCamera;
    public GameObject ParticleSystem;
    public GameObject ParticleSystem2;
    bool carrying;
    GameObject carriedObject;
    public float distance;
    public float smooth;

    void Start()
    {
        mainCamera = GameObject.FindWithTag("MainCamera");
    }

    void Update()
    {
        if(carrying)
        {
            carry(carriedObject);
            checkDrop();
            ParticleSystem.SetActive(false);
            ParticleSystem2.SetActive(true);
        }
        else
        {
            pickup();
        }
    }

    void carry(GameObject o)
    {
        o.transform.position = Vector3.Lerp(o.transform.position, mainCamera.transform.position + mainCamera.transform.forward * distance, Time.deltaTime * smooth);
    }

    void pickup()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            int x = Screen.width / 2;
            int y = Screen.height / 2;

            Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x, y));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Pickupable p = hit.collider.GetComponent<Pickupable>();
                if (p != null)
                {
                    carrying = true;
                    carriedObject = p.gameObject;
                    p.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                }
            }
        }

    }

    void checkDrop()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            dropObject();
        }
    }

    void dropObject()
    {
        carrying = false;
        carriedObject.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        carriedObject = null;
    }
}
