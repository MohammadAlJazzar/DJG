using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    public Animator anim;
    public string ObstacleTag = "Obstacle";
    public MeshRenderer[] meshRenderers;
    public Tile[] tiles;

    public void Hide()
    {
        anim.SetTrigger("Hide");
        GameManager.Instance.levelManager.NextLevel();
        GameManager.Instance.scoreManager.AddScore(2);
    }

    private void Start()
    {
        for(int i=0; i< 12; i++)
        {
            switch(tiles[i].tiletype)
            {
                case TileType.Obstacle:
                    meshRenderers[i].tag = ObstacleTag;
                    meshRenderers[i].material = GameManager.Instance.colorManager.obstacleMat;
                    break;
                case TileType.Thru:
                    meshRenderers[i].gameObject.SetActive(false);
                    break;

            }
        }
        
    }
}

[System.Serializable]
public class Tile
{
    public TileType tiletype;
}
public enum TileType
{
    Normal, Obstacle, Thru
}
