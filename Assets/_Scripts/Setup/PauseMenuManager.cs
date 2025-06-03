using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PauseMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject[] activeInGameUIObjects;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject pauseMenuLayout;

    private void Start()
    {
        pauseMenu.SetActive(false);            
        pauseMenuLayout.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) && !GameManager.Instance.isUsingPauseMenuGameManager)
        {
            EnterPauseMenuConditions();
            
            foreach (GameObject activeInGameUIObject in activeInGameUIObjects)
                activeInGameUIObject.SetActive(false);
            
            pauseMenu.SetActive(true);
            return;
        }

        if (Input.GetKeyUp(KeyCode.Escape) && GameManager.Instance.isUsingPauseMenuGameManager)
            Continue();
    }

    private void EnterPauseMenuConditions()
    {
        GameManager.Instance.isUsingPauseMenuGameManager = true;
        if (GameManager.Instance.isUsingPCGameManager)
            return;
        
        GameManager.Instance.playerObject.GetComponent<PlayerMovement>().StopMovement();
        
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        GameManager.Instance.cursorIcon.SetActive(false);
    }

    private void ExitPauseMenuConditions()
    {
        if (GameManager.Instance.isUsingPCGameManager)
        {
            GameManager.Instance.isUsingPauseMenuGameManager = false;
            GameManager.Instance.cursorIcon.SetActive(false);
            GameManager.Instance.infoText.SetActive(false);
            return;
        }
        
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        
        GameManager.Instance.isUsingPauseMenuGameManager = false;
    }
    
    public void Continue()
    {
        foreach (GameObject activeInGameUIObject in activeInGameUIObjects)
            activeInGameUIObject.SetActive(true);
        
        pauseMenu.SetActive(false);
        
         ExitPauseMenuConditions();        
    }

    public void OpenScreen(GameObject screen)
    {
        foreach (Transform child  in pauseMenu.transform)
            child.gameObject.SetActive(false);
        
        screen.SetActive(true);
    }
    
    public void CloseScreen(GameObject screen)
    {
        pauseMenuLayout.SetActive(true);
        screen.SetActive(false);
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
