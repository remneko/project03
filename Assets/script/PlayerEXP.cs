using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Mui
{
    public class PlayerEXP : MonoBehaviour
    {
        private static Image EXPBarImage;
        private void Start()
        {
            EXPBarImage = GetComponent<Image>();
            EXPBarImage.fillAmount = 0f;
        }
        public static void SetEXPBarValue(float value)
        {
            EXPBarImage.fillAmount = value;
        }
        public static float GetEXPBarValue()
        {
            return EXPBarImage.fillAmount;
        }
    }
}
