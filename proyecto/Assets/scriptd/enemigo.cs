using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigo : MonoBehaviour
{
    public GameObject player, bala, cañon;
    public float velocidad_bala;
    public float limite;

    Vector3 direccion;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("inst_disparo", 0.2f, 0.56f);
    }

    // Update is called once per frame
    void Update()
    {
        direccion = (player.transform.position - transform.position);
        if(direccion.magnitude <= limite)
        {
            transform.forward = direccion.normalized;
        }
    }
     
    void inst_disparo()
    {
        if (direccion.magnitude <= limite)
        {
            GameObject temp_bala = Instantiate(bala, cañon.transform.position, Quaternion.identity);


            temp_bala.transform.up = direccion.normalized;
            temp_bala.GetComponent<Rigidbody>().velocity = direccion.normalized * velocidad_bala;
        }

    }
}
