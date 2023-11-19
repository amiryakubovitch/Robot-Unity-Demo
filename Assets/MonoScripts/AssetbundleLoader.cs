using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


/// <summary>
/// AssetbundleLoader Loads from a list of bundle name and prefab names prefabs from the corresponding asset bundles
/// </summary>
public class AssetbundleLoader 
{


   

    /// <summary>
    /// loads a prefab from assetbundel 
    /// </summary>
    /// <param name="bundleName"> name of the prefab to load</param>
    /// <param name="prefabName">name of the bundle to load prefab from</param>
    public static GameObject LoadPrefab (string bundleName,string prefabName)
    {
        AssetBundle bundle= LoadAssetBundle(bundleName);
        if (bundle == null)
            return null;

        GameObject objectToLoad = bundle.LoadAsset<GameObject>(prefabName);
        if(objectToLoad == null) {
            Debug.LogError("failed to load prefab " + prefabName);
            return null;
        }
        bundle.Unload(false);

        return objectToLoad;
    }

    /// <summary>
    /// loads and return an asset bundle **note i use for the assignment application.dataPath but i could add parameter for path
    /// </summary>
    /// <param name="name"> given bundle name</param>
    /// <returns>return the Asset bundle or null if failed</returns>
    public static AssetBundle LoadAssetBundle(string name)
    {
        AssetBundle bundle = AssetBundle.LoadFromFile(Path.Combine(Application.dataPath, name));
        if (bundle == null)
        {
            Debug.LogError("failed to load asset bundle");
            return null;
        }

        return bundle;
    }
}
