using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "HiveStatus")]
public class Status : ScriptableObject
{
    private int beesToChangePerDay;

    public int GetBeesToChangePerDay()
    {
        return beesToChangePerDay;
    }
}
