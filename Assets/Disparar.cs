using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparar : MonoBehaviour
{
    public GameObject inicio;
    public GameObject bala;
    public float ratio = 0.3f;
    private float ratioTime = 0f;
    public float velBala;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            if (Time.time > ratioTime)
            {
                GameObject balaT = Instantiate(bala, inicio.transform.position, inicio.transform.rotation) as GameObject;
                Rigidbody rb = balaT.GetComponent<Rigidbody>();
                rb.AddForce(transform.forward * velBala);
                ratioTime = Time.time + ratio;
                Destroy(balaT, 5.0f);
            }
        }
    }
}
