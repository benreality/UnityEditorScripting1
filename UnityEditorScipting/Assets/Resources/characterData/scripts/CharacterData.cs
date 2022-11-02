using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ScriptableObject = a class that is built to ease the transition of data into unity
public class CharacterData : ScriptableObject
{
    public GameObject prefab;
    public float maxHealth;
    public float maxEnergy;
    public float CritChance;
    public float Power;
    public string name;
}
