
/* 网络下载WWW类。
 * WWW是Unity网络开发中使用频率非常高的一个工具类。
 * 主要提供一般HTTP访问的功能，以及动态地从网上下载图片、声音、视频资源等。
 * 主要支持的协议有： http://、
 *                  https://、
 *                  file://
 *                  ftp://(支持匿名账号)
 * 其中file:// 是访问本地文件.
 */
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WWWTest: MonoBehaviour
{
    public GameObject goCube;
    public GameObject goSphere;
    private Texture2D DownloadTextures;   // 下载的贴图.

    public Button DownLoadLocalButton;
    public Button DownLoadHttpButton;

    private void Start()
    {
        /*
         * 按下按钮时将触发UnityEvent。
        */
        // 为下载本地贴图的按钮注册点击事件
        DownLoadLocalButton.onClick.AddListener(DownLoadTexturesByWWW);
        // 为下载互联网贴图的按钮注册点击时间
        DownLoadHttpButton.onClick.AddListener(DownLoadTextureFromHTTP);
    }

    // 下载本机贴图
    public void DownLoadTexturesByWWW()
    {
        StartCoroutine("StartDownLoadTexture");
    }

    // 从互联网下载贴图
    public void DownLoadTextureFromHTTP()
    {
        StartCoroutine("StartDownLoadTexturesFromHTTP");
    }

    // 下载本机资源
    IEnumerator StartDownLoadTexture()
    {
        // 定义本机资源
        WWW loadTexture = new WWW("file://" + Application.dataPath + "/Resources/Textures/hello.jpg");
        // 等待下载
        yield return loadTexture;
        // 将下载的Texture赋值给指定的游戏对象
        goCube.GetComponent<Renderer>().material.mainTexture = loadTexture.texture;
    }

    // 从互联网下载资源
    IEnumerator StartDownLoadTexturesFromHTTP()
    {
        // 定义本机资源
        WWW loadTexture = new WWW("https://ss0.bdstatic.com/70cFuHSh_Q1YnxGkpoWK1HF6hhy/it/u=3237710877,578187982&fm=27&gp=0.jpg");
        // 等待下载
        yield return loadTexture;
        // 下载的贴图直接赋值给指定的游戏对象
        goSphere.GetComponent<Renderer>().material.mainTexture = loadTexture.texture;
    }
}
