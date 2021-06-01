using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IPointerClickHandler , IDragHandler, IBeginDragHandler, IEndDragHandler, IDropHandler
{

    public event Action<ItemSlot> OnRightClickEvent;
    public event Action<ItemSlot> OnBeginDragEvent;
    public event Action<ItemSlot> OnEndDragEvent;
    public event Action<ItemSlot> OnDragEvent;
    public event Action<ItemSlot> OnDropEvent;

    private static Color normalColor = Color.white;
    private static Color disableColor = Color.clear;
    

    [SerializeField]
    private Image image;

    private Item _item;

    public Item Item {
        get { return _item; }

        set {

            _item = value;
            if(_item == null){
                image.color = disableColor;
            } else {
                image.sprite = _item.Icon;
                image.color = normalColor;
            }
        }
    }

    protected virtual void OnValidate()
    {
        if (image == null)
            image = GetComponent<Image>();
    }

    public virtual bool CanReceiveItem(Item item)
    {
        return true;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData != null && eventData.button == PointerEventData.InputButton.Right)
        {
            OnRightClickEvent(this);
        }
    }

    Vector2 originalPosition;

    public void OnBeginDrag(PointerEventData eventData){
        if(eventData != null)
        {
            OnBeginDragEvent(this);
        }
    }

    public void OnEndDrag(PointerEventData eventData){
        if(eventData != null)
        {
            OnEndDragEvent(this);
        }
    }

    public void OnDrag(PointerEventData eventData){
        if(eventData != null)
        {
            OnDragEvent(this);
        }
    }

    public void OnDrop(PointerEventData eventData){
        if(eventData != null)
        {
            OnDropEvent(this);
        }
    }

}
