using UnityEngine;

[CreateAssetMenu(fileName = "HealEffect", menuName = "Card Effect/HealEffect")]

public class HealEffect : Effect
{
    public override void Execute(CharacterBase from, CharacterBase target)
    {
        if (targetType == EffectTargetType.Self)
        {
            from.HealHealth(value);
        }

        if (targetType == EffectTargetType.Target)
        {
            target.HealHealth(value);
        }
    }
}
