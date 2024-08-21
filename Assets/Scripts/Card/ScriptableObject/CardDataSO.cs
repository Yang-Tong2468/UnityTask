using UnityEngine;

[CreateAssetMenu(fileName = "CardDataSO" , menuName = "Card/CardDataSO")]
public class CardDataSO : ScriptableObject
{
    public string cardName;

    public Sprite cardImage;

    public int cost;

    public CardType cardType;

    [TextArea]

    public string description;

    //执行的效果
}
