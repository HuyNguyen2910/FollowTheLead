using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserData : MonoBehaviour
{
    public static UserData Instance;

    public int currentExplode;
    public int currentFloor;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this);
    }
    public void SavePrefsInt(string name, int value)
    {
        PlayerPrefs.SetInt(name, value);
        PlayerPrefs.Save();
        LoadPrefs();
    }
    public void LoadPrefs(Action act = null)
    {
        currentExplode = PlayerPrefs.GetInt(Define.EXPLODE_SHOP);
        currentFloor = PlayerPrefs.GetInt(Define.FLOOR_SHOP);
        act?.Invoke();
    }
}
