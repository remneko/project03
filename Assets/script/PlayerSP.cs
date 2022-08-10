using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Mui
{
    public class PlayerSP : MonoBehaviour
    {
        static public Image SPBarImage;
        private void Start()
        {
            SPBarImage = GetComponent<Image>();
            SPBarImage.fillAmount = 1f;
        }
        public static void SetSPBarValue(float value)
        {
            SPBarImage.fillAmount = value;
        }
        public static float GetSPBarValue()
        {
            return SPBarImage.fillAmount;
        }
    }
}
