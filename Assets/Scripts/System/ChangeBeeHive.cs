using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBeeHive : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] GameObject leftButton;
    [SerializeField] GameObject rightButton;
    [SerializeField] Transform beehives;
    [SerializeField] float movingDistance = 13f;
    [SerializeField] float movingTime = 2f;

    private int index = 1;
    private float t;
    private Vector3 currentPosition;
    private Vector3 targetPosition;

    private void Start()
    {
        currentPosition = beehives.position;
    }

    public void FixedUpdate()
    {
        //t += Time.deltaTime / movingTime;
        //beehives.position = Vector2.Lerp(currentPosition, targetPosition, t);
    }

    public void GoLeft()
    {
        index--;
        CheckButton();
        animator.SetTrigger("GoLeft");
        //currentPosition = beehives.position;
        //targetPosition = new Vector2(currentPosition.x + movingDistance, currentPosition.y);
    }

    public void GoRight()
    {
        index++;
        CheckButton();
        animator.SetTrigger("GoRight");
        //currentPosition = beehives.position;
        //targetPosition = new Vector2(currentPosition.x - movingDistance, currentPosition.y);
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
