using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LocoDialog : MonoBehaviour
{
    [SerializeField] private GameObject dialogMark;
    [SerializeField] private GameObject dialogPanel;
    [SerializeField] private TMP_Text dialogText;
    [SerializeField] private Texture ImagenPerfil;
    public RawImage Perfil;

    [SerializeField, TextArea(4, 6)] private string[] dialogLines;

    private float typingTime = 0.05f;

    public GameObject iconoOpciones;
    public GameObject iconoMapa;
    public GameObject iconoInv;


    private bool isPlayerInRange;
    private bool didDialogStart;
    private int lineIndex;

    void Start()
    {

    }

    void Update()
    {

        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (!didDialogStart)
            {
                StartDialog();
            }
            else if (dialogText.text == dialogLines[lineIndex])
            {
                NextDialogLine();
            }
            else
            {
                StopAllCoroutines();
                dialogText.text = dialogLines[lineIndex];
            }
        }


    }

    private void StartDialog()
    {
        didDialogStart = true;
        dialogPanel.SetActive(true);
        dialogMark.SetActive(false);
        iconoMapa.SetActive(false);
        iconoOpciones.SetActive(false);
        iconoInv.SetActive(false);
        lineIndex = 0;
        Time.timeScale = 0f;
        Perfil.GetComponent<Texture>();
        Perfil.texture = ImagenPerfil;
        StartCoroutine(ShowLine());
    }

    private void NextDialogLine()
    {
        lineIndex++;
        if (lineIndex < dialogLines.Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            didDialogStart = false;
            dialogPanel.SetActive(false);
            dialogMark.SetActive(true);
            iconoMapa.SetActive(true);
            iconoOpciones.SetActive(true);
            iconoInv.SetActive(true);

            Time.timeScale = 1f;
        }
    }

    private IEnumerator ShowLine()
    {
        dialogText.text = string.Empty;

        foreach (char ch in dialogLines[lineIndex])
        {
            dialogText.text += ch;
            yield return new WaitForSecondsRealtime(typingTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector3 linePos = gameObject.transform.position;
            float linePosX = gameObject.transform.position.x;
            float linePosY = gameObject.transform.position.y + 1;

            isPlayerInRange = true;
            dialogMark.SetActive(true);

            dialogMark.transform.position = new Vector3(linePosX, linePosY, 0);

        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
            dialogMark.SetActive(false);

        }
    }
}
