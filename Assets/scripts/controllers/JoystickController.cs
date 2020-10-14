using UnityEngine;

public class JoystickController : MoveController
{
    public Joystick joystick;

    public override Vector2 Movies()
    {
        if (joystick)
            return new Vector2(joystick.Horizontal, joystick.Vertical);

        Debug.Log("Joystick not found");
        return Vector2.zero;
    }
}