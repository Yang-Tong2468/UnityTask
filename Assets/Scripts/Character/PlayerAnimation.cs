using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Player player;

    private Animator animator;

    private void Awake()
    {
        player = GetComponent<Player>();

        animator = GetComponentInChildren<Animator>();
    }

    private void OnEnable()
    {
        animator.Play("sleep");

        animator.SetBool("isSleep", true);
    }

    public void PlayerTurnBeginAnimation()
    {
        animator.SetBool("isSleep", false);

        animator.SetBool("isParry", false);
    }

    public void PlayerTurnEndAnimation()
    {
        if (player.defence.currentValue > 0)
        {
            animator.SetBool("isParry", true);
        }
        else
        {
            animator.SetBool("isSleep", true);

            animator.SetBool("isParry", false);
        }
    }

    public void OnPlayCardEvent(object obj)
    {
        Card card = obj as Card;

        switch (card.cardData.cardType)
        {
            case CardType.Attack:
                animator.SetTrigger("attack");
                break;
            case CardType.Defence:
            case CardType.Abilities:
                animator.SetTrigger("skill");
                break;
        }
    }

    public void SetSleepAnimation()
    {
        animator.Play("death");
    }
}
