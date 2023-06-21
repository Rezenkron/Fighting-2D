using Cinemachine;
using System;
using UnityEngine;

public class BossZone : MonoBehaviour
{
    [SerializeField] private GameObject leftBorder;
    [SerializeField] private GameObject rightBorder;
    [SerializeField] private EnemyUI bossHeathBar;
    [SerializeField] private AudioSource otherMusic;
    [SerializeField] private AudioSource bossMusic;
    [SerializeField] private CinemachineVirtualCamera bossCam;
    [SerializeField] private BossEnemy boss;

    public event Action OnPlayerEnteredZone;

    private int i = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            leftBorder.SetActive(true); 
            rightBorder.SetActive(true);
            bossHeathBar.gameObject.SetActive(true);
            otherMusic.Stop();
            bossMusic.Play();
            bossCam.Priority = 10;
            OnPlayerEnteredZone?.Invoke();
        }
    }

    private void Update()
    {
        if(boss.isDead && i == 0)
        {
            i++;
            bossMusic.Stop();
            otherMusic.Play();
        }
    }
}
