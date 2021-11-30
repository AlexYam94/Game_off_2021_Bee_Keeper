using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BeeHive : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Texture2D inspectableCursor;
    [SerializeField] Texture2D uninspectableCursor;
    [SerializeField] StatusManager statusManager;
    [SerializeField] int index;

    [SerializeField] Sprite beehiveSprite;
    [SerializeField] Sprite beehiveOpenedSprite;

    public bool opened { get; set; } = false;
    public bool paralyzed { get; set; } = false;

    private void Update()
    {
    }

    public int GetIndex()
    {
        return index;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (opened)
        {
            statusManager.InspectStatus(index);
        }
    }

    public void OpenBeehive()
    {
        if (opened) return;
        opened = true;
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        if (!renderer) return;
        renderer.sprite = beehiveOpenedSprite;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        UpdateCursor();
    }

    public void UpdateCursor()
    {
        if (opened)
        {
            Cursor.SetCursor(inspectableCursor, Vector2.zero, CursorMode.Auto);
        }
        else
        {
            Cursor.SetCursor(uninspectableCursor, Vector2.zero, CursorMode.Auto);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
