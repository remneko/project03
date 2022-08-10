using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Mui
{
    public class difficultyLevel : MonoBehaviour
    {
        [SerializeField, Header("�C������")]
        private Button btnBattle;
        [SerializeField, Header("�C�������x��")]
        private Button btnBattle2;
        [SerializeField, Header("�C�������c��")]
        private Button btnBattle3;
        [SerializeField, Header("�}�l�e��")]
        private Button btnBattle4;
        [SerializeField, Header("�ɯŤ���")]
        private Button btnBattle5;
        [SerializeField, Header("���k����")]
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
            SceneManager.LoadScene("�C������");
        }
        public void Difficult()
        {
            SceneManager.LoadScene("�C�������x��");
        }
        public void nightmare()
        {
            SceneManager.LoadScene("�C�������c��");
        }
        public void back()
        {
            SceneManager.LoadScene("�}�l�e��");
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

