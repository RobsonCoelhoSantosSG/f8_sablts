using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryListVisual : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI list;

    void Update() {
        list.text = "";

        foreach (var item in InventorySystem.Items) {
            list.text += item.Key.itemName + " x" + item.Value + "\n" ;
        }
    }
}
