using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScoreManager : MonoBehaviour
{
    public int score;
    
    // kkkk
    public static event Action<int> UpdatedScore = delegate { };

    private void Start()
    {
        Reset();
    }
    private void Reset()
    {
        score = 0;
        UpdatedScore(score);
    }
    public void AddScore(int amount)
    {
        SoundManager.Instance.PlaySound(SoundManager.Instance.score);
        score += amount;
        UpdatedScore(score);
    }
}
