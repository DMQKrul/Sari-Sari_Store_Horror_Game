namespace EasyPeasyFirstPersonController
{
    using UnityEngine;

    public class PlayerGroundedState : PlayerBaseState
    {
        public PlayerGroundedState(FirstPersonController currentContext, PlayerStateFactory playerStateFactory)
            : base(currentContext, playerStateFactory) { }

        public override void EnterState()
        {
            ctx.moveDirection.y = -2f;
        }

        public override void UpdateState()
        {
            CheckSwitchStates();

            ctx.targetCameraY = ctx.standingCameraHeight;
            ctx.targetFov = ctx.normalFov;
            ctx.currentBobIntensity = ctx.bobAmount;
            ctx.currentBobSpeed = ctx.bobSpeed;
            ctx.targetTilt = 0;

            ctx.characterController.height = Mathf.MoveTowards(
                ctx.characterController.height,
                ctx.standingCharacterControllerHeight,
                Time.deltaTime * 5f
            );

            ctx.characterController.center = Vector3.MoveTowards(
                ctx.characterController.center,
                ctx.standingCharacterControllerCenter,
                Time.deltaTime * 2.5f
            );

            Vector2 input = ctx.input.moveInput;
            Vector3 move = ctx.transform.right * input.x + ctx.transform.forward * input.y;
            Vector3 finalVelocity = move * ctx.walkSpeed;
            finalVelocity.y = -20f;
            ctx.characterController.Move(finalVelocity * Time.deltaTime);
        }

        public override void ExitState() { }

        public override void CheckSwitchStates()
        {
            if (ctx.input.crouch && ctx.isGrounded)
            {
                SwitchState(factory.Crouching());
            }
        }
    }
}