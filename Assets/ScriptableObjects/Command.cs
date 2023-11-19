using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// represent a single command
/// </summary>
public abstract class Command : ScriptableObject
{
    public float TimeToExec=0;
    public float TickPerSeconds = 0.05f;


    /// <summary>
    /// Executes a command with a coroutine over the amount of time to execute
    /// </summary>
    /// <param name="executer">GameObject that executes the command</param>
    public virtual IEnumerator ExecuteCommand(GameObject executer)
    {
        float timeLeft = TimeToExec;
        while (timeLeft > 0)
        {
            float executionPrecentage = TickPerSeconds / timeLeft;
            CommandFunction(executer, executionPrecentage);
            timeLeft -= TickPerSeconds;
            yield return new WaitForSeconds(TickPerSeconds);
        }
        EndFunction(executer);
    }


    /// <summary>
    /// The action of the command on the executer
    /// </summary>
    /// <param name="executer">GameObject that executes the command</param>
    /// <param name="executionPrecentage">The Tick devided by the time left</param>
    protected abstract void CommandFunction(GameObject executer, float executionPrecentage);


    /// <summary>
    /// function for fixing float point errors
    /// </summary>
    /// <param name="executer">GameObject that executes the command</param>
    protected virtual void EndFunction(GameObject executer){}

}
