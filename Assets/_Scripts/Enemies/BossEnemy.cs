using System.Collections;
using UnityEngine;

public class BossEnemy : AEnemy
{
    [SerializeField] private float speed;
    [SerializeField] private float stoppingDistance;
    [SerializeField] private float attackCooldown;
    [SerializeField] private BossZone bossZone;

    private float xScale;
    private bool isPlayerEnteredZone = false;
    private bool isAttackPossible = true;
    private bool isMovingPossible = true;

    private void Start()
    {
        xScale = gameObject.transform.localScale.x;
    }

    private void OnEnable()
    {
        bossZone.OnPlayerEnteredZone += PlayerEnteredZone;
    }

    private void OnDisable()
    {
        bossZone.OnPlayerEnteredZone -= PlayerEnteredZone;
    }

    private void Update()
    {
        FacePlayer();
    }
    private void FixedUpdate()
    {
        if (isPlayerEnteredZone)
        {
            MoveToPlayer();
        }
    }

    private void MoveToPlayer()
    {
        Vector2 direction = player.transform.position - transform.position;
        direction = direction.normalized;

        float distanceToTarget = Vector2.Distance(transform.position, player.transform.position);

        if (distanceToTarget >= stoppingDistance && isMovingPossible)
        {
            transform.Translate(new Vector2(direction.x * speed * Time.fixedDeltaTime, 0));
            anim.SetFloat(HashedAnimations.HorizontalSpeed, Mathf.Abs(distanceToTarget));
        }
        else if(distanceToTarget <= stoppingDistance && isAttackPossible) 
        {
            Attack();
        }
    }

    private void Attack()
    {
        isAttackPossible = false;
        isMovingPossible = false;
        StartCoroutine(AttackCooldown());
    }

    private IEnumerator AttackCooldown()
    {
        anim.SetBool(HashedAnimations.IsAttacking, true);
        int i;
        bool isAttackDone = false;
        for (i = 0; i != 1;)
        {
            yield return new WaitForSeconds(0.6f);
            i = Random.Range(0, 2);
        }
        if (i == 1)
        {
            anim.SetBool(HashedAnimations.IsAttacking, false);
            isAttackDone = true;
            isMovingPossible = true;
        }
        if(isAttackDone)
        {
            yield return new WaitForSeconds(attackCooldown);
            isAttackPossible = true;
        }
    }

    private void FacePlayer()
    {
        if(player.transform.position.x > gameObject.transform.position.x)
        {
            gameObject.transform.localScale = new Vector3(-xScale, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
        } else if ( player.transform.position.x < gameObject.transform.position.x)
        {
            gameObject.transform.localScale = new Vector3(xScale, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
        }
    }
    private void PlayerEnteredZone()
    {
        isPlayerEnteredZone = true;
    }
}
