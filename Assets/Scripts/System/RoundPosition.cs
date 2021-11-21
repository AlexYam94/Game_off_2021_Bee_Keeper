using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundPosition : MonoBehaviour
{
    public void CorrectPosition()
    {
        float x = Mathf.Round(transform.position.x);
        Vector2 position = transform.position;
        position.x = x;
        transform.position = position;
    }
}
