using UnityEngine;

public class CombatAnimation
{
    [SerializeField] private KeyCode attackKey;
    [SerializeField] private KeyCode buffKey;
    IInputListener<bool> attackInput;
    IInputListener<bool> buffInput;
    public void Start()
    {
        attackInput = new InputKeyListener(attackKey);
        buffInput = new InputKeyListener(buffKey);
    }

    public void Update()
    {
        if (attackInput.OnButtonUp())
        {
            
        }
    }
}
