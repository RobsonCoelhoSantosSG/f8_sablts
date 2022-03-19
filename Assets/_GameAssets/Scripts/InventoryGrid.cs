using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryGrid : MonoBehaviour
{
    [SerializeField] GameObject itemPrefab;
    [SerializeField] Transform Grid;

    private void OnEnable() {
        InventorySystem.OnInventoryChanged += UpdateGrid;
    }

    private void OnDisable() {
        InventorySystem.OnInventoryChanged -= UpdateGrid;
    }

    public void UpdateGrid(Dictionary<ItemDataSO, int> items) {
        foreach(Transform child in Grid) {
            Destroy(child.gameObject);
        }

        foreach (var item in items) {
            var newitem = Instantiate(itemPrefab, Grid);
            newitem.GetComponent<ItemIcon>().SetData(item.Key, item.Value);
        }
    }
}