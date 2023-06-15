public class WeaponSwitcher
{
    public void SwitchWeapon(AWeapon currentWeapon, AWeapon nextWeapon)
    {
        currentWeapon.gameObject.SetActive(false);
        nextWeapon.gameObject.SetActive(true); 
    }
}
