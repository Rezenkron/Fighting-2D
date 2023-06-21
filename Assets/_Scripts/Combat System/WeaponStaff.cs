using UnityEngine;
using Zenject;

public class WeaponStaff : AWeapon
{
    [SerializeField] private int HealValue;
    Player player;
    [Inject]
    private void Construct(Player player)
    {
        this.player = player;
    }
    protected override void Buff()
    {
        player.GetHeal(HealValue);
    }

    protected override void DeactivateBuff()
    {

    }
}
