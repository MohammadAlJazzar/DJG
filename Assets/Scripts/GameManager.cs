using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    public ColorManager colorManager;

    public LevelManager levelManager;

    public UIManager uiManager;

    public bool isGameOn = false;

    public ScoreManager scoreManager;
    

    private void Awake()
    {
        Instance = this;
    }
    public void StartGame()
    {
        isGameOn = true;
    }
   
    public void LoseGame()
    {
        SoundManager.Instance.PlaySound(SoundManager.Instance.lose);
        isGameOn = false;
    }

    public void WinGame()
    {
        isGameOn = false;
        uiManager.Win();
        levelManager.WinLevel();
    }


}
