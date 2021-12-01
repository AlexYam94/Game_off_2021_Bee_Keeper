using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instruction : MonoBehaviour
{
    [SerializeField] TimeManager timeManager;

    public void ShowInstruction()
    {
        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);
        timeManager.StartGame();
    }
}
