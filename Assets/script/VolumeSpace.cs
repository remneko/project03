using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace Mui
{
    public class VolumeSpace : MonoBehaviour
    {
        private Volume v;
        private Bloom b;
        private Vignette vg;

        void Start()
        {
            v = GetComponent<Volume>();
            v.profile.TryGet(out b);
            v.profile.TryGet(out vg);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Test();
            }
        }

        private void Test()
        {

            b.threshold.value = 0.25f;
            vg.intensity.value = 0.5f;
            print("space key was pressed");
        }
    }
}

