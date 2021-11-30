using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiveTool : MonoBehaviour, Interactable
{
    public void Interact(GameObject target)
    {
        //OpenBeeHive
        BeeHive beeHive = target.GetComponent<BeeHive>();
        if (beeHive)
        {
            beeHive.OpenBeehive();
            beeHive.UpdateCursor();
        }
    }
}
