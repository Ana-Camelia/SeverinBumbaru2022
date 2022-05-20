using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Money : MonoBehaviour
{

    // updatam banii din player stats
    void Update()
    {
        GetComponent<TextMeshProUGUI>().SetText("$"+PlayerStats.Money.ToString());
    }
}
