using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sugar : MonoBehaviour, Interactable
{
    [SerializeField] StatusManager statusManager;
    [SerializeField] MoneyManager moneyManager;

    private string name = "Hungry";

    public void Interact(GameObject target)
    {
        BeeHive beeHive = target.GetComponent<BeeHive>();
        if (!beeHive) return;
        if (moneyManager.SpendMoney(10))
        {
            int index = beeHive.GetIndex();
            statusManager.HideStatusByName(index, name);
        }
    }
}
