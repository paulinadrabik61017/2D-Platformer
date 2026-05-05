using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class LevelPortal : MonoBehaviour
{
    public string lvlToOpen;
    private void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene(lvlToOpen);
    }
   
  
}
