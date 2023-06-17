using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    public int Health { get; private set; }

    protected Player player;
    private AWeapon weapon;

    [Inject]
    private void Construct(Player player)
    {
        this.player = player;
    }

    //private void OnEnable()
    //{
    //    weapon.OnHit += GetHit;
    //}

    //private void OnDisable()
    //{
    //    weapon.OnHit -= GetHit;
    //}

    private void Awake()
    {
        Health = maxHealth;
    }


    protected void GetHit(AWeapon weapon,int damage)
    {
        this.weapon = weapon;
        Health -= damage;
    }
}
