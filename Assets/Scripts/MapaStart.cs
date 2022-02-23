using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapaStart : MonoBehaviour
{
    

    public GameObject MapaAssets;
    public GameObject Minimapa;
    public GameObject Marcador;

    int sceneID;
   

    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.M) && MapaAssets.activeSelf == false)
        {
            Time.timeScale = 0f;
            MapaAssets.SetActive(true);
            Minimapa.SetActive(false);
            Marcador.SetActive(true);
            EscenarioActual();

        }
        else if (Input.GetKeyDown(KeyCode.M) && MapaAssets.activeSelf == true)
        {
            Time.timeScale = 1f;
            MapaAssets.SetActive(false);
            Minimapa.SetActive(true);
            Marcador.SetActive(false);

        }



    }

    private void EscenarioActual()
    {
        sceneID = SceneManager.GetActiveScene().buildIndex;
        switch (sceneID)
        {
            case 1: case 2:
                Marcador.transform.position = new Vector3(-3, -1, -3);
                break;

            default:

                break;
        }
        
        
    }
}
