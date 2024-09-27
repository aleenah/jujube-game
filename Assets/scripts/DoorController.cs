using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public string nextScene;
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.CompareTag("Player"))
        {
            var olives = GameObject.FindGameObjectsWithTag("olive");
            if (olives.Length == 0) {
                UnityEngine.SceneManagement.SceneManager.LoadScene(nextScene);
            }
        }
    }
}
