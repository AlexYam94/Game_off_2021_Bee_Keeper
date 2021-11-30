using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SavingManager : MonoBehaviour
{
    [SerializeField] GameObject savingSystem;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void LoadGame(){
        StartCoroutine(LoadScene());
    }

    public IEnumerator LoadScene()
    {
        yield return SceneManager.LoadSceneAsync(1);
        GameObject.Instantiate(savingSystem);
        Destroy(gameObject);
    }

    public void TestSave()
    {
        SavingSystem.Save();
    }

    public void TestLoad()
    {
        SavingSystem.Load();
    }

}