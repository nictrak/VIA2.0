using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaterialUIController : MonoBehaviour
{
    private static Color normalColor = Color.white;
    private static Color normalTextColor = Color.black;
    private static Color disableColor = Color.clear;

    private Inventory _inventory;

    [SerializeField]
    private Image image;
    [SerializeField]
    private Text amountRequire;
    [SerializeField]
    private Text amountCurrent;

    [SerializeField]
    private ItemAndAmount _material;

    public ItemAndAmount Material {
        get { return _material; }
        set { SetMaterialItem(value); }
    }

    public Inventory Inventory {
        get { return _inventory; }
        set { _inventory = value; }
    }

    private void SetMaterialItem(ItemAndAmount newMaterial){
        _material = newMaterial;
        SetUI();
    }

    public void SetNull(){
        image.color = disableColor;
        amountRequire.color = disableColor;
        amountCurrent.color = disableColor;
        gameObject.SetActive(false);
    }

    private void SetUI(){
        if(_material.Item != null && _material.Amount > 0){
            image.sprite = _material.Item.Icon;
            image.color = normalColor;
            amountRequire.text = _material.Amount.ToString();
            amountRequire.color = normalTextColor;
            amountCurrent.text = _inventory.ItemCount(_material.Item).ToString();
            amountCurrent.color = normalTextColor;
            gameObject.SetActive(true);
        } else {
            SetNull();
        }
    }

    // Start is called before the first frame update
    void Update()
    {
        SetUI();
    }

    // Update is called once per frame
    private void OnValidate()
    {
        SetUI();
    }
}
