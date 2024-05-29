using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    [SerializeField] private GameObject explode;
    [SerializeField] private Collider trigger;
    public void CheckSafePos(bool isSafe)
    {
        trigger.enabled = !isSafe;
        explode.SetActive(!isSafe);
    }
}
