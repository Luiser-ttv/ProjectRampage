using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndDay : MonoBehaviour
{
    public GameObject blackOutSquare;
    private GameObject Jugador;

    public TMP_Text endTexto;
    public string myText;

    bool IsHere = false;

    Collider2D c2DTrigger;

    public void Update()
    {
        Jugador = GameObject.FindGameObjectWithTag("Player");
        c2DTrigger = GameObject.FindGameObjectWithTag("PuertaBar").GetComponent<Collider2D>();
        if (IsHere == true)
        {
            StartCoroutine(FadeBlackOutSquare());
            endTexto.text = "DIA 2";
            Jugador.transform.position = new Vector2(52, -61);
            StartCoroutine(WaitSeconds());
            StartCoroutine(FadeBlackOutSquare(false));
            
            IsHere = false;
            
        }
        if(IsHere == false)
        {
            //c2DTrigger.enabled = true;
            
        }
        if (Jugador.transform.position.x != 52 && Jugador.transform.position.y != -61)
        {
            endTexto.text = "";
        }
    }

public IEnumerator FadeBlackOutSquare(bool fadeToBlack = true, float fadeSpeed = 0.1f)
    {
        Color objectColor = blackOutSquare.GetComponent<Image>().color;
        float fadeAmount;
        if (fadeToBlack)
        {
            while (blackOutSquare.GetComponent<Image>().color.a < 1)
            {
                fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);
                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                blackOutSquare.GetComponent<Image>().color = objectColor;
                yield return null;
            }
               
        }
        else
        {
            while (blackOutSquare.GetComponent<Image>().color.a > 0)
            {
                fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                blackOutSquare.GetComponent<Image>().color = objectColor;
                yield return null;

            }
        }
    }

    IEnumerator WaitSeconds()
    {
        yield return new WaitForSeconds(1);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            blackOutSquare.SetActive(true);
            IsHere = true;
        }

    }
    /*
      private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            IsHere = false;
        }
    }
     */


}

