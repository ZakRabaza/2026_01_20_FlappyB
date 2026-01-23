using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] 
    private static GameManager Instance;

    [SerializeField] 
    private BirdController bird;

    [SerializeField]
    private float score;

    [SerializeField]
    private TMP_Text scoreText;
    void Awake()
    {
        Instance = this;
    }

    void OnEnable() 
    { 
        bird.OnDeath += GameOver;
        bird.Score += UpdateScore;
        
    }
    void OnDisable() 
    { 
        bird.OnDeath -= GameOver;
        bird.Score -= UpdateScore;
    }

    public void GameOver()
    {
        Debug.Log("GAME OVER");

        PlayerPrefs.SetFloat("LastScore", score); 
        float best = PlayerPrefs.GetFloat("BestScore", 0); 
        if (score > best) 
            PlayerPrefs.SetFloat("BestScore", score);



        Time.timeScale = 0f;
        SceneManager.LoadScene("02-MenuScene");
    }

    public void AddScore()
    {
        score++;
    }

    void UpdateScore()
    {
        AddScore();
        scoreText.text = "Score : " + score;
    }
}
