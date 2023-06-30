using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pasar1 : MonoBehaviour
{

    public Animator theDoor;

    private void OnTriggerEnter(Collider other)
    {
        theDoor.Play("abrir1");
    }

    private void OnTriggerExit(Collider other)
    {
        theDoor.Play("cerrar1");
    }
}
