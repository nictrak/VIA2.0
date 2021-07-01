using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUIController : MonoBehaviour
{
    // Start is called before the first frame update
    private static Color normalColor = Color.white;
    private static Color disableColor = Color.clear;

    public Inventory Inventory;
    private ShopItem shopItem;
    public ShopItem ShopItem {
        get { return shopItem; }
        set { SetShopItem(value); }
    }

    [SerializeField]
    private Image image;
    [SerializeField]
    private Text price;
    
    private void SetShopItem(ShopItem newShopItem){
        shopItem = newShopItem;
        if(shopItem != null){
            image.sprite = shopItem.Item.Icon;
            image.color = normalColor;
            price.text = shopItem.Price.ToString();
            price.color = normalColor;
            gameObject.SetActive(true);
        } else {
            image.color = disableColor;
            price.color = disableColor;
            gameObject.SetActive(false);
        }
    }

    public void OnBuyButtonClick(){
        if(shopItem != null){
            if(shopItem.CanBuy(Inventory)){
                if(!Inventory.IsFull()){
                    shopItem.Buy(Inventory);
                } else {
                    Debug.LogError("Inventory Full");
                }
            } else {
                Debug.LogError("Cannot Buy (Not Enough Money or Out of Stock)");
            }
        }
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
