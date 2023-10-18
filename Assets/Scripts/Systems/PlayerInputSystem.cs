using Unity.Entities;
using UnityEngine;

[UpdateInGroup(typeof(InitializationSystemGroup), OrderLast = true)]
public partial class PlayerInputSystem : SystemBase
{
    private InputControls inputActions;
    private Entity player;

    protected override void OnCreate() //Awake
    {
        RequireForUpdate<PlayerTag>();
        RequireForUpdate<PlayerMoveInput>();

        inputActions = new InputControls();
    }
    protected override void OnStartRunning() //Start
    {
        inputActions.Enable();

        player = SystemAPI.GetSingletonEntity<PlayerTag>();
    }
    protected override void OnUpdate()
    {
        var inp = inputActions.Mainactionmap.PlayerMoveInput.ReadValue<Vector2>();

        SystemAPI.SetSingleton(new PlayerMoveInput { Value = inp });
    }

    protected override void OnStopRunning()
    {
        inputActions.Disable();

        player = Entity.Null;
    }
}
