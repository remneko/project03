using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

namespace Mui
{ 
    public class GameStart : MonoBehaviour
    {
        [SerializeField, Header("開始按鈕")]
        private Button btnBattle;

        private void Start()
        {
            btnBattle.GetComponent<Button>().onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            SceneManager.LoadScene("遊戲場景");
        }

    }
}

