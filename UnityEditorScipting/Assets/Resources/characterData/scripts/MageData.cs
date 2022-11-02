using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Import data from Types Script
using Types;

//Create Menu Attribute
[CreateAssetMenuAttribute(fileName ="New Mage Data", menuName= "Character Data/Mage")]
// CharacterData, to import all the property from CharacterData Script
public class MageData : CharacterData
{
    // Get the property from Types Script
    public MageDmgType dmgType;
    public MageWpnType wpnType;
}
