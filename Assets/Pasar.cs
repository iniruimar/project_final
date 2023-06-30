using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pasar : MonoBehaviour
{

    public Animator theDoor;

    private void OnTriggerEnter(Collider other)
    {
        theDoor.Play("abrir");
    }

    private void OnTriggerExit(Collider other)
    {
        theDoor.Play("cerrar");
    }
}
