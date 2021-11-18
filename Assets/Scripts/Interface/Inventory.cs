using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Inventory
{
    public bool InsertItem();

    public bool GetItem();

    public bool RemoveItem();
}
