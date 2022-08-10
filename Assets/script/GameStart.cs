using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Mui
{ 
    public class GameStart : MonoBehaviour
    {
        [SerializeField, Header("開始按鈕")]
        private Button btnBattle;
        [SerializeField, Header("離開按鈕")]
        private Button btnBattle2;

        private void Start()
        {
            btnBattle.GetComponent<Button>().onClick.AddListener(OnClick1);
            btnBattle2.GetComponent<Button>().onClick.AddListener(OnClick2);
        }

        private void OnClick1()
        {
            SceneManager.LoadScene("遊戲玩法說明");
        }
        private void OnClick2()
        {
            Application.Quit();
            
        }

    }
}

