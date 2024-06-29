using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerFollowTheLead : MonoBehaviour
{
    private string triggerString = "Explore";
    private bool isLoose = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == triggerString && !isLoose)
        {
            Debug.Log("Boom!");

            LoadingScene.Instance.ReStartNewGame();
            isLoose = true;
        }
    }
}
