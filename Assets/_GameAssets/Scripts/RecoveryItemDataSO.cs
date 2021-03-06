using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Stat
{
    HP,
    MP
}

[CreateAssetMenu(fileName = "itemData", menuName = "Scriptable Objects/RecoveryItemData", order = 4)]
public class RecoveryItemDataSO : ItemDataSO, IUsable
{
    public Stat stat;
    public float ammount;

    public override void Use() {
        Debug.Log("Used a " + itemName + " to restore " + ammount + " of " + stat);
    }
}
