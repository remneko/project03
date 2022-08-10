using UnityEngine;

namespace Mui
{ 
    public class EXPmanager : MonoBehaviour
    {
        public GameObject canvas;

        private void Start()
        {
            
        }
        private void Update()
        {
            if (PlayerEXP.EXPBarImage.fillAmount == 1f)
            {
                Time.timeScale = 0;
                canvas.SetActive(true);
            }
        }
    }
}

