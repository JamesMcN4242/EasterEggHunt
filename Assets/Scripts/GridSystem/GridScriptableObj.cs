﻿////////////////////////////////////////////////////////////
/////   GridScriptableObj.cs
/////   James McNeil - 2020
////////////////////////////////////////////////////////////

using UnityEngine;

[CreateAssetMenu(fileName = "GridData", menuName = "ScriptableObjects/GridData", order = 0)]
public class GridData : ScriptableObject
{
    [Range(1, 50)] public int m_columns;
    [Range(1, 50)] public int m_rows;

    public string m_buttonFormat = string.Empty;
}
