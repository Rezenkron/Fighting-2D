using UnityEngine;

public class WeaponSword : AWeapon
{
    [SerializeField] int IncreaseDamageValue;

    private int prevDamage;

    private void Start()
    {
        prevDamage = damage;
    }
    protected override void Buff()
    {
        damage += IncreaseDamageValue;
    }

    protected override void DeactivateBuff()
    {
        damage = prevDamage;
    }

    private void OnDisable()
    {
        DeactivateBuff();
    }
}
