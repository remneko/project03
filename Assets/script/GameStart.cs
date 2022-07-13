using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

namespace Mui
{ 
    public class GameStart : MonoBehaviour
    {
        [SerializeField, Header("�}�l���s")]
        private Button btnBattle;

        private void Start()
        {
            btnBattle.GetComponent<Button>().onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            SceneManager.LoadScene("�C������");
        }

    }
}

