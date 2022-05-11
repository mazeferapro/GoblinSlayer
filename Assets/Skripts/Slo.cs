using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slo : MonoBehaviour
{
    private InventoryTest inventory;
    public int i;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<InventoryTest>();
    }

    private void Update()
    {
        if(transform.childCount <= 0)
        {
            inventory.isFool[i] = false;
        }
    }

    public void DropItem()
    {
        foreach(Transform child in transform)
        {
            child.GetComponent<Droped>().SpawnDropedItem();
            GameObject.Destroy(child.gameObject);
        }
    }
}
