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
    public GameObject Jugador;
    public Vector2 posMarcador;



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
        Marcador.transform.position = new Vector2(0,0);
        float jugadorPosX = Jugador.transform.position.x;
        float jugadorPosY = Jugador.transform.position.y;

        if (jugadorPosX >= 17 && jugadorPosY <= -17)
        {
            //Debug.Log(jugadorPosX);
            Marcador.transform.position = posMarcador;
        }
        else if (jugadorPosX <= 17 && jugadorPosY <= -17)
        {
            Marcador.transform.position = posMarcador;
        }








    }
}
