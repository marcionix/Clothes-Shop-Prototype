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
    [SerializeField] SpriteMatrix hairMatrix;
    [SerializeField] SpriteMatrix bodyMatrix;

    public SpriteMatrix BodyMatrix { get => bodyMatrix; }
    public SpriteMatrix HairMatrix { get => hairMatrix; }
    public CharGarments Garments { get => garments; }
    public BodyType BodyType { get => body; }

    public Sprite[] GetStandFrontSprites() {
        Sprite[] sprites = new Sprite[10];

        if (garments) {
            if (garments.TopHead) sprites[0] = garments.TopHead.SpriteMatrix.Front[garments.TopHead.SpriteMatrix.IdleFrame];
            if (garments.Head) sprites[1] = garments.Head.SpriteMatrix.Front[garments.Head.SpriteMatrix.IdleFrame];
            if (garments.Neck) sprites[2] = garments.Neck.SpriteMatrix.Front[garments.Neck.SpriteMatrix.IdleFrame];
            if (garments.UpperBody) sprites[3] = garments.UpperBody.SpriteMatrix.Front[garments.UpperBody.SpriteMatrix.IdleFrame];
            if (garments.Body) sprites[4] = garments.Body.SpriteMatrix.Front[garments.Body.SpriteMatrix.IdleFrame];
            if (garments.LowerBody) sprites[5] = garments.LowerBody.SpriteMatrix.Front[garments.LowerBody.SpriteMatrix.IdleFrame];
            if (garments.Legs) sprites[6] = garments.Legs.SpriteMatrix.Front[garments.Legs.SpriteMatrix.IdleFrame];
            if (garments.Feet) sprites[7] = garments.Feet.SpriteMatrix.Front[garments.Feet.SpriteMatrix.IdleFrame];
        }
        if (HairMatrix) sprites[8] = HairMatrix.Front[HairMatrix.IdleFrame];
        if (BodyMatrix) sprites[9] = BodyMatrix.Front[BodyMatrix.IdleFrame];

        return sprites;
    }
}
