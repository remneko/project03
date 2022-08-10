using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Mui
{
    public class PlayerMP : MonoBehaviour
    {
        static public Image MPBarImage;
        private void Start()
        {
            MPBarImage = GetComponent<Image>();
            MPBarImage.fillAmount = 1f;
        }
        public static void SetMPBarValue(float value)
        {
            MPBarImage.fillAmount = value;
        }
        public static float GetMPBarValue()
        {
            return MPBarImage.fillAmount;
        }
    }
}
