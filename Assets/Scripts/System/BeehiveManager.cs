using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BeehiveManager : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] GameObject leftButton;
    [SerializeField] GameObject rightButton;
    [SerializeField] Transform beehives;
    [SerializeField] float movingDistance = 13f;
    [SerializeField] float movingTime = 2f;
    [SerializeField] TextMeshProUGUI indexText;
    [SerializeField] StatusManager statusManager;

    private int index = 1;
    private float t;
    private Vector3 currentPosition;
    private Vector3 targetPosition;
    private bool canChange = true;

    private void Start()
    {
        currentPosition = beehives.position;
    }

    public void FixedUpdate()
    {
        indexText.text = ""+index;
        //t += Time.deltaTime / movingTime;
        //beehives.position = Vector2.Lerp(currentPosition, targetPosition, t);
    }

    public int GetCurrentBeeHiveIndex()
    {
        return index;
    }

    public void ResetIndex()
    {
        int lastIndex = index;
        index = 1;
        CheckButton();
        UpdateUI(lastIndex, index);
    }

    private void UpdateUI(int lastIndex, int currentIndex)
    {
        statusManager.HideStatus(lastIndex);
        statusManager.ShowStatus(currentIndex);
    }

    public void GoLeft()
    {
        if (!canChange) return;
        index--;
        CheckButton();
        animator.SetTrigger("GoLeft");
        UpdateUI(index+1, index);
    }


    public void GoRight()
    {
        if (!canChange) return;
        index++;
        CheckButton();
        animator.SetTrigger("GoRight");
        UpdateUI(index-1, index);
    }

    public void DisableChange()
    {
        canChange = false;
    }

    public void EnableChange()
    {
        canChange = true;
    }

    private void CheckButton()
    {
        if (index <= 0)
        {
            leftButton.SetActive(false);
        }
        else
        {
            leftButton.SetActive(true);
        }
        if (index >= 2)
        {
            rightButton.SetActive(false);
        }
        else
        {
            rightButton.SetActive(true);
        }
    }
}
