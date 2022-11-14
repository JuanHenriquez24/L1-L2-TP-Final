using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    public bool doorInRange;
    private GameObject currentDoor;
    private bool bookInRange;
    private GameObject book;
    private GameObject bookDoor;
    private bool bookDoorOpen;

    void Update()
    {

        if (doorInRange && Input.GetKeyDown(KeyCode.Q))
        {
            openDoor();
        }
    }

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("colliding");
        if(col.tag == "Puerta")
        {
            doorInRange = true;
            currentDoor = col.gameObject;
            Debug.Log("enter");
        }
        else if(col.tag == "Libro")
        {
            bookInRange = true;
            book = col.gameObject;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject == currentDoor)
        {
            doorInRange = false;
            currentDoor = null;
            Debug.Log("Exit");
        }
        else if (col.tag == "Libro")
        {
            bookInRange = false;
            book = null;
        }
    }

    void openDoor()
    {
            currentDoor.GetComponent<Animator>().SetBool("abrir", !currentDoor.GetComponent<Animator>().GetBool("abrir"));
    }
}
