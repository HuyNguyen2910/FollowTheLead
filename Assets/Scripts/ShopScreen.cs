using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScreen : MonoBehaviour
{
    public static ShopScreen Instance;

    [SerializeField] private List<ItemShop> itemExplodeShops;
    [SerializeField] private List<ItemShop> itemFloorShops;
    [SerializeField] private List<int> explodeShop;
    [SerializeField] private List<int> floorShop;

    private string explodeString = "exploreShop";
    private string floorString = "floorShop";
    private void Awake()
    {
        Instance = this;
        SaveExplodeShop(0, 1);
        SaveFloorShop(0, 1);
        //LoadPrefs();
    }
    public void SaveExplodeShop(int index, int value)
    {
        //SavePrefsInt(explodeString + index, value);
        PlayerPrefs.SetInt(explodeString + index, value);
        PlayerPrefs.Save();
        for (int i = 0; i < explodeShop.Count; i++)
        {
            explodeShop[i] = PlayerPrefs.GetInt(explodeString + i);
            itemExplodeShops[i].Setup(Convert.ToBoolean(explodeShop[i]), i, true);
        }
        //LoadPrefs();
    }
    public void SaveFloorShop(int index, int value)
    {
        //SavePrefsInt(floorString + index, value);
        PlayerPrefs.SetInt(floorString + index, value);
        PlayerPrefs.Save();
        for (int i = 0; i < floorShop.Count; i++)
        {
            floorShop[i] = PlayerPrefs.GetInt(floorString + i);
            itemFloorShops[i].Setup(Convert.ToBoolean(floorShop[i]), i, false);
        }
    }
    //public void SavePrefsInt(string name, int value)
    //{
    //    PlayerPrefs.SetInt(name, value);
    //    PlayerPrefs.Save();
    //    LoadPrefs();
    //}
    //public void LoadPrefs()
    //{
    //    for (int index = 0; index < explodeShop.Count; index++)
    //    {
    //        explodeShop[index] = PlayerPrefs.GetInt(explodeString + index);
    //    }
    //    for (int index = 0; index < floorShop.Count; index++)
    //    {
    //        floorShop[index] = PlayerPrefs.GetInt(floorString + index);
    //    }
    //    SetupItemShop();
    //}
    //private void SetupItemShop()
    //{
    //    for (int index = 0; index < itemExplodeShops.Count; index++)
    //    {
    //        itemExplodeShops[index].Setup(Convert.ToBoolean(explodeShop[index]), index, true);
    //    }
    //    for (int index = 0; index < itemFloorShops.Count; index++)
    //    {
    //        itemFloorShops[index].Setup(Convert.ToBoolean(floorShop[index]), index, false);
    //    }
    //}
}
