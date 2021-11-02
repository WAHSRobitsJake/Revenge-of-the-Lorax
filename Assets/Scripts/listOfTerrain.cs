using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class listOfTerrain : ScriptableObject
{
    public int lastTreesGenerated = 0;
    public int totalTreesGenerated = 0;
    public int level;
    public List<GameObject> terrain;
    public GameObject endTerrain;
    public GameObject endTerrainLvl2;
    public int terrainGenerated = 1;
    public GameObject randomTerrainRestrictor()
    {
        terrainGenerated++;
        if (level == 0)
        {
            int randTerrain = Random.Range(0, 2);
            return terrain[randTerrain];
        } else
        {
            int randTerrain = Random.Range(2, 5);
            return terrain[randTerrain];
        }
    }
    public int numOfTrees()
    {
    int maxTreesSpawned = 4;
        if (level == 0)
        {
            Debug.Log("Hello There");
            maxTreesSpawned = 4;
        }
        else if (level == 1)
        {
            if (terrainGenerated >= 9)
            {
                maxTreesSpawned = 1;
            }
            else if (terrainGenerated >= 6 && terrainGenerated < 9)
            {
                maxTreesSpawned = 2;
            }
            else if (terrainGenerated >= 3 && terrainGenerated < 6)
            {
                maxTreesSpawned = 3;
            }
        }
        lastTreesGenerated = maxTreesSpawned;
        totalTreesGenerated += maxTreesSpawned;
        return maxTreesSpawned;
    }
}