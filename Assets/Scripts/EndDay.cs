using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndDay : MonoBehaviour
{
    private GameObject blackScreen;
    public TMP_Text endTexto;
    public string myText;

    // Start is called before the first frame update
    void Start()
    {
        blackScreen = GameObject.FindGameObjectWithTag("BlackScreen");
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            blackScreen.SetActive(true);
            endTexto.text = myText;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            blackScreen.SetActive(false);
        }
    }

}
