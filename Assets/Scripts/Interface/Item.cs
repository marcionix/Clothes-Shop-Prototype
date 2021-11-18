using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Item 
{

    public bool buy(out Garment garment);

    public bool sell();
}
