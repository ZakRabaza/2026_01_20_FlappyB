using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text lastScoreText; 
    [SerializeField] private TMP_Text bestScoreText;

    void Start() 
    {
        
        float last = PlayerPrefs.GetFloat("LastScore", 0); 
        float best = PlayerPrefs.GetFloat("BestScore", 0);
        lastScoreText.text = "Last Score : " + last;
        bestScoreText.text = "Best Score : " + best;
        Debug.Log("lastScoreText = " + lastScoreText);
        Debug.Log("bestScoreText = " + bestScoreText);
    }
    public void PlayGame() 
    { 
        Time.timeScale = 1f;
        SceneManager.LoadScene("01-MainScene"); 
    }
}
