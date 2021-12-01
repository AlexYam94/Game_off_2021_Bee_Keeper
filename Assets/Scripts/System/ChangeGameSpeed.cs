
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGameSpeed : MonoBehaviour
{
    [SerializeField] GameObject normalSpeedIcon;
    [SerializeField] GameObject accelerateSpeedIcon;

    private bool isAccelerated = false;
    public void ToggleAccelerate()
    {
        if (!isAccelerated)
        {
            accelerateSpeedIcon.SetActive(true);
            normalSpeedIcon.SetActive(false);
            Time.timeScale = 3 ;
            isAccelerated = true;
        }
        else
        {
            accelerateSpeedIcon.SetActive(false);
            normalSpeedIcon.SetActive(true);
            Time.timeScale = 1;
            isAccelerated = false;
        }
    }

    public void PauseGame()
    {
        accelerateSpeedIcon.SetActive(false);
        normalSpeedIcon.SetActive(true);
        Time.timeScale = 0;
        isAccelerated = true;

    }
}
