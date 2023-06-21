using System;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    private AWeapon[] weapons;
    private AWeapon activeWeapon;

    float input;
    int value;

    public event Action<AWeapon> OnWeaponChanged;

    void Start()
    {
        weapons = GetComponentsInChildren<AWeapon>();
        for(int i = weapons.Length - 1; i > 0; i--)
        {
            weapons[i].gameObject.SetActive(false);
        }

        activeWeapon = weapons[0];

        OnWeaponChanged.Invoke(activeWeapon);
    }

    void Update()
    {
        input = Input.GetAxisRaw("Mouse ScrollWheel");
        if (input != 0)
        {
            value = (int)Mathf.Repeat(value + input, weapons.Length);
            weapons[value].gameObject.SetActive(true);

            activeWeapon.gameObject.SetActive(false);
            activeWeapon = weapons[value];

            OnWeaponChanged?.Invoke(activeWeapon);
        }
    }
}
