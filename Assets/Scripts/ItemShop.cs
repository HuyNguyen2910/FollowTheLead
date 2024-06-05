using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemShop : MonoBehaviour
{
    [SerializeField] private Button buyButton;
    [SerializeField] private Button useButton;
    [SerializeField] private TextMeshProUGUI useText;
    [SerializeField] private int index;
    [SerializeField] private bool isExplodeShop;

    private string useString = "Use";
    private string usingString = "Using";

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
        SetIsUsing();
    }
    public void SetIsUsing()
    {
        if ((isExplodeShop && UserData.Instance.currentExplode == index) || (!isExplodeShop && UserData.Instance.currentFloor == index))
        {
            SetUsing(true);
        }
        else
        {
            SetUsing(false);
        }
    }    
    private void SetUsing(bool isUsing)
    {
        useText.text = isUsing ? usingString : useString;
        useButton.interactable = isUsing ? false : true;
    }
    private void Buy()
    {
        if (isExplodeShop)
        {
            ShopScreen.Instance.BuyExplodeShop(index, 1);
        }
        else
        {
            ShopScreen.Instance.BuyFloorShop(index, 1);
        }
        //Setup(true, index, isExplodeShop);
    }    
    private void Use()
    {
        string shop = isExplodeShop ? Define.EXPLODE_SHOP : Define.FLOOR_SHOP;
        UserData.Instance.SaveCurrentShop(shop, index);
        //Setup(true, index, isExplodeShop);
        if (isExplodeShop)
        {
            ShopScreen.Instance.GetExplodeShop();
        }
        else
        {
            ShopScreen.Instance.GetFloorShop();
        }
    }    
}
