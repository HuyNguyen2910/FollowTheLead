using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemShop : MonoBehaviour
{
    [SerializeField] private Button buyButton;
    [SerializeField] private Button useButton;
    [SerializeField] private int index;
    [SerializeField] private bool isExplodeShop;

    private void Start()
    {
        buyButton.onClick.AddListener(Buy);
        useButton.onClick.AddListener(Use);
    }
    public void Setup(bool isBought, int idx, bool isExplode)
    {
        index = idx;
        isExplodeShop = isExplode;
        buyButton.gameObject.SetActive(!isBought);
        useButton.gameObject.SetActive(isBought);
    }
    private void Buy()
    {
        if (isExplodeShop)
        {
            ShopScreen.Instance.SaveExplodeShop(index, 1);
        }
        else
        {
            ShopScreen.Instance.SaveFloorShop(index, 1);
        }
        Setup(true, index, isExplodeShop);
    }    
    private void Use()
    {
        string shop = isExplodeShop ? Define.EXPLODE_SHOP : Define.FLOOR_SHOP;
        UserData.Instance.SaveCurrentShop(shop, index);
    }    
}
