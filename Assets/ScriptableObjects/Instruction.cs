using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents a list of objects that inherit Command class
/// </summary>
[CreateAssetMenu(fileName = "New Instructions", menuName = "Create Instructions")]
public class Instruction : ScriptableObject
{
    [SerializeField]
    public List<Command> CommandsList = new List<Command>();
}
