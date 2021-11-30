using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : MonoBehaviour, Interactable
{
    [SerializeField] StatusManager statusManager;
    [SerializeField] MoneyManager moneyManager;

    private string name = "DeadQueen";

    public void Interact(GameObject target)
    {
        BeeHive beeHive = target.GetComponent<BeeHive>();
        if (!beeHive) return;
        if (moneyManager.SpendMoney(40))
        {
            int index = beeHive.GetIndex();
            statusManager.HideStatusByName(index, name);
        }
    }
}
