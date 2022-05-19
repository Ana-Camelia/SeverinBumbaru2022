using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Money : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        GetComponent<TextMeshProUGUI>().SetText("$"+PlayerStats.Money.ToString());
    }
}
