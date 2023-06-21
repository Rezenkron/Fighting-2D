using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private Slider healthBar;

    private Player player;

    [Inject]
    private void Construct(Player player)
    {
        this.player = player;
    }

    private void Update()
    {
        healthBar.value = (float)player.Health / (float)player.MaxHealth;
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
}
