using System;
using System.Threading;
using UnityEngine;
using Zenject;

public abstract class AWeapon : MonoBehaviour
{
    [SerializeField] protected int damage;

    private CombatAnimation combatAnimation;

    public event Action<AWeapon, int> OnHit;

    [Inject]
    private void Construct(CombatAnimation combatAnimation)
    {
        this.combatAnimation = combatAnimation;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnHit?.Invoke(this, damage);
    }

    private void Update()
    {
        combatAnimation.Update();
    }
    protected abstract void Buff();

    private void BuffTimer()
    {
        
    }
}
