using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terrainChecker : MonoBehaviour
{
    public listOfTerrain lOT;
    public Vector3 position;
    public Transform treesParent;
    public GameObject tree;
    public void Start()
    {
        int numOfTreesToSpawn = lOT.numOfTrees();
        Debug.Log("Number of Trees to spawn: "+numOfTreesToSpawn);
        Transform[] treePos = treesParent.gameObject.GetComponentsInChildren<Transform>();
        List<Transform> treePosActual = new List<Transform>(treePos);
        treePosActual.Remove(treesParent);
        for (int i = 0; i < numOfTreesToSpawn; i++) {
            int randomTreePos = Random.Range(0, treePosActual.Count);
            Instantiate(tree, treePosActual[randomTreePos]);
            treePosActual.RemoveAt(randomTreePos);
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        position.x = this.gameObject.transform.position.x;
        if (other.gameObject.CompareTag("player") && lOT.terrainGenerated != 10) {   
            Instantiate(lOT.randomTerrainRestrictor(), new Vector3 (position.x + 16f, 0.0f, 0.0f), Quaternion.identity);
        } else if (other.gameObject.CompareTag("player") && lOT.terrainGenerated == 10) {
            if (lOT.level == 1)
            {
                Instantiate(lOT.endTerrain, new Vector3(position.x + 16f, 0.0f, 0.0f), Quaternion.identity);
            }
            else if (lOT.level > 1 && lOT.level < 3)
            {
                Instantiate(lOT.endTerrainLvl2, new Vector3(position.x + 16f, 0.0f, 0.0f), Quaternion.identity);
            }
        }
        if (other.gameObject.CompareTag("player"))
        {
            Destroy(this.gameObject.GetComponent<BoxCollider2D>());
        }
    }
}