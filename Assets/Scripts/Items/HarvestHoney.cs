using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarvestHoney : MonoBehaviour, Interactable
{
    [SerializeField] HoneyManager honeyManager;

    public void Interact(GameObject target)
    {
        BeeHive beeHive = target.GetComponent<BeeHive>();
        if (!beeHive) return;
        if (!beeHive.opened) return;
        int index = beeHive.GetIndex();
        honeyManager.HarvestHoney(index);
    }

}
