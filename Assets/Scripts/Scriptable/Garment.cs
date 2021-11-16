using UnityEngine;

[CreateAssetMenu(fileName = "Garment.asset", menuName = "Char/Garments/Garment", order = 2)]
public class Garment : ScriptableObject
{
    [SerializeField] GarmentType type;
    [SerializeField] Gender gender;

    [Header("Sprite Matrix")]
    [SerializeField] SpriteMatrix spriteMatrix;

    [Header("Remove other")]
    [SerializeField] bool none;
    [SerializeField] bool topHead;
    [SerializeField] bool head;
    [SerializeField] bool neck;
    [SerializeField] bool upperBody;
    [SerializeField] bool body;
    [SerializeField] bool lowerBody;
    [SerializeField] bool legs;
    [SerializeField] bool feet;

    [Header("Original Colors")]
    [SerializeField] Color[] baseColors;

    public int Remove() {
        return  (topHead ? 1 : 0) + (head ? 2 : 0) + (neck ? 4 : 0) +(upperBody ? 8 : 0) + (body ? 16 : 0) + (lowerBody ? 32 : 0) + (legs ? 64 : 0) + (feet ? 128 : 0);
    }

    private void OnValidate() {
        if (none) {
            topHead = false;
            head = false;
            neck = false;
            upperBody = false;
            body = false;
            lowerBody = false;
            legs = false;
            feet = false;
            none = false;
        }
    }
}