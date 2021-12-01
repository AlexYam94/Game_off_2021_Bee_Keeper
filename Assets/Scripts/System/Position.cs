using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position : MonoBehaviour
{
    [SerializeField] BeehiveManager beehiveManager;

    private Animator anim;
    private bool correctPosition = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if (correctPosition)
        {
            correctPosition = false;
            float x = Mathf.Round(transform.position.x);
            Vector2 position = transform.position;
            position.x = x;
            transform.position = position;
        }
    }

    public void ResetPosition()
    {
        transform.position = Vector3.zero;
        beehiveManager.ResetIndex();
    }

    public void CorrectPosition()
    {
        correctPosition = true;
    }
}
