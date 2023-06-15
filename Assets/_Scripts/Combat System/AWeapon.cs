using UnityEngine;

public abstract class AWeapon : MonoBehaviour
{
    [SerializeField] protected float damage;
    [SerializeField] protected float attackCooldown;
    [SerializeField] protected float buffCooldown;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject is EnemyCommonSettings)
        //{
        //    Attack();
        //}
    }
    protected abstract void Attack();
    protected abstract void Buff();

}
