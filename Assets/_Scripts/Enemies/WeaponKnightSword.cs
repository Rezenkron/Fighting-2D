using UnityEngine;

public class WeaponKnightSword : MonoBehaviour
{
    [SerializeField] private int damage;
    Player player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (player = collision.gameObject.GetComponent<Player>())
        {
            player.GetHit(damage);
        }
    }
}
