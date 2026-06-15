using UnityEngine;
public class Trampolinee : MonoBehaviour
{
    [Header("Ustawienia Trampoliny")]
    public float bounceForce = 15f; // Si³a wybicia w górê
                                    // Funkcja uruchamia siê automatycznie, gdy coœ dotknie klocka
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Sprawdzamy, czy obiekt, który na nas skoczy³, ma Rigidbody2D (czyli czy to postaæ)
        Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            // Resetujemy prêdkoœæ pionow¹ postaci, ¿eby zawsze wybija³a siê tak samo mocno...
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);

            // ...i dodajemy potê¿ny impuls w górê!
            rb.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);
        }
    }
}