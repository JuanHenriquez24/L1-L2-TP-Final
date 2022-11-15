using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessingEncender : MonoBehaviour
{
    public DataJugadorYObjetos data;
    public GameObject Proccess;
    // Update is called once per frame
    void Start()
    {
        Proccess.SetActive(false);
    }

    void Update()
    {
        if (data.startTimer == true)
        {
            Proccess.SetActive(true);
        }
    }
}
