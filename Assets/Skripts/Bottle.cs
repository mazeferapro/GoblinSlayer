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
    public Inventory inv;
    public Item item;
    int count = 1;
    int pos;
    void OnTriggerEnter2D(Collider2D tr)
    {
        if (tr.gameObject.tag == "Player")
        {
            pos = Random.Range(0, 3);
            inv.AddItem(pos, data.items[item.id], count);
            tr.GetComponent<Health>().USB(1);
            Destroy(gameObject);
        }
    }


}
