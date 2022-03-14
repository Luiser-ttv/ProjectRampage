using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject volumeOptions;
    public GameObject iconoOpciones;
    public GameObject iconoMapa;
    public GameObject iconoInv;

    public Animator fadeMenu;


    void Start()
    {
        pauseMenuUI.SetActive(false);
        iconoInv.SetActive(true);
        iconoMapa.SetActive(true);
        iconoOpciones.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && pauseMenuUI.activeSelf == false)
        {
            GameIsPaused = true;
            pauseMenuUI.SetActive(true);
            iconoInv.SetActive(false);
            iconoMapa.SetActive(false);
            iconoOpciones.SetActive(false);
            fadeMenu.enabled = true;
            fadeMenu.Play("FadeMenu");
            Pause();

        }
        else if(Input.GetKeyDown(KeyCode.Escape) && pauseMenuUI.activeSelf == true)
        {
            Time.timeScale = 1f;
            GameIsPaused = false;
            pauseMenuUI.SetActive(false);
            volumeOptions.SetActive(false);
            iconoInv.SetActive(true);
            iconoMapa.SetActive(true);
            iconoOpciones.SetActive(true);
            fadeMenu.enabled = true;
            fadeMenu.Play("FadeMenu");
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void loadVolume()
    {
        volumeOptions.SetActive(true);
        pauseMenuUI.SetActive(false);
    }

    public void backMenu()
    {
        volumeOptions.SetActive(false);
        pauseMenuUI.SetActive(true);
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
        Debug.Log("Loading menu...");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}