using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BacteriaMedicine : MonoBehaviour, Interactable
{
    [SerializeField] StatusManager statusManager;
    [SerializeField] MoneyManager moneyManager;

    private string name = "Bacteria";

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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
