
using UnityEngine;

namespace TSU.SceneManager
{
    /// <summary>
    ///場景管理器:切換場景與退出遊戲 
    /// </summary>
    public class SceneManager : MonoBehaviour
    {
        [SerializeField, Range(0.1f,2.5f), Header("音效時間")]
        private float soundDuration = 2.2f;
        private string sceneNameToChange;
        // 按鈕與程式溝通的方式
        // 1. 定義公開方法
        // 2. 此腳本掛在遊戲物件上
        // 3. 按鈕上設定 On Click 事件

        /// <summary>
        /// 用場景字串名稱切換場景
        /// </summary>
        /// <param name="sceneName"></param>
        public void ChangeScene(string sceneName)
        {
            sceneNameToChange = sceneName;
            Invoke("DelayChangeScene", soundDuration);
        }
        public void DelayChangeScene()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneNameToChange);

        }
        /// <summary>
        /// 用UnityAPI結束遊戲輸出遊戲後才有效果
        /// </summary>
        public void Quit()
        {
            Invoke("DelayQuit",soundDuration);
        }
        public void DelayQuit()
        {
            
            print("離開遊戲");
            Application.Quit();
        }
    }
}

