using System;
using UnityEngine;

public class CombatAnimation
{
    private readonly Animator animator;
    private readonly KeyCode attackKey;
    private readonly KeyCode buffKey;
    private readonly IInputListener<bool> input;

    public CombatAnimation(IInputListener<bool> input,Animator animator, KeyCode attackKey, KeyCode buffKey)
    {
        this.animator = animator;
        this.attackKey = attackKey;
        this.buffKey = buffKey;
        this.input = input;
    }

    public void Update()
    {
        if (input.OnButtonDown(attackKey))
        {
            animator.SetTrigger(HashedAnimations.Attack);
            animator.SetInteger(HashedAnimations.AttackAction, HashedAnimations.Swipe);
        }

        if (input.OnButtonDown(buffKey))
        {
            animator.SetBool(HashedAnimations.IsAttacking, true);
            animator.SetInteger(HashedAnimations.AttackAction, HashedAnimations.Summon);
        }
        if (input.OnButtonUp(buffKey))
        {
            animator.SetBool(HashedAnimations.IsAttacking, false);
        }
    }
}
