using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject[] activeInGameUIObjects;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject pauseMenuLayout;
    [SerializeField] private GameObject helpScreen;

    [SerializeField] private Transform playerTransform;

    private void Start()
    {
        pauseMenu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            GameManager.Instance.StartUsingPC(playerTransform);
            
            foreach (GameObject activeInGameUIObject in activeInGameUIObjects)
                activeInGameUIObject.SetActive(false);
            
            pauseMenu.SetActive(true);
        }
    }

    public void Continue()
    {
        foreach (GameObject activeInGameUIObject in activeInGameUIObjects)
            activeInGameUIObject.SetActive(true);
        
        pauseMenu.SetActive(false);
        
        GameManager.Instance.StopUsingPC();
    }

    public void OpenHelp()
    {
        helpScreen.SetActive(true);
        pauseMenuLayout.SetActive(false);
    }
    
    public void CloseHelp()
    {
        pauseMenuLayout.SetActive(true);
        helpScreen.SetActive(false);
    }

    public void QuitApplication()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}
