using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SavingSystem : MonoBehaviour
{
    private void Start()
    {
        Load();
    }

    public static void Save(){
        Dictionary<string, string> state = new Dictionary<string, string>();
            foreach (SaveableEntity saveable in FindObjectsOfType<SaveableEntity>())
            {
                saveable.CaptureState();
            }
    }

    public static void Load(){
        Dictionary<string, string> state = new Dictionary<string, string>();
            foreach (SaveableEntity saveable in FindObjectsOfType<SaveableEntity>())
            {
                saveable.RestoreState();
            }
    
    }
}