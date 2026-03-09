namespace EasyPeasyFirstPersonController
{
    public class PlayerStateFactory
    {
        FirstPersonController context;

        public PlayerStateFactory(FirstPersonController currentContext)
        {
            context = currentContext;
        }

        public PlayerBaseState Grounded() => new PlayerGroundedState(context, this);
        public PlayerBaseState Crouching() => new PlayerCrouchingState(context, this);
    }
}