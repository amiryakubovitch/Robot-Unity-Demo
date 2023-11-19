using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Loads robot to the scene from assets bundels 
/// </summary>
public class RobotLoader : MonoBehaviour
{
    //ui refrence
    public GameObject ButtonPlaceHolder;
    //asset refrences
    public GameObject ButtonPrefab;
    public GameObject TitlePrefab;
    
    //used to calculate new button position
    private int buttonIndex = 0;
    //offsets between buttons
    private float buttonOffset = 50;

    /// <summary>
    /// a struct with a bundle and robot prefab names
    /// </summary>
    [Serializable]
    private struct AssetBundleAndPrefabNames
    {
        public string BundleName;
        public string RobotName;
    }

    [SerializeField]
    private List<AssetBundleAndPrefabNames> bundleToLoad;


    /// <summary>
    /// loads the next robot prefab from its bundle
    /// </summary>
    public void LoadNext()
    {
        if (bundleToLoad.Count == 0)
            return;

        initiateRobot(bundleToLoad[0].BundleName, bundleToLoad[0].RobotName);
        bundleToLoad.RemoveAt(0);
    }


    /// <summary>
    /// create a new robot with button for activating instructions
    /// </summary>
    /// <param name="bundleName">the name of the bundle to load from</param>
    /// <param name="prefabName">the name of the robot prefab inside it</param>
    void initiateRobot(string bundleName, string prefabName)
    {
        //get the prefab 
        GameObject robotPrefab = AssetbundleLoader.LoadPrefab(bundleName, prefabName);
        if (robotPrefab == null) {
            return;
        }

        //create the robot
        Robot robotController= Instantiate(robotPrefab).GetComponent<Robot>();
        if(robotController == null ) {
            Debug.Log("Prefab doesnt contain a rovot component");
            return;
        }

        //add title to the ui
        GameObject robotTitle = Instantiate(TitlePrefab, ButtonPlaceHolder.transform);
        robotTitle.transform.Translate(new Vector3(0, buttonIndex * buttonOffset * -1, 0));
        robotTitle.GetComponentInChildren<Text>().text = prefabName + ":";
        buttonIndex++;

        //create a button for each instruction of the robot
        for (int i = 0; i < robotController.instructionsList.Count; i++)
        {
            GameObject buttonGo = Instantiate(ButtonPrefab, ButtonPlaceHolder.transform);
            buttonGo.transform.Translate(new Vector3(0, buttonIndex * buttonOffset*-1, 0));
            Button button= buttonGo.GetComponent<Button>();
            //creating a new int var to avoid closure 
            int lambdaValue = i;
            button.onClick.AddListener(() => robotController.StartExecuteCoroutine(lambdaValue));
            buttonGo.GetComponentInChildren<Text>().text = robotController.instructionsList[i].name;
            buttonIndex++;
        }

    }
}
