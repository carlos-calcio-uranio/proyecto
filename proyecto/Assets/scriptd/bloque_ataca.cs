using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bloque_ataca : MonoBehaviour
{ 
    public GameObject enemigo,bala;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("punto_debil"))
        {
            enemigo.gameObject.SetActive(false);
            bala.gameObject.SetActive(false);
        }
    }

}
