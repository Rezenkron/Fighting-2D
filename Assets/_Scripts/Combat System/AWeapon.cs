using System.Collections;
using System.Threading;
using UnityEngine;
using Zenject;

public abstract class AWeapon : MonoBehaviour
{
    [SerializeField] protected int damage;
    [SerializeField] private float buffDuration;
    [SerializeField] private float buffCooldown;


    private bool isBuffActive = false;
    private bool isBuffReloaded = true;

    private CombatAnimation combatAnimation;
    private CombatAnimationEvents animationEvents;

    [Inject]
    private void Construct(CombatAnimation combatAnimation, CombatAnimationEvents animationEvents)
    {
        this.combatAnimation = combatAnimation;
        this.animationEvents = animationEvents;
    }

    private void OnEnable()
    {
        animationEvents.OnBuff += ActivateBuff;
    }

    private void OnDisable()
    {
        animationEvents.OnBuff -= ActivateBuff;
        StopAllCoroutines();
        isBuffReloaded = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AEnemy enemy;
        if (enemy = collision.gameObject.GetComponent<AEnemy>())
        {
            enemy.GetHit(damage);
        }
    }

    private void Update()
    {
        combatAnimation.Update();

        if (isBuffActive && isBuffReloaded)
        {
            Buff();
            StartCoroutine(BuffReload());
            StartCoroutine(BuffEnded());
            isBuffReloaded = false;
            isBuffActive = false;
        }


    }
    protected abstract void Buff();
    protected abstract void DeactivateBuff();
    private void ActivateBuff()
    {
        isBuffActive = true;
    }

    private IEnumerator BuffReload()
    {
        yield return new WaitForSeconds(buffCooldown);
        isBuffReloaded = true;
    }

    private IEnumerator BuffEnded()
    {
        yield return new WaitForSeconds(buffDuration);
        DeactivateBuff();
    }
}
