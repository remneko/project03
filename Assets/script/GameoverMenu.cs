using UnityEngine;
using UnityEngine.SceneManagement;

namespace Mui
{
    public class GameoverMenu : MonoBehaviour
    {
        public void Restart()
        {
            SceneManager.LoadScene("�C������");
        }

        public void Continue()
        {
            SceneManager.LoadScene("�C����������");
        }

        private void option()
        {
            
        }

        public void Quit()
        {
            SceneManager.LoadScene("�}�l�e��");
            //Application.Quit();
            //EditorApplication.isPlaying =false;
        }
    }

}
