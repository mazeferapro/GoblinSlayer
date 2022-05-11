using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PickUp : MonoBehaviour
{
    private InventoryTest inventory;
    public GameObject inventorySpace;


    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<InventoryTest>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if(inventory.isFool[i] == false)
                {
                    inventory.isFool[i] = true;
                    Instantiate(inventorySpace, inventory.slots[i].transform);
                    Destroy(gameObject);
                    break;  
                }
            }
        }
    }
}

