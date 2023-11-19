
using UnityEngine;

/// <summary>
/// represents the data for move to command
/// </summary>
[CreateAssetMenu(fileName = "new move to", menuName = "Commands/MoveTo")]
public class MoveTo : Command
{
    public Vector3 Position;

    /// <summary>
    /// moves the executer
    /// </summary>
    /// <param name="executer">GameObject that executes the command</param>
    /// <param name="executionPrecentage">The Tick devided by the time left</param>
    protected override void CommandFunction(GameObject executer, float executionPrecentage)
    {
        executer.transform.position = Vector3.Lerp(executer.transform.position, Position, executionPrecentage);
    }

    /// <summary>
    /// final movemnt for float point errors 
    /// </summary>
    /// <param name="executer">GameObject that executes the command</param>
    protected override void EndFunction(GameObject executer)
    {
        executer.transform.position = Position;
    }
}
