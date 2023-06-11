using System;

public static class GameEvents
{
    public static event Action<float> OnPlayerMovement;
    public static event Action<bool> OnPlayerJump;
    public static event Action<bool> OnPlayerEnter;


    public static void PlayerMovement(float velocity)
    {
        OnPlayerMovement?.Invoke(velocity);
    }

    public static void PlayerJump(bool isJumping)
    {
        OnPlayerJump?.Invoke(isJumping);
    }

    public static void PlayerEnter(bool isActive)
    {
        OnPlayerEnter?.Invoke(isActive);
    }

}