using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// Controls the robot behaviour 
/// </summary>
public class Robot : MonoBehaviour
{
    /// <summary>
    /// the tickrate of the robot per sec(how long will it wait in a courotine
    /// </summary>
    public float CalculateEverySec = 0.05f;

    //a list of instructions
    [SerializeField]
    public List<Instruction> instructionsList;

    private Coroutine currentInstruction;

    /// <summary>
    /// starts an instarction coroutine by index (if none is already running)
    /// </summary>
    /// <param name="instructionIndex"></param>
    public void StartExecuteCoroutine(int instructionIndex)
    {
        if(instructionIndex >= 0 && instructionIndex < instructionsList.Count)
        {
            if (currentInstruction != null)
            {
                //i could also stop the current one and start the new one with stopCoroutine()
                return;
            }
            currentInstruction=StartCoroutine(ExecuteInstruction(instructionIndex));
        }
    }

    /// <summary>
    /// courotine that iterate all the command in a given instruction index and calls the corresponding courotine ( and wait for it to finish)
    /// </summary>
    IEnumerator ExecuteInstruction(int instructionIndex)
    {
        foreach(Command command in instructionsList[instructionIndex].CommandsList)
        {
            yield return StartCoroutine(command.ExecuteCommand(gameObject));

        }

        currentInstruction = null;
    }

}
