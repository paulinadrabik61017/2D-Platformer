using UnityEngine;
using UnityEngine.SceneManagement; // Wymagane do zmiany scen
public class WinZone : MonoBehaviour
{
    [Header("Nazwa sceny koñcowej")]
    public string winSceneName = "You Win";
    // Funkcja uruchomi siê automatycznie, gdy postaæ wejdzie w ten klocek
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Sprawdzamy, czy obiekt, który nas dotkn¹³, to gracz (szukamy tagu "Player")
        if (collision.gameObject.CompareTag("Player"))
        {
            // £adujemy scenê z wygran¹
            SceneManager.LoadScene(winSceneName);
        }
    }
}