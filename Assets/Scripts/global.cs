using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class global : ScriptableObject
{
    public int score = 10;
    public int highScore = 0;

    public int batKills = 0;
    public int slimeKills = 0;
    public int treesDestroyed = 0;
    public void gameReset()
    {
        score = 0;
    }
    public void fullReset()
    {
        score = 0;
        highScore = 0;
        batKills = 0;
        slimeKills = 0;
        treesDestroyed = 0;
    }
    public void highScoreChecker()
    {
        if (score > highScore)
        {
            highScore = score;
        }
    }
}
