using UnityEngine;
using System.Collections;

public class LoadAsset : MonoBehaviour {

    AssetBundle cubeBundle;
    private void OnGUI()
    {
        if (GUILayout.Button("LoadAssetBundle"))
        {
            // 加载主主资源文件 AssetBundle
            AssetBundle manifestBundle = AssetBundle.LoadFromFile(Application.dataPath + "/AssetBundle/AssetBundle");
            if (manifestBundle != null)
            {
                // AssetBundleManifest:清单中的所有assetBundle构建。
                // 加载主资源文件AssetBundle.manifest的AssetBundleManifest属性
                AssetBundleManifest manifest = (AssetBundleManifest)manifestBundle.LoadAsset("AssetBundleManifest");
                // 加载cubeb文件
                cubeBundle = AssetBundle.LoadFromFile(Application.dataPath + "/AssetBundle/cubeb");
                // 通过Prefab的名字加载预制件
                GameObject cube = cubeBundle.LoadAsset("Cubeasset") as GameObject;

                if (cube != null)
                {
                    // 实例化
                    Instantiate(cube);
                }
                StartCoroutine("WaitUnload");
            }
        }
    }

    IEnumerator WaitUnload()
    {
        yield return new WaitForSeconds(5f);
        /*
         * AssetBundle的卸载
         * 在Unity中提供了相应的方法来卸载AssetBundle,
         * 这个方法是使用一个bool参数来告诉Unity是否卸载所有的数据（包含加载的资源对象）或者只是已经下载过的被压缩好的资源数据，
         * AssetBundle.Unload(false):指释放AssetBundle文件的内存镜像，不包含Load创建的Asset内存对象.
         * AssetBundle.Unload(true):指释放那个AssetBundle文件内存镜像并销毁所有用Load创建的Asset内存对象.
         */
        cubeBundle.Unload(false);
        // cubeBundle.Unload(true);
        Debug.Log("Hello");
    }
}
