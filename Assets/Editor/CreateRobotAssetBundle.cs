using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/// <summary>
/// Creates a robot asset bundle **note in retrospec this class can create any asset bundle and not just robots 
/// </summary>
public class CreateRobotAssetBundle 
{
    /// <summary>
    /// create asset bundle from all assets that are marked to become an asset bundle
    /// </summary>
    [MenuItem("Assetes/Create robot asset bundle")]
    private static void BuildAssetBundle()
    {
        string bundleOutputPath = Application.dataPath;
        try
        {
            //build all objects marked for asset bundle with the active build targer
            BuildPipeline.BuildAssetBundles(bundleOutputPath, BuildAssetBundleOptions.None, EditorUserBuildSettings.activeBuildTarget);
        }
        catch (System.Exception e)
        {
            Debug.LogException(e); 
        }
    }
}
