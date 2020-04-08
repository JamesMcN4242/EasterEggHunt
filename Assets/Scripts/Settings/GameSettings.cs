////////////////////////////////////////////////////////////
/////   GameSettings.cs
/////   James McNeil - 2020
////////////////////////////////////////////////////////////

using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "ScriptableObjects/GameSettings", order = 0)]
public class GameSettings : ScriptableObject
{
    public int m_eggsToFind = 5;
}
