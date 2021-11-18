using System;
using UnityEngine;

[CreateAssetMenu(fileName = "SpriteMatrix.asset", menuName = "Sprite Matrix", order = 1)]
public class SpriteMatrix : ScriptableObject
{
    [SerializeField] Sprite[] back;
    [SerializeField] Sprite[] left;
    [SerializeField] Sprite[] front;
    [SerializeField] Sprite[] right;
    [SerializeField] Sprite[] recolorBack;
    [SerializeField] Sprite[] recolorLeft;
    [SerializeField] Sprite[] recolorFront;
    [SerializeField] Sprite[] recolorRight;
    [SerializeField] int idleFrame = 0;
    [SerializeField] int startFrame = 8;
    [SerializeField] int restartFrame = 1;

    [Header("Original Colors")]
    [SerializeField] Color[] baseColors;
    [SerializeField] Color[] recolorColors;

    Texture2D recolorTexture;

    public Sprite[] Back { get => (baseColors.Length > 0 ? (recolorColors.Length>0? (recolorBack.Length>0 ? recolorBack : Recolor(back,out recolorBack)) : back) : back); set => recolorBack = value; }
    public Sprite[] Left { get => (baseColors.Length > 0 ? (recolorColors.Length > 0 ? (recolorLeft.Length > 0 ? recolorLeft : Recolor(left, out recolorLeft)) : left) : left); set => recolorLeft = value; }
    public Sprite[] Front { get => (baseColors.Length > 0 ? (recolorColors.Length > 0 ? (recolorFront.Length > 0 ? recolorFront : Recolor(front, out recolorFront)) : front) : front); set => recolorFront = value; }
    public Sprite[] Right { get => (baseColors.Length > 0 ? (recolorColors.Length > 0 ? (recolorRight.Length > 0 ? recolorRight : Recolor(right, out recolorRight)) : right) : right); set => recolorRight = value; }

    internal void ResetRecolor() {
        recolorColors = new Color[0];
        recolorBack = new Sprite[0];
        recolorLeft = new Sprite[0];
        recolorFront = new Sprite[0];
        recolorRight = new Sprite[0];
        recolorTexture = null;
    }

    public int IdleFrame { get => idleFrame; set => idleFrame = value; }
    public int StartFrame { get => startFrame; set => startFrame = value; }
    public int RestartFrame { get => restartFrame; set => restartFrame = value; }
    public Color[] BaseColors { get => baseColors; }
    public Color[] RecolorColors { set => recolorColors = value; }

    private Sprite[] Recolor(Sprite[] original, out Sprite[] recolor) {
        recolor = new Sprite[original.Length];
        if (recolorTexture == null) {
            recolorTexture = CopyTexture2D(original[0].texture);
            recolorTexture.name = "Recoloror_"+original[0].texture.name;
        }
        for (int i = 0; i < original.Length; i++) {
            Sprite sprite = Sprite.Create(recolorTexture, original[i].rect, new Vector2(0.5f,0));
            recolor[i] = sprite;
        }
        return recolor;
    }

    public Texture2D CopyTexture2D(Texture2D copiedTexture) {
        Texture2D texture = new Texture2D(copiedTexture.width, copiedTexture.height);
        texture.filterMode = FilterMode.Point;
        texture.wrapMode = TextureWrapMode.Clamp;
        int y = 0;
        while (y < texture.height) {
            int x = 0;
            while (x < texture.width) {
                bool oldColor = true;
                for (int i = 0; i < baseColors.Length; i++) {
                    if (copiedTexture.GetPixel(x, y) == baseColors[i]) {
                        texture.SetPixel(x, y, recolorColors[i]);
                        oldColor = false;
                        break;
                    }
                } 
                if(oldColor) {
                    texture.SetPixel(x, y, copiedTexture.GetPixel(x, y));
                }
                ++x;
            }
            ++y;
        }
        texture.Apply();
        return texture;
    }

}