using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[System.Serializable]


public class Bottle : MonoBehaviour
{
    public LayerMask Player;
    public DataBase data;
    public Item item;
    void OnTriggerEnter2D(Collider2D tr)
    {
        if (tr.gameObject.tag == "Player")
        {
            tr.GetComponent<Health>().USB(1);
            Destroy(gameObject);
        }
    }


}
