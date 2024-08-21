using TMPro;
using UnityEngine;

public class Card : MonoBehaviour
{
    [Header("组件")]

    public SpriteRenderer cardSprite;

    public TextMeshPro costText, descriptionText, typeText, cardName;

    public CardDataSO cardData;

    private void Start()
    {
        Init(cardData);
    }

    public void Init(CardDataSO data)
    {
        cardData = data;

        cardSprite.sprite = data.cardImage;

        costText.text = data.cost.ToString();

        descriptionText.text = data.description;

        cardName.text = data.cardName;

        typeText.text = data.cardType switch
        {
            CardType.Attack => "攻击",
            CardType.Defence => "技能",
            CardType.Abilities => "能力",
            _ => throw new System.NotImplementedException(),
        };
    }
}
