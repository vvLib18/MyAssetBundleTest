using UnityEngine;
using System.Collections;
using UnityEditor;

public class MyBuildAsset : MonoBehaviour {

    [@MenuItem("Test/Build Asset Bundles")]  // 添加菜单栏“Test”以及子菜单“Build Asset Bundles”
    // 声明一个AssetBundle创建方法。
    // 在此方法中将项目的资源采用未压缩格式打包到AssetBundle的文件夹下。
    // 需要注意的是该方法将资源打包到指定的文件夹中，该文件夹并不会自动创建，需要玩家在运行前手动创建，否则会报错！
    static void BuildAssetBundles() {
        BuildPipeline.BuildAssetBundles(Application.dataPath + "/AssetBundle", // AssetBundles的输出路径
            BuildAssetBundleOptions.UncompressedAssetBundle,                   // AssetBundles的创建选项。
            BuildTarget.StandaloneWindows64);                                  // AssetBundles的目标创建平台.
    }

   
    [MenuItem("Test/Get AssetBundle names")]
    static void GetNames()
    {   // 获取所有AssetBundle的名字
        var names = AssetDatabase.GetAllAssetBundleNames();
        foreach (var name in names)
        Debug.Log("AssetBundle: " + name);
        
    }
}
