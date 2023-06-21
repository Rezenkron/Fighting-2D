using System;
using UnityEngine;
using Zenject;

public class CombatAnimationEvents : MonoBehaviour
{
    private WeaponHolder weaponHolder;

    public event Action OnBuff;

    [Inject]
    private void Construct(WeaponHolder weaponHolder)
    {
        this.weaponHolder = weaponHolder;
    }

    private AWeapon weapon;
    private Collider2D collider2d;

    private void OnEnable()
    {
        weaponHolder.OnWeaponChanged += ChangeWeapon;
    }

    private void OnDisable()
    {
        weaponHolder.OnWeaponChanged -= ChangeWeapon;
    }

    public void TurnOnCollider()
    {
        collider2d.enabled = true;
    }
    public void TurnOffCollider()
    {
        collider2d.enabled = false;
    }

    public void Buff()
    {
        OnBuff?.Invoke();
    }

    private void ChangeWeapon(AWeapon weapon)
    {
        this.weapon = weapon;
        collider2d = weapon.GetComponent<Collider2D>();
    }
}
