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
}
