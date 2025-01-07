using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public TextMeshProUGUI scoreText;
    public AudioClip pointSound;
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
        if (audioSource != null && pointSound != null)
        {
            audioSource.PlayOneShot(pointSound);
        }
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }
    }
}
