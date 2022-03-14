using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryStart : MonoBehaviour
{
    public GameObject Inventario;
    public GameObject Mochila;



    void Start()
    {
        Inventario.SetActive(false);
        Mochila.SetActive(true);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && Inventario.activeSelf == false)
        {
            Inventario.SetActive(true);
            Mochila.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.I) && Inventario.activeSelf == true)
        {
            Inventario.SetActive(false);
            Mochila.SetActive(true);
        }



    }
}
