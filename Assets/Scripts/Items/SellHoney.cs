using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class SellHoney : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] HoneyManager honeyManager;
    [SerializeField] MoneyManager moneyManager;

    public void OnPointerClick(PointerEventData eventData)
    {
        moneyManager.SellHoney(honeyManager.GetHoneyAmount());
        honeyManager.ClearHoney();
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
