using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Descriptable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private string _description;
    private TextMeshProUGUI descriptionText;
    private Outline outline;

    private void Start()
    {
        descriptionText = GameObject.Find("DescriptionText").GetComponent<TextMeshProUGUI>();
        outline = GetComponent<Outline>();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        descriptionText.text = "";
        outline.enabled = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        descriptionText.text = _description;
        outline.enabled = true;
    }
}
