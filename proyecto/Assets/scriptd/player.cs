using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public GameObject muro, pesa, trampolin_1, enemigo, fin_2;
    public float velocidad, fuerzaJ, fuerzaJ_plataforma;
    public float fuerza_salto_largo, fuerza_salto_alto, fuerzaJ_2;
    public int punto;
    public bool power_up = true;

    int i;
    Rigidbody rbd;

    void Start()
    {
        rbd = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {   
        // salto
        if (power_up == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (rbd.velocity.y == 0)
                {
                    i = 0;
                }

                i++;

                if (i <= 1)
                {
                    rbd.AddForce(new Vector3(0, 1, 0) * fuerzaJ, ForceMode.Impulse);
                }
            }
        }
        //

        // movimiento especial
        if (Input.GetKeyDown(KeyCode.C) && rbd.velocity.y != 0)
        {
            rbd.AddForce(new Vector3(0, -1, 0) * fuerzaJ_2, ForceMode.Impulse);
        }
        //

        // movimiento comun
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        rbd.velocity = new Vector3(x * velocidad, rbd.velocity.y, rbd.velocity.z);
        rbd.velocity = new Vector3(rbd.velocity.x, rbd.velocity.y, z * velocidad);
        //

        // aparecer el trampolin
        if (punto >= 71)
        {
            trampolin_1.gameObject.SetActive(true);
        }
        //

        // doble salto, power up
        if(punto >= 71)
        {
            power_up = false;
            salto_doble();
        }
        //
    }
   

    void salto_doble() // funcion doble salto
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (rbd.velocity.y == 0)
            {
                i = 0;
            }

            i++;

            if (i <= 2)
            {
                rbd.AddForce(new Vector3(0, 1, 0) * fuerzaJ, ForceMode.Impulse);
            }
        }
    }

    private void OnCollisionEnter(Collision collision) 
    {
        if (collision.gameObject.CompareTag("plataforma"))
        {
                rbd.AddForce(new Vector3(0, 1, 0) * fuerzaJ_plataforma, ForceMode.Impulse);
        }

        if (collision.gameObject.CompareTag("plata_2"))
        {
            rbd.AddForce(new Vector3(0, 1, 0) * fuerza_salto_largo, ForceMode.Impulse);
        }

        if (collision.gameObject.CompareTag("trampolin_1"))
        {
            rbd.AddForce(new Vector3(0, 1, 0) * fuerza_salto_alto, ForceMode.Impulse);
        }

        if (collision.gameObject.CompareTag("daño"))
        {
            SceneManager.LoadScene("SampleScene");
        }

        if (collision.gameObject.CompareTag("fin")) 
        {
            fin_2.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("punto"))
        {
            punto++;
            Destroy(other.gameObject);
        }

        if (other.CompareTag("boton"))
        {
            Destroy(other.gameObject);
            muro.gameObject.SetActive(false);
        }

        if (other.CompareTag("boton_2"))
        {
            Destroy(other.gameObject);
            pesa.gameObject.SetActive(true);
        }
    }

}
