using UnityEngine;
using Zenject;

public class Player : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private GameObject deathPanel;
    public int MaxHealth { get; private set; }
    public int Health { get { return health; } }

    private void Start()
    {
        MaxHealth = health;
    }

    private IMovementModel playerMovement;
    private IMovementView playerMovementView;
    private IJumpModel jumpModel;
    [Inject]
    private void Construct(IMovementModel playerMovement, IMovementView playerMovementView, IJumpModel jumpModel)
    {
        this.playerMovement = playerMovement;
        this.playerMovementView = playerMovementView;
        this.jumpModel = jumpModel;
    }

    private void Update()
    {
        playerMovement.Update();
        playerMovementView.Update();
        jumpModel.DoJump();
    }

    public void GetHit(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Death();
        }
    }

    public void GetHeal(int value)
    {
        health = Mathf.Clamp(health += value, 0, MaxHealth);
    }

    private void Death()
    {
        Time.timeScale = 0;
        deathPanel.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Death")
        {
            Death();
        }
    }
}
