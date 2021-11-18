using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomAnimator : MonoBehaviour
{
    public Direction direction;
    public Pose pose;
    private Pose lastPose;
    [SerializeField] Char thisChar;

    public float animationTime = 1f;
    [SerializeField, Range(1f,3f)] float animationSpeed = 1f;

    private float timePerFrame;
    private float passedTime = 0;
    private int lastFrame = 0;
    private int idle = 0;
    private int startFrame = 1;
    private int restartFrame = 1;
    private CharGarments garments;
    private Sprite[] sprites = new Sprite[0];
    [Space]
    private Color[] baseBodyColors;
    [Header("Body Colors")]
    [SerializeField] Color[] hairColors;
    [SerializeField] Color[] eyeColors;
    [SerializeField] Color[] selfColors;
    [SerializeField] Color[] underpantsColors;

    [Header("Clothes Colors")]
    [SerializeField] Color[] topHeadColors;
    [SerializeField] Color[] headColors;
    [SerializeField] Color[] neckColors;
    [SerializeField] Color[] upperBodyColors;
    [SerializeField] Color[] bodyColors;
    [SerializeField] Color[] lowerBodyColors;
    [SerializeField] Color[] legsColors;
    [SerializeField] Color[] feetColors;

    [Space]
    [SerializeField] SpriteRenderer[] spriteRenderers;

    public Char ThisChar { get => thisChar; }

    void Start() {
        if (thisChar != null) {

            garments = thisChar.Garments;
            idle = thisChar.BodyMatrix.IdleFrame;
            startFrame = thisChar.BodyMatrix.StartFrame;
            restartFrame = thisChar.BodyMatrix.RestartFrame;
            //Recolor hair
            if(thisChar.HairMatrix)
                thisChar.HairMatrix.ResetRecolor();
                thisChar.HairMatrix.RecolorColors = hairColors;
            //Recolor body
            Color[] colors = new Color[selfColors.Length + eyeColors.Length + underpantsColors.Length];
            selfColors.CopyTo(colors, 0);
            eyeColors.CopyTo(colors, selfColors.Length);
            underpantsColors.CopyTo(colors, selfColors.Length + eyeColors.Length);
            thisChar.BodyMatrix.ResetRecolor();
            thisChar.BodyMatrix.RecolorColors = colors;

            //Recolor Clothes
            RecolorClothes();

            if (spriteRenderers.Length > 0)
                timePerFrame = (animationTime / thisChar.BodyMatrix.Front.Length) / animationSpeed;
            else
                spriteRenderers = transform.GetComponentsInChildren<SpriteRenderer>();
        }
    }

    void Update() {
        if (thisChar == null)
            return;

        timePerFrame = (animationTime / thisChar.BodyMatrix.Front.Length) / animationSpeed;

        if (passedTime >= timePerFrame) {
            if (pose != lastPose) {
                lastPose = pose;
                lastFrame = (startFrame > 0 ? startFrame - 1 : startFrame);
            }
            SpriteRendering(ref sprites);
            passedTime = 0;
        } else
            passedTime += Time.deltaTime;

    }

    private void RecolorClothes() {
        if (thisChar.Garments.TopHead != null) {
            thisChar.Garments.TopHead.SpriteMatrix.ResetRecolor();
            thisChar.Garments.TopHead.SpriteMatrix.RecolorColors = topHeadColors;
        }
        if (thisChar.Garments.Head != null) {
            thisChar.Garments.Head.SpriteMatrix.ResetRecolor();
            thisChar.Garments.Head.SpriteMatrix.RecolorColors = headColors;
        }
        if (thisChar.Garments.Neck != null) {
            thisChar.Garments.Neck.SpriteMatrix.ResetRecolor();
            thisChar.Garments.Neck.SpriteMatrix.RecolorColors = neckColors;
        }
        if (thisChar.Garments.UpperBody != null) {
            thisChar.Garments.UpperBody.SpriteMatrix.ResetRecolor();
            thisChar.Garments.UpperBody.SpriteMatrix.RecolorColors = upperBodyColors;
        }
        if (thisChar.Garments.Body != null) {
            thisChar.Garments.Body.SpriteMatrix.ResetRecolor();
            thisChar.Garments.Body.SpriteMatrix.RecolorColors = bodyColors;
        }
        if (thisChar.Garments.LowerBody != null) {
            thisChar.Garments.LowerBody.SpriteMatrix.ResetRecolor();
            thisChar.Garments.LowerBody.SpriteMatrix.RecolorColors = lowerBodyColors;
        }
        if (thisChar.Garments.Legs != null) {
            thisChar.Garments.Legs.SpriteMatrix.ResetRecolor();
            thisChar.Garments.Legs.SpriteMatrix.RecolorColors = legsColors;
        }
        if (thisChar.Garments.Feet != null) {
            thisChar.Garments.Feet.SpriteMatrix.ResetRecolor();
            thisChar.Garments.Feet.SpriteMatrix.RecolorColors = feetColors;
        }
    }

    private void SpriteRendering(ref Sprite[] sprites) {
        switch (pose) {
            case Pose.idle:
                lastFrame = idle;
                break;
            case Pose.walk:
                lastFrame++;
                if (lastFrame >= sprites.Length)
                    lastFrame = restartFrame;
                break;
        }

        for (int i = 0; i < spriteRenderers.Length; i++) {
            switch (direction) {
                case Direction.back:
                    sprites = new Sprite[thisChar.BodyMatrix.Back.Length];
                    if (i == 0 && garments.TopHead !=null) {
                        sprites = garments.TopHead.SpriteMatrix.Back;
                    }
                    if (i == 1 && garments.Head != null) {
                        sprites = garments.Head.SpriteMatrix.Back;
                    }
                    if (i == 2 && garments.Neck != null) {
                        sprites = garments.Neck.SpriteMatrix.Back;
                    }
                    if (i == 3 && garments.UpperBody != null) {
                        sprites = garments.UpperBody.SpriteMatrix.Back;
                    }
                    if (i == 4 && garments.Body != null) {
                        sprites = garments.Body.SpriteMatrix.Back;
                    }
                    if (i == 5 && garments.LowerBody != null) {
                        sprites = garments.LowerBody.SpriteMatrix.Back;
                    }
                    if (i == 6 && garments.Legs != null) {
                        sprites = garments.Legs.SpriteMatrix.Back;
                    }
                    if (i == 7 && garments.Feet != null) {
                        sprites = garments.Feet.SpriteMatrix.Back;
                    }
                    if (i == 8 && thisChar.HairMatrix != null) {
                        sprites = thisChar.HairMatrix.Back;
                    }
                    if (i == 9 && thisChar.BodyMatrix != null) {
                        sprites = thisChar.BodyMatrix.Back;
                    }
                    break;
                case Direction.left:
                    sprites = new Sprite[thisChar.BodyMatrix.Left.Length];
                    if (i == 0 && garments.TopHead != null) {
                        sprites = garments.TopHead.SpriteMatrix.Left;
                    }
                    if (i == 1 && garments.Head != null) {
                        sprites = garments.Head.SpriteMatrix.Left;
                    }
                    if (i == 2 && garments.Neck != null) {
                        sprites = garments.Neck.SpriteMatrix.Left;
                    }
                    if (i == 3 && garments.UpperBody != null) {
                        sprites = garments.UpperBody.SpriteMatrix.Left;
                    }
                    if (i == 4 && garments.Body != null) {
                        sprites = garments.Body.SpriteMatrix.Left;
                    }
                    if (i == 5 && garments.LowerBody != null) {
                        sprites = garments.LowerBody.SpriteMatrix.Left;
                    }
                    if (i == 6 && garments.Legs != null) {
                        sprites = garments.Legs.SpriteMatrix.Left;
                    }
                    if (i == 7 && garments.Feet != null) {
                        sprites = garments.Feet.SpriteMatrix.Left;
                    }
                    if (i == 8 && thisChar.HairMatrix != null) {
                        sprites = thisChar.HairMatrix.Left;
                    }
                    if (i == 9 && thisChar.BodyMatrix != null) {
                        sprites = thisChar.BodyMatrix.Left;
                    }
                    break;
                case Direction.front:
                    sprites = new Sprite[thisChar.BodyMatrix.Front.Length];
                    if (i == 0 && garments.TopHead != null) {
                        sprites = garments.TopHead.SpriteMatrix.Front;
                    }
                    if (i == 1 && garments.Head != null) {
                        sprites = garments.Head.SpriteMatrix.Front;
                    }
                    if (i == 2 && garments.Neck != null) {
                        sprites = garments.Neck.SpriteMatrix.Front;
                    }
                    if (i == 3 && garments.UpperBody != null) {
                        sprites = garments.UpperBody.SpriteMatrix.Front;
                    }
                    if (i == 4 && garments.Body != null) {
                        sprites = garments.Body.SpriteMatrix.Front;
                    }
                    if (i == 5 && garments.LowerBody != null) {
                        sprites = garments.LowerBody.SpriteMatrix.Front;
                    }
                    if (i == 6 && garments.Legs != null) {
                        sprites = garments.Legs.SpriteMatrix.Front;
                    }
                    if (i == 7 && garments.Feet != null) {
                        sprites = garments.Feet.SpriteMatrix.Front;
                    }
                    if (i == 8 && thisChar.HairMatrix != null) {
                        sprites = thisChar.HairMatrix.Front;
                    }
                    if (i == 9 && thisChar.BodyMatrix != null) {
                        sprites = thisChar.BodyMatrix.Front;
                    }
                    break;
                case Direction.right:
                    sprites = new Sprite[thisChar.BodyMatrix.Right.Length];
                    if (i == 0 && garments.TopHead != null) {
                        sprites = garments.TopHead.SpriteMatrix.Right;
                    }
                    if (i == 1 && garments.Head != null) {
                        sprites = garments.Head.SpriteMatrix.Right;
                    }
                    if (i == 2 && garments.Neck != null) {
                        sprites = garments.Neck.SpriteMatrix.Right;
                    }
                    if (i == 3 && garments.UpperBody != null) {
                        sprites = garments.UpperBody.SpriteMatrix.Right;
                    }
                    if (i == 4 && garments.Body != null) {
                        sprites = garments.Body.SpriteMatrix.Right;
                    }
                    if (i == 5 && garments.LowerBody != null) {
                        sprites = garments.LowerBody.SpriteMatrix.Right;
                    }
                    if (i == 6 && garments.Legs != null) {
                        sprites = garments.Legs.SpriteMatrix.Right;
                    }
                    if (i == 7 && garments.Feet != null) {
                        sprites = garments.Feet.SpriteMatrix.Right;
                    }
                    if (i == 8 && thisChar.HairMatrix != null) {
                        sprites = thisChar.HairMatrix.Right;
                    }
                    if (i == 9 && thisChar.BodyMatrix != null) {
                        sprites = thisChar.BodyMatrix.Right;
                    }
                    break;
            }
            spriteRenderers[i].sprite = sprites[lastFrame];
        }
    }

}
