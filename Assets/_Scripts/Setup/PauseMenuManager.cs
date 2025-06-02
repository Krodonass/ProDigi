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

    [SerializeField] private Transform playerTransform;

    private void Start()
    {
        pauseMenu.SetActive(false);            
        pauseMenuLayout.SetActive(true);
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
