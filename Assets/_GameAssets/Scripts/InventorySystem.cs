using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InventorySystem
{
    public static event Action<ItemDataSO, int> OnItemAdded;
    public static event Action<Dictionary<ItemDataSO, int>> OnInventoryChanged;

    public static Dictionary<ItemDataSO, int> Items = new Dictionary<ItemDataSO, int>();

    public static void AddItem(ItemDataSO item) {
        if (Items.ContainsKey(item)) {
            Items[item] += 1;
        }
        else {
            Items.Add(item, 1);
        }

        OnItemAdded?.Invoke(item, Items[item]);
        OnInventoryChanged?.Invoke(Items);
    }
}
