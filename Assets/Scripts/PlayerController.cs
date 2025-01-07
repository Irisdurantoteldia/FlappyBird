using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10f; // Fuerza del salto
    public float maxRotationAngle = 30f; // Ángulo máximo de rotación
    private bool isDead = false;
    private Rigidbody2D rb;
    public Animator animator;
    
    // Sons públics per assignar-los des de l'inspector
    public AudioSource audioSource; // Referència a l'AudioSource
    public AudioClip pointSound;    // Clip de so per al punt
    public AudioClip gameOverSound; // Sonido per la mort

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); // Obtener el component Animator
        audioSource = GetComponent<AudioSource>(); // Obtener el component AudioSource
    }

    void Update()
    {
        if (!isDead)
        {
            // Saltar si es prem el ratolí o la tecla espai
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            {
                Flap();
            }
        }

        // Si el jugador està mort, permet reiniciar el joc amb "R"
        if (isDead && Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }

    void FixedUpdate()
    {
        // Ajustar la rotació del jugador
        float rotationZ = Mathf.Clamp(rb.velocity.y * 2f, -maxRotationAngle, maxRotationAngle);
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
    }

    void Flap()
    {
        rb.velocity = Vector2.zero;
        rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("Ground"))
        {
            Die();
            if (audioSource != null && gameOverSound != null)
            {
                audioSource.PlayOneShot(gameOverSound); // Reproducir sonido de Game Over
            }
            MenuManager.Instance.ShowGameOverMenu();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Point"))
        {
            GameManager.Instance.AddScore(1);
            MenuManager.Instance.PlayPointSound(); // Reproducir el sonido de punt
        }
    }

    void Die()
    {
        isDead = true;
        animator.SetTrigger("IsDead");
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
    }

    void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
