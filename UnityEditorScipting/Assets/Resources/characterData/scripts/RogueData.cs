using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Import data from Types Script
using Types;

//Create Menu Attribute
[CreateAssetMenuAttribute(fileName = "New Rogue Data", menuName = "Character Data/Rogue")]
// CharacterData, to import all the property from CharacterData Script
public class RogueData : CharacterData

{
    // Get the property from Types Script
    public RogueWpnType wpnType;
    public RogueStrategyType strategyType;
}
