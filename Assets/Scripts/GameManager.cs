using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public TextMeshProUGUI scoreText;
    public AudioClip pointSound; // Sonido para cada punto agregado
    private AudioSource audioSource;
    public int score = 0;

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
        UpdateScoreText();
    }

    public void AddScore(int value)
    {
        score += value;
        UpdateScoreText();
        // Reproducir el sonido de punto cada vez que se suma un punto
        audioSource.PlayOneShot(pointSound);
    }

    void UpdateScoreText()
    {
        scoreText.text = score.ToString();
    }
}
