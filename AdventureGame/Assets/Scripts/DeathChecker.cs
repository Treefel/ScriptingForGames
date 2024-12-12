using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathChecker : MonoBehaviour
{
    public FloatData dataObj;
    private float value;
    void Update()
    {
        if (dataObj.value <= 0)
        {
            DeathScreen();
        }
    }

    public void DeathScreen()
    {
        SceneManager.LoadScene(2);
        dataObj.value = 1;
    }
}
