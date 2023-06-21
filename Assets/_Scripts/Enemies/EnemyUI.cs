using UnityEngine;
using UnityEngine.UI;

public class EnemyUI : MonoBehaviour
{
    [SerializeField] private BossEnemy boss;
    [SerializeField] private Slider healthbar;


    private void Update()
    {
        healthbar.value = (float)boss.Health / (float)boss.MaxHealth;
    }
}
