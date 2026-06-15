using UnityEngine;
using UnityEngine.SceneManagement; // Ta linijka jest wymagana do zmieniania scen!
public class MainMenu : MonoBehaviour
{
    // Funkcja, któr¹ wywo³amy po klikniêciu przycisku
    public void LoadLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}