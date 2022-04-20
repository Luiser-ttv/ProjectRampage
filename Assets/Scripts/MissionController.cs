using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionController : MonoBehaviour
{
    private Inventory inventory;

    public bool isCompleted = false;
    
    void Start()
    {
        inventory = gameObject.GetComponent<Inventory>();
    }

    
    void Update()
    {
       
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Balloon") || other.CompareTag("Chest") || other.CompareTag("Chest"))
        {
            isCompleted = true;
        }
    }
}
