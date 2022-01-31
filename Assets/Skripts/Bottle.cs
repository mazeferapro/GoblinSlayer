using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : MonoBehaviour
{
    public LayerMask Player;
    void OnTriggerEnter2D(Collider2D tr)
    {
        if (tr.gameObject.tag == "Player")
        {
            tr.GetComponent<Health>().USB(1);
            Destroy(gameObject);
        }
    }


}
