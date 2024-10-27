using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Globalization;

[RequireComponent(typeof(TextMeshProUGUI))]
public class SimpleTextMeshProBehaviour : MonoBehaviour
{
    private TextMeshProUGUI textObj;
    public SimpleIntData dataObj;

    void Start()
    {
        textObj = GetComponent<TextMeshProUGUI>();
        UpdateWithIntData();
    }

    public void UpdateWithIntData()
    {
        print("attemptingtoupdate");
        print(dataObj.value.ToString());
        textObj.text = dataObj.value.ToString(CultureInfo.InvariantCulture);
    }
}
