
/*打包资源文件*/
using UnityEngine;
using System.Collections;
using UnityEditor;

public class SelectedAsset : Editor {
    
    [MenuItem("Test/输出选中的游戏对象的名字")]
    static void CreateAssetBundlesSinglePackage()
    {
        // 获取在Project视图中选择的所有游戏对象
        // Selection：在编辑器中访问所选择的对象
        // GetFiltered:返回按类型和模式过滤的当前选择。
        // DeepAssets:如果所选内容包含文件夹，则还包括文件层次结构中该文件夹内的所有资产和子文件夹。
        Object[] SelectedAsset = Selection.GetFiltered(typeof(Object), SelectionMode.DeepAssets);

        // 创建"StreamingAssets"目录

        // 遍历所有的游戏对象
        foreach (Object obj in SelectedAsset)
        {
            Debug.Log("Select Name: " + obj.name);
        }

    }
	
}
