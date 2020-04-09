using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuManager : MonoBehaviour
{
    public GameObject PanelLoading;//讀取面板
    public Text LoadingText;//讀取文字
    public Image LoadingImg;//讀取Bar條圖片
    /// <summary>
    /// 開始載入遊戲場景
    /// </summary>
    public void StartLoading()
    {
        print("開始載入...");
        PanelLoading.SetActive(true);//開啟讀取面板
        //SceneManager.LoadScene("關卡1");
        StartCoroutine(Loading());
    }
    /// <summary>
    /// 載入畫面的讀取
    /// </summary>
    /// <returns></returns>
    public IEnumerator Loading()
    {
        AsyncOperation Ao = SceneManager.LoadSceneAsync("關卡1");
        Ao.allowSceneActivation = false;//關閉自動載入場景
        while (Ao.progress < 1)
        {
        print("關卡進度" + Ao.progress);yield return null;
        LoadingText.text = Ao.progress /0.9f *100 +"%";//控制文字內容
        LoadingImg.fillAmount = Ao.progress /0.9f;//控制讀取條填滿
            if (Ao.progress == 0.9f) Ao.allowSceneActivation = true;
        }
    }
}
