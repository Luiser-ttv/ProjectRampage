using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StartFirstScene : MonoBehaviour
{
    
    [SerializeField] private GameObject dialogPanel;
    [SerializeField] private TMP_Text dialogText;
    [SerializeField] private Texture ImagenPerfil;
    [SerializeField] private GameObject UI;
    public RawImage Perfil;

    [SerializeField, TextArea(4, 6)] private string[] dialogLines;

    private float typingTime = 0.05f;

    private bool isPlayerInRange;
    private bool didDialogStart;
    private int lineIndex;

    void Start()
    {
        
    }

    void Update()
    {
        
            if (isPlayerInRange)
            {
                if (lineIndex >= dialogLines.Length)
                {
                    didDialogStart = false;
                    dialogPanel.SetActive(false);
                    Debug.Log("BIEN");
                    MovLoco();
                    Time.timeScale = 1f;
                    
                }
                else if (!didDialogStart)
                {
                    StartDialog();
                }
                else if (dialogText.text == dialogLines[lineIndex] && Input.GetKeyDown(KeyCode.E))
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
        UI.SetActive(false);
        dialogPanel.SetActive(true);
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

    private void MovLoco()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector3 linePos = gameObject.transform.position;
            float linePosX = gameObject.transform.position.x;
            float linePosY = gameObject.transform.position.y + 1;

            isPlayerInRange = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
            UI.SetActive(true);
        }
    }
}
