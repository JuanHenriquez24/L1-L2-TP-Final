using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerActions : MonoBehaviour
{
    private bool doorInRange;
    private GameObject currentDoor;
    private bool bookInRange;
    [SerializeField] private GameObject book;
    [SerializeField] private GameObject bookDoor;
    private bool bookDoorOpen;
    [SerializeField] private GameObject holdBook;
    private bool esqueletoPersigue;
    private float timer;
    [SerializeField] private TextMeshProUGUI timerGO;
    [SerializeField] private GameObject perdiste;
    [SerializeField] private GameObject esqueleto;
    [SerializeField] private GameObject ganaste;
    //public bool startTimer;
    //public bool hasBook;
    public DataJugadorYObjetos data;
    [SerializeField] private GameObject Qsign;

    private void Start()
    {
        data.hasBook = false;
        holdBook.SetActive(false);
        timerGO.enabled = false;
        perdiste.SetActive(false);
        esqueleto.SetActive(false);
        ganaste.SetActive(false);
        Qsign.SetActive(false);
    }

    void Update()
    {
        timer += Time.deltaTime;
        timerGO.text = Mathf.RoundToInt(timer) + "s";

        if(bookInRange || doorInRange)
        {
            Qsign.SetActive(true);
        }
        else
        {
            Qsign.SetActive(false);
        }

        if(bookDoorOpen && bookInRange && Input.GetKeyDown(KeyCode.Q))
        {
            Destroy(book);
            holdBook.SetActive(true);
            data.hasBook = true;
        }
        else if (doorInRange && Input.GetKeyDown(KeyCode.Q))
        {
            openDoor();
        }

        if (data.startTimer)
        {
            timerGO.enabled = true;
            timer = 0;
            data.startTimer = false;
            esqueleto.SetActive(true);
            esqueletoPersigue = true;
        }

        if(timer >= 60 && esqueletoPersigue)
        {
            ganaste.SetActive(true);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Puerta")
        {
            doorInRange = true;
            currentDoor = col.gameObject;
        }
        else if(col.tag == "Libro")
        {
            bookInRange = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject == currentDoor)
        {
            doorInRange = false;
            currentDoor = null;
        }
        else if (col.tag == "Libro")
        {
            bookInRange = false;
        }
        if(col.tag == "enemigo")
        {

            perdiste.SetActive(true);
        }
    }

    void openDoor()
    {
        currentDoor.GetComponent<Animator>().SetBool("abrir", !currentDoor.GetComponent<Animator>().GetBool("abrir"));
        if(currentDoor == bookDoor)
        {
            bookDoorOpen = !bookDoorOpen;
        }
    }
}
