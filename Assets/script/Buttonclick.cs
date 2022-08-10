using UnityEngine;
using TMPro;

namespace Mui
{
    public class Buttonclick : MonoBehaviour
    {
        public GameObject canvas;
        public TextMeshProUGUI TMP1;
        private int TMP1LV = 1;
        public TextMeshProUGUI TMP2;
        private int TMP2LV = 1;
        public TextMeshProUGUI TMP3;
        private int TMP3LV = 1;
        public TextMeshProUGUI TMP4;
        private int TMP4LV = 1;

        private void Start()
        {
            TMP1 = GameObject.Find("ю阑Θ单").GetComponent<TextMeshProUGUI>();
            TMP2 = GameObject.Find("脄阑Θ单").GetComponent<TextMeshProUGUI>();
            TMP3 = GameObject.Find("ň縨Θ单").GetComponent<TextMeshProUGUI>();
            TMP4 = GameObject.Find("ネ㏑Θ单").GetComponent<TextMeshProUGUI>();
        }
        public void ATKbutton(float A)
        {
            Slash.Damageplus += A;
            PlayerEXP.EXPBarImage.fillAmount = 0f;
            PlayerHealth.EXP = 0;
            PlayerEXP.SetEXPBarValue(0);
            TMP1LV += 1;
            Time.timeScale = 1;
            TMP1.text = TMP1LV.ToString();
        }
        public void CPBbutton(float C)
        {
            Slash.critProbabilityplus += C/10;
            PlayerEXP.EXPBarImage.fillAmount = 0f;
            PlayerHealth.EXP = 0;
            PlayerEXP.SetEXPBarValue(0);
            TMP2LV += 1;
            Time.timeScale = 1;
            TMP2.text = TMP2LV.ToString();
        }
        public void DEFbutton(float D)
        {
            PlayerHealth.DEF += D;
            PlayerEXP.EXPBarImage.fillAmount = 0f;
            PlayerHealth.EXP = 0;
            PlayerEXP.SetEXPBarValue(0);
            TMP3LV += 1;
            Time.timeScale = 1;
            TMP3.text = TMP3LV.ToString();
        }
        public void HPbutton(float H)
        {
            PlayerHealth.maxHP += H;
            PlayerHealth.HP = PlayerHealth.maxHP;
            PlayerHp.HealthBarImage.fillAmount = 1f;
            PlayerHealth.maxSP += H/100;
            PlayerHealth.SP = PlayerHealth.maxSP;
            PlayerSP.SPBarImage.fillAmount = 1f;
            PlayerHealth.EXP = 0;
            PlayerEXP.SetEXPBarValue(0);
            TMP4LV += 1;
            Time.timeScale = 1;
            TMP4.text = TMP4LV.ToString();
        }

        private void Update()
        {            
            if (PlayerEXP.EXPBarImage.fillAmount == 1f)
            {
                Time.timeScale = 0;
                canvas.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                canvas.SetActive(false);
            }
        }
    }
}

