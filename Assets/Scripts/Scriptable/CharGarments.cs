using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharGarments.asset", menuName = "Char/CharGarments", order = 1)]
public class CharGarments : ScriptableObject
{
    [SerializeField] Garment topHead;
    [SerializeField] Garment head;
    [SerializeField] Garment neck;
    [SerializeField] Garment upperBody;
    [SerializeField] Garment body;
    [SerializeField] Garment lowerBody;
    [SerializeField] Garment legs;
    [SerializeField] Garment feet;

    public Garment TopHead { get => topHead; }
    public Garment Head { get => head; }
    public Garment Neck { get => neck; }
    public Garment UpperBody { get => upperBody;  }
    public Garment Body { get => body; }
    public Garment LowerBody { get => lowerBody; }
    public Garment Legs { get => legs; }
    public Garment Feet { get => feet; }
}
