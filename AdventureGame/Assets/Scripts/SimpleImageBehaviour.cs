using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class SimpleImageBehaviour : MonoBehaviour
{

    
    private Image imageObj;
    public FloatData dataObj;

    private void Start()
    {
        imageObj = GetComponent<Image>();
    }

    
    public void UpdateWithFloatData()
    {
        imageObj.fillAmount = dataObj.value;
        print(dataObj.value);
    }
}
