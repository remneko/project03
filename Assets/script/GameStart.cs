using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Mui
{ 
    public class GameStart : MonoBehaviour
    {
        [SerializeField, Header("�}�l���s")]
        private Button btnBattle;
        [SerializeField, Header("���}���s")]
        private Button btnBattle2;

        private void Start()
        {
            btnBattle.GetComponent<Button>().onClick.AddListener(OnClick1);
            btnBattle2.GetComponent<Button>().onClick.AddListener(OnClick2);
        }

        private void OnClick1()
        {
            SceneManager.LoadScene("�C�����k����");
        }
        private void OnClick2()
        {
            Application.Quit();
            
        }

    }
}

