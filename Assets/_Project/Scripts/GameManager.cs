using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] 
    private static GameManager Instance;

    [SerializeField] 
    private BirdController bird;

    [SerializeField]
    private float score;
    void Awake()
    {
        Instance = this;
    }

    void OnEnable() 
    { 
        bird.OnDeath += GameOver;
        bird.Score += AddScore;
        
    }
    void OnDisable() 
    { 
        bird.OnDeath -= GameOver;
        bird.Score -= AddScore;
    }

    public void GameOver()
    {
        Debug.Log("GAME OVER");
        Time.timeScale = 0f;
    }

    public void AddScore()
    {
        score++;
    }
}
