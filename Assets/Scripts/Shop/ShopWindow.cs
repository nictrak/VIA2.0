using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopWindow : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Refferences")]
    [SerializeField]
    private ShopUIController shopUIPrefab;
    [SerializeField]
    private RectTransform shopUIParent;
    [SerializeField]
    private List<ShopUIController> shopUIs;

    [SerializeField]
    private Inventory inventory;
    [SerializeField]
    private List<ShopItem> shopItems;

    private void Init(){
        shopUIParent.GetComponentsInChildren<ShopUIController>(includeInactive: true, result: shopUIs);
        UpdateShopUIs();
    }

    public void UpdateShopUIs(){
        for (int i = 0; i < shopItems.Count; i++){
            if(shopUIs.Count == i) {
                shopUIs.Add(Instantiate(shopUIPrefab, shopUIParent, false));
            } else if (shopUIs[i] == null) {
                shopUIs[i] = Instantiate(shopUIPrefab, shopUIParent, false);
            }

            shopUIs[i].Inventory = inventory;
            shopUIs[i].ShopItem = shopItems[i];
        }

        for (int i = shopItems.Count; i < shopUIs.Count; i++){
            shopUIs[i].ShopItem = null;
        }
    }

    private void OnValidate() {
        Init();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
