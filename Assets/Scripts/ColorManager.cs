using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    public Material playerMat, normalMat, obstacleMat, helixMat;

    
    public LevelColors[] levelColors;
    [HideInInspector]
    public Color splashColor;

    private void Start()
    {
        int i = Random.Range(0, levelColors.Length);

        splashColor = levelColors[i].playerColor;
        playerMat.color = splashColor;
        obstacleMat.color = levelColors[i].obstacleColor;
        normalMat.color = levelColors[i].normalColor;
        helixMat.color = levelColors[i].helixColor;

        Camera.main.backgroundColor= levelColors[i].backgroundColor;
    }
    [System.Serializable]
    public class LevelColors
    {
        public Color normalColor;
        public Color obstacleColor;
        public Color playerColor;
        public Color helixColor;
        public Color backgroundColor;
    }
}
