using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]

public class PauseMenuScript : MonoBehaviour
{
    
    private CanvasGroup canvasGroup;
    
    public void Setup(float time)
    {
        gameObject.SetActive(true);
    }
    
    void Start()
    {
        
        canvasGroup = GetComponent<CanvasGroup>();
         
    }

    public void Resume() 
    {
                Time.timeScale = 1f;
                canvasGroup.interactable = false; canvasGroup.blocksRaycasts = false; canvasGroup.alpha = 0f;
                AudioListener.volume = 1;
    }

    public void MuteAllSound()
    {
        AudioListener.volume = 0;
    }

    public void UnMuteAllSound()
    {
        AudioListener.volume = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp (KeyCode.Escape)) 
        {
            if (canvasGroup.interactable) 
            {
                Time.timeScale = 1f;
                canvasGroup.interactable = false; canvasGroup.blocksRaycasts = false; canvasGroup.alpha = 0f;
                AudioListener.volume = 1;
            } else {
                Time.timeScale = 0f;
                canvasGroup.interactable = true; canvasGroup.blocksRaycasts = true; canvasGroup.alpha = 1f;
                AudioListener.volume = 0;
            } 
        }
    }
}
