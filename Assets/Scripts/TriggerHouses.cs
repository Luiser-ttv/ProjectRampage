using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerHouses : MonoBehaviour
{
    
    private bool isPlayerInRange;
    private bool isBannedSite;
    public int numeroEscena;

    void Update()
    {
        if (isBannedSite)
        {

        }
        else if (isPlayerInRange)
        {
            SceneManager.LoadScene(numeroEscena);
        }
        
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.CompareTag("Banned"))
        {
            isBannedSite = true;
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
           
        }
        
       
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
           
        }
    }
}
