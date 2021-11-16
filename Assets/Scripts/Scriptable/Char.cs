using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Char.asset", menuName = "Char/Char", order = 0)]
public class Char : ScriptableObject
{
    [SerializeField] Gender gender;
    [SerializeField] BodyType body;
    [SerializeField] CharGarments garments;

    [Header("Sprite Matrix")]
    [SerializeField] SpriteMatrix spriteMatrix;
}
