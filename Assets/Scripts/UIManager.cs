using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject startPanel, winPanel, losePanel;

    [Header("Text")]
    public TextMeshProUGUI scoreText;
    public void StartGame()
    {
        startPanel.SetActive(false);
        GameManager.Instance.StartGame();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Lose()
    {
        losePanel.SetActive(true);
        GameManager.Instance.LoseGame();
    }

    public void Win()
    {
        winPanel.SetActive(true);
        
    }
    private void OnEnable()
    {
        ScoreManager.UpdatedScore += ScoreManager_UpdatedScore;
    }
    void ScoreManager_UpdatedScore(int obj)
    {
        scoreText.text = obj.ToString();
    }

}
