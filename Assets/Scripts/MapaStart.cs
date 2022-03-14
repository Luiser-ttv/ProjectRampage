using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapaStart : MonoBehaviour
{
    

    public GameObject MapaAssets;
    public GameObject Minimapa;
    public GameObject Marcador;
    public GameObject iconoOpciones;
    public GameObject iconoMapa;
    public GameObject iconoInv;


    int sceneID;


     void Start()
    {
        iconoMapa.SetActive(true);
        iconoOpciones.SetActive(true);
        iconoInv.SetActive(true);
    }

    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.M) && MapaAssets.activeSelf == false)
        {
            Time.timeScale = 0f;
            MapaAssets.SetActive(true);
            Minimapa.SetActive(false);
            Marcador.SetActive(true);
            iconoMapa.SetActive(false);
            iconoOpciones.SetActive(false);
            iconoInv.SetActive(false);
            EscenarioActual();

        }
        else if (Input.GetKeyDown(KeyCode.M) && MapaAssets.activeSelf == true)
        {
            Time.timeScale = 1f;
            MapaAssets.SetActive(false);
            Minimapa.SetActive(true);
            Marcador.SetActive(false);
            iconoMapa.SetActive(true);
            iconoOpciones.SetActive(true);
            iconoInv.SetActive(true);

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
            case 3:
                Marcador.transform.position = new Vector3(-4, -2, -3);
                break;
            default:

                break;
        }
        
        
    }
}
