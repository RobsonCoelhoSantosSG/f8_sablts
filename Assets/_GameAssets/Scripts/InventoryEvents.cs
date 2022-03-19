using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InventoryEvents : MonoBehaviour
{
    public UnityEvent<ItemDataSO, int> OnItemAdded;
    public UnityEvent<Dictionary<ItemDataSO, int>> OnInventoryChanged;

    private void OnEnable() {
        InventorySystem.OnItemAdded += RaiseOnItemAdded;
    }

    private void OnDisable() {
        InventorySystem.OnItemAdded -= RaiseOnItemAdded;
    }

    public void RaiseOnItemAdded(ItemDataSO item, int ammount) {
        OnItemAdded.Invoke(item, ammount);
    }

    public void RaiseOnInventoryChanged(Dictionary<ItemDataSO, int> items) {
        OnInventoryChanged.Invoke(items);
    }
}