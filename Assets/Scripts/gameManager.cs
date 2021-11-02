using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class gameManager : MonoBehaviour
{
    public global variableHandler;
    public gameManager GM;
    public runeHandler rH;
    public playerMovementHandler pMH;
    public listOfTerrain lOT;
    public List<AudioClip> selectSounds;
    public AudioSource audioSource;
    public GUISkin myGUISkin;
    public bool isPreRun = true;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        lOT.totalTreesGenerated = 0;
        lOT.terrainGenerated = 1;
        if (rH.isNewGame)
        {
            lOT.level = 1;
            rH.isNewGame = false;
            rH.inactiveRunes = new List<GameObject>(rH.defaultRunes); 
        }
        if (SceneManager.GetActiveScene().name == "runeScene")
        {
            setRunesToInactive();
        }
    }
    public void OnGUI()
    {
        GUI.skin = myGUISkin;
        if (SceneManager.GetActiveScene().name == "runeScene")
        {
            //Create the number of runes in the rune list
            int offSetRunes = 0;
            int topOffSetRunes = 0;
            foreach (GameObject runeObject in rH.inactiveRunes)
            {
                if (rH.activeRunes.Contains(runeObject))
                {
                    continue;
                }
                runeScript rS = runeObject.GetComponent<runeScript>();
                GUI.Label(new Rect(Screen.width / 8.5f +offSetRunes, Screen.height / 1.25f - 60f, 150f, 100f), rS.name);
                if (GUI.Button(new Rect(Screen.width / 7.5f + offSetRunes, Screen.height / 1.25f, 75f, 75f), new GUIContent(rS.runeMask)) && rH.activeRunes.Count < 3)
                {
                    int rand = Random.Range(0, 5);
                    audioSource.PlayOneShot(selectSounds[rand]);
                    rH.activeRunes.Add(runeObject);
                    Debug.Log("Hello There");
                } 
                offSetRunes += 150;
            }
            foreach (GameObject runeObject in rH.activeRunes)
            {
                runeScript rS2 = runeObject.GetComponent<runeScript>();
                GUI.Label(new Rect(Screen.width / 8.5f + topOffSetRunes, Screen.height / 5.25f - 60f, 150f, 100f), rS2.name);
                if (GUI.Button(new Rect(Screen.width / 7.5f + topOffSetRunes, Screen.height / 5.25f, 90f, 90f), new GUIContent(rS2.runeMask)))
                {
                    int rand = Random.Range(0, 5);
                    audioSource.PlayOneShot(selectSounds[rand]);
                    rH.activeRunes.Remove(runeObject);
                    Debug.Log("Hello There");
                }
                topOffSetRunes += 150;
            }
            if (GUI.Button(new Rect(Screen.width / 2, 200, 100f, 100f), "Play!"))
            {
                SceneManager.LoadScene("sampleScene");
            }
            GUI.Label(new Rect(20, 20, 200f, 200f), "Selected Runes");
            GUI.Label(new Rect(20, 650, 200f, 200f), "UnSelected Runes");
            GUI.Label(new Rect(Screen.height + 250, 150, 250f, 250f), "These are runes, runes will enhance your gameplay in specific ways, click on 3 of the runes you want");
        }
       }
    public void setRunesToInactive()
    {
        rH.activeRunes = new List<GameObject>();
    }
    public void gameOver()
    {
        rH.isNewGame = true;
        SceneManager.LoadScene("endScene");
    }
    public void runeAdder()
    {
        if (variableHandler.treesDestroyed >= 15 && rH.isRuneInInactiveRunesList("Major Speed Rune") == false)
        {
            rH.addRuneToInactiveRunes("Major Speed Rune");
        }
        if (variableHandler.slimeKills >= 25 && rH.isRuneInInactiveRunesList("Major Health Rune") == false)
        {
            rH.addRuneToInactiveRunes("Major Health Rune");
        }
        if (variableHandler.batKills >= 15 && rH.isRuneInInactiveRunesList("Double Axes Rune") == false)
        {
            rH.addRuneToInactiveRunes("Double Axes Rune");
        }
        if (variableHandler.highScore >= 750 && rH.isRuneInInactiveRunesList("Double Points Rune") == false)
        {
            rH.addRuneToInactiveRunes("Double Points Rune");
        }
    }
}