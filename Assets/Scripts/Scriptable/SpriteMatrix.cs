using UnityEngine;

[CreateAssetMenu(fileName = "SpriteMatrix.asset", menuName = "Sprite Matrix", order = 1)]
public class SpriteMatrix : ScriptableObject
{
    [SerializeField] Sprite[] back;
    [SerializeField] Sprite[] left;
    [SerializeField] Sprite[] front;
    [SerializeField] Sprite[] right;
    [SerializeField] int idleFrame = 0;

    public Sprite[] Back { get => back; }
    public Sprite[] Left { get => left; }
    public Sprite[] Front { get => front; }
    public Sprite[] Right { get => right; }
    public int IdleFrame { get => idleFrame; }
}