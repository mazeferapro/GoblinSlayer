using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryTest : MonoBehaviour
{
    public bool[] isFool;
    public GameObject[] slots;
    public GameObject backGround;


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            backGround.SetActive(!backGround.activeSelf);
        }
    }
}
