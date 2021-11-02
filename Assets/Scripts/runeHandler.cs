using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class runeHandler : ScriptableObject
{
    public bool isNewGame = true;
    public List<GameObject> inactiveRunes;
    public List<GameObject> defaultRunes;
    public List<GameObject> unaddedRunes;
    public List<GameObject> activeRunes;

    public void addRuneToInactiveRunes(string runeName)
    {
        foreach (GameObject runeObject in unaddedRunes)
        {
            if (runeObject.GetComponent<runeScript>().name == runeName)
            {
                inactiveRunes.Add(runeObject);
                return;
            }
        }
    }
    public bool isRuneInInactiveRunesList(string runeName)
    {
        foreach (GameObject runeObject in inactiveRunes)
        {
            if (runeObject.GetComponent<runeScript>().name == runeName)
            {
                return true;
            }
        }
        return false;
    }
}