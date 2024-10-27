using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SimpleFloatData : MonoBehaviour
{
    
    public FloatData dataObj;
    public float value;



    public void UpdateValue(float amount)
    {
            dataObj.UpdateValue(amount);
    }

    public void SetValue(FloatData amount)
    {
        dataObj.SetValue(amount);
    }
}
