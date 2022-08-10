using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Mui
{
    public class difficultyLevel : MonoBehaviour
    {
        [SerializeField, Header("遊戲場景")]
        private Button btnBattle;
        [SerializeField, Header("遊戲場景困難")]
        private Button btnBattle2;
        [SerializeField, Header("遊戲場景惡夢")]
        private Button btnBattle3;
        [SerializeField, Header("開始畫面")]
        private Button btnBattle4;
        [SerializeField, Header("升級介紹")]
        private Button btnBattle5;
        [SerializeField, Header("玩法介紹")]
        private Button btnBattle6;
        public GameObject setActive01;
        public GameObject setActive02;

        private void Start()
        {
            btnBattle.GetComponent<Button>().onClick.AddListener(Normal);
            btnBattle2.GetComponent<Button>().onClick.AddListener(Difficult);
            btnBattle3.GetComponent<Button>().onClick.AddListener(nightmare);
            btnBattle4.GetComponent<Button>().onClick.AddListener(back);
            btnBattle5.GetComponent<Button>().onClick.AddListener(Levelup);
            btnBattle6.GetComponent<Button>().onClick.AddListener(back2);
            setActive01.SetActive(true);
            setActive02.SetActive(false);
        }

        public void Normal()
        {
            SceneManager.LoadScene("遊戲場景");
        }
        public void Difficult()
        {
            SceneManager.LoadScene("遊戲場景困難");
        }
        public void nightmare()
        {
            SceneManager.LoadScene("遊戲場景惡夢");
        }
        public void back()
        {
            SceneManager.LoadScene("開始畫面");
        }
        public void Levelup()
        {
            setActive02.SetActive(true);
            setActive01.SetActive(false);
        }
        public void back2()
        {
            setActive01.SetActive(true);
            setActive02.SetActive(false);
        }
    }
}

