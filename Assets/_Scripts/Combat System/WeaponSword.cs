using UnityEngine;

public class WeaponSword : AWeapon
{
    [SerializeField] int IncreaseDamagePercent;
    protected override void Buff()
    {
        damage += damage * (IncreaseDamagePercent / 100);
    }
}
