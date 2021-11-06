using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public GameObject startLevel;
    public GameObject goalPrefab;

    public GameObject[] levels;

    public int maxOnScreen = 10;
    public int firstSpawn = 5;  
    public float distance = 5;
    public Transform Helix;
    Vector3 spawnPos;

    List<GameObject> levelsSpawnd = new List<GameObject>();
    int levelsSpawndCount = 0;

    // slider
    private const string currentLevelStr = "CurrentLevel";
    public int currentLevel;
    public int increaseAmount = 4;
    public int startAmount = 5;
    public int levelStages = 0;
    int stageOn = 0;

    int nextLevel;
    
    [Header("Slider")]
    public TextMeshProUGUI currentText;
    public TextMeshProUGUI nextText;
    public Slider levelSlider;

    private void Awake()
    {
        currentLevel = PlayerPrefs.GetInt(currentLevelStr, 1);
        nextLevel = currentLevel + 1;
        levelStages = startAmount + (increaseAmount * currentLevel);
        SetSliderValues();
    }
    void SetSliderValues()
    {
        levelSlider.maxValue = levelStages;
        levelSlider.value = 0;
        currentText.text = currentLevel.ToString();
        nextText.text = nextLevel.ToString();



    }

    private void Start()
    {
        for (int i=0; i< firstSpawn; i++)
        {
            SpawnLevel();
        }

     }
    void SpawnLevel()
    {
        GameObject newLevel;

        if (levelsSpawndCount == 0)
        {
            newLevel = Instantiate(startLevel, spawnPos, Quaternion.identity);
        }
        else if (levelsSpawndCount <= levelStages)
        {
            newLevel = Instantiate(levels[Random.Range(0, levels.Length)], spawnPos, Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0)));
        }
        else if (levelsSpawndCount == levelStages+1)
        {
            newLevel = Instantiate(goalPrefab, spawnPos,Quaternion.identity);
        }
        else
        {
            return;
        }
        
        newLevel.transform.SetParent(Helix, true);
        spawnPos.y -= distance;

        levelsSpawnd.Add(newLevel);
        levelsSpawndCount++;

        if(levelsSpawndCount > maxOnScreen)
        {
            Destroy(levelsSpawnd[0]);
            levelsSpawnd.RemoveAt(0);
        }

    }

    public void NextLevel()
    {
        SpawnLevel();
        AddPoint();
    }

    void AddPoint()
    {
        stageOn++;
        levelSlider.value = stageOn;
    }

    public void WinLevel()
    {
        PlayerPrefs.SetInt(currentLevelStr, currentLevel);
    }


    

}
