using UnityEngine;
using Zenject;

public class Player : MonoBehaviour
{
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
}
