using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Import data from Types Script
using Types;

//Create Menu Attribute
[CreateAssetMenuAttribute(fileName = "New Warrior Data", menuName = "Character Data/Warrior")]
// CharacterData, to import all the property from CharacterData Script
public class WarriorData : CharacterData
{
    // Get the property from Types Script
    public WarriorClassType classType;
    public WarriorWpnType wpnType;
}
