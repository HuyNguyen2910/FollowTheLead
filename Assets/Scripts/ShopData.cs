using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopData : MonoBehaviour
{
    public static ShopData Instance;

    public List<int> explodeShop;

    private string explodeString = "exploreShop";
    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this);
        SavePrefsInt(explodeString + 0, 1);
        LoadPrefs();
    }
    public void SavePrefsInt(string name, int value)
    {
        PlayerPrefs.SetInt(name, value);
        PlayerPrefs.Save();
        LoadPrefs();
    }
    public void LoadPrefs()
    {
        //for (int index = 0; index < explodeShop.Count; index++)
        //{
        //    explodeShop[index] = index == UserData.Instance.currentExplode;
        //}

        //currentExplode = PlayerPrefs.GetInt(Define.EXPLODE_SHOP);
        //currentFloor = PlayerPrefs.GetInt(Define.FLOOR_SHOP);
        for (int index = 0; index < explodeShop.Count; index++)
        {
            explodeShop[index] = PlayerPrefs.GetInt(explodeString + index);
        }
    }
}
