using System.Collections;
using UnityEngine;

/// <summary>
/// represents the data for change color command
/// </summary>
[CreateAssetMenu(fileName = "new color change", menuName = "Commands/ChangeColor")]
public class ColorChange : Command
{
    public Color ColorToChange;

    /// <summary>
    /// Override of ExecuteCommand that changes the color of the executer ( overriden for break on error ) 
    /// </summary>
    /// <param name="executer">the gameobject to change color to</param>
    public override IEnumerator ExecuteCommand(GameObject executer)
    {
        MeshRenderer mr = executer.GetComponent<MeshRenderer>();
        if (mr == null)
            yield break;

        float timeLeft = TimeToExec;
        while (timeLeft > 0)
        {
            mr.material.color = Color.Lerp(mr.material.color, ColorToChange, TickPerSeconds / timeLeft);
            timeLeft -= TickPerSeconds;
            yield return new WaitForSeconds(TickPerSeconds);
        }
        mr.material.color = ColorToChange;
    }


    //empty necessary override 
    protected override void CommandFunction(GameObject executer, float executionPrecentage) { }

}
