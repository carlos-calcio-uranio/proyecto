using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plat_fall : MonoBehaviour
{ 
    Rigidbody rbd;
    // Start is called before the first frame update
    void Start()
    {
        rbd = GetComponent<Rigidbody>();
    }


    IEnumerator retraso()
    {
        yield return new WaitForSeconds(2);

        rbd.isKinematic = false;

        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            StartCoroutine(retraso());
        }
    }
}
