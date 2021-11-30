using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParasiteMedicine : MonoBehaviour, Interactable
{
    [SerializeField] StatusManager statusManager;
    [SerializeField] MoneyManager moneyManager;

    private string name = "Parasite";

    public void Interact(GameObject target)
    {
        BeeHive beeHive = target.GetComponent<BeeHive>();
        if (!beeHive) return;
        if (moneyManager.SpendMoney(15))
        {
            int index = beeHive.GetIndex();
            statusManager.HideStatusByName(index, name);
        }
    }

}
