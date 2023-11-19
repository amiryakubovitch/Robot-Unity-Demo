using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// represents the data for rotate to command
/// </summary>
[CreateAssetMenu(fileName = "new rotate to", menuName = "Commands/RotateTo")]
public class RotateTo : Command
{
    public Vector3 Angles;

    /// <summary>
    /// rotates the executer
    /// </summary>
    /// <param name="executer">GameObject that executes the command</param>
    /// <param name="executionPrecentage">The Tick devided by the time left</param>
    protected override void CommandFunction(GameObject executer, float executionPrecentage)
    {
        executer.transform.eulerAngles = Vector3.Lerp(executer.transform.eulerAngles, Angles, executionPrecentage);
    }

    /// <summary>
    /// final rotation for float point errors 
    /// </summary>
    /// <param name="executer">GameObject that executes the command</param>
    protected override void EndFunction(GameObject executer)
    {
        executer.transform.eulerAngles = Angles;
    }
}
