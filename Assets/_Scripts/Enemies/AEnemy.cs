using UnityEngine;
using Zenject;

public abstract class AEnemy : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] protected Animator anim;
    [SerializeField] private GameObject winPanel;

    public bool isDead { get; private set; } = false;
    public int MaxHealth { get; private set; }
    public int Health { get { return health; } }

    protected Player player;

    private void Awake()
    {
        MaxHealth = health;
    }

    [Inject]
    private void Construct(Player player)
    {
        this.player = player;
    }


    public void GetHit(int damage)
    {
        health -= damage;
        if(health <= 0) 
        {
            Death();
        }
    }

    private void Death()
    {
        anim.SetBool(HashedAnimations.IsDead, true);
        winPanel.SetActive(true);
        isDead = true;
    }  
    
}
