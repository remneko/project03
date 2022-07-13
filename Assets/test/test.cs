using Mui;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LifeGameManager.SetHealthBarValue(1);
    }

    // Update is called once per frame
    void Update()
    {
        LifeGameManager.SetHealthBarValue(LifeGameManager.GetHealthBarValue() - 0.01f);
    }
}
