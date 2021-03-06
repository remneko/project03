using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Mui
{
    public class PlayerHp : MonoBehaviour
    {
        private static Image HealthBarImage;
        private void Start()
        {
            HealthBarImage = GetComponent<Image>();
            HealthBarImage.fillAmount = 1f;
        }
        public static void SetHealthBarValue(float value)
        {
            HealthBarImage.fillAmount = value;
        }
        public static float GetHealthBarValue()
        {
            return HealthBarImage.fillAmount;
        }
    }
}