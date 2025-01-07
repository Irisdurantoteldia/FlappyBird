using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    public GameObject startMenu;
    public GameObject inGameMenu;
    public GameObject gameOverMenu;
    public TextMeshProUGUI scoreText;
    
    // Sons públics per assignar-los des de l'inspector
    public AudioClip gameOverSound; 
    public AudioClip pointSound; // Sonido del punt
    public AudioClip backgroundMusic; // Música de fons
    private AudioSource audioSource;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayBackgroundMusic(); // Reproducir música de fons en iniciar el joc
        ShowStartMenu();
    }

    public void ShowStartMenu()
    {
        startMenu?.SetActive(true);
        inGameMenu?.SetActive(false);
        gameOverMenu?.SetActive(false);
        Time.timeScale = 0f;
    }

    public void HideStartMenu()
    {
        startMenu?.SetActive(false);
        Time.timeScale = 1f;
    }

    public void StartGame()
    {
        inGameMenu?.SetActive(true);
    }

    public void ShowGameOverMenu()
    {
        inGameMenu?.SetActive(false);
        gameOverMenu?.SetActive(true);
        if (scoreText != null) scoreText.text = GameManager.Instance.score.ToString();
        Time.timeScale = 0f;

        if (audioSource != null && gameOverSound != null)
        {
            audioSource.PlayOneShot(gameOverSound); // Reproducir sonido de Game Over
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void HideGameOverMenu()
    {
        gameOverMenu?.SetActive(false);
        Time.timeScale = 1f;
    }

    public void PlayPointSound()
    {
        if (audioSource != null && pointSound != null)
        {
            audioSource.PlayOneShot(pointSound); // Reproducir sonido de Punt
        }
    }

    public void PlayBackgroundMusic()
    {
        if (audioSource != null && backgroundMusic != null)
        {
            audioSource.loop = true; // Loop per la música de fons
            audioSource.clip = backgroundMusic;
            audioSource.Play();
        }
    }

    void Update()
    {
        if (startMenu.activeSelf && (Input.GetKeyDown(KeyCode.X) || Input.GetMouseButtonDown(0)))
        {
            HideStartMenu();
            StartGame();
        }
        else if (gameOverMenu.activeSelf && (Input.GetKeyDown(KeyCode.X) || Input.GetMouseButtonDown(0)))
        {
            RestartGame();
        }
    }
}
