using UnityEngine;
using UnityEngine.SceneManagement;

namespace Mui
{
    public class GameoverMenu : MonoBehaviour
    {
        public void Restart()
        {
            SceneManager.LoadScene("遊戲場景");
        }

        public void Continue()
        {
            SceneManager.LoadScene("遊戲場景王關");
        }

        private void option()
        {
            
        }

        public void Quit()
        {
            SceneManager.LoadScene("開始畫面");
            //Application.Quit();
            //EditorApplication.isPlaying =false;
        }
    }

}
