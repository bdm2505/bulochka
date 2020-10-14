using UnityEngine;

public class KeyboardController : MoveController
{
    
    public override Vector2 Movies()
    {
        var dx = Input.GetAxis("Horizontal");
        var dy = Input.GetAxis("Vertical");
        return new Vector2(dx, dy);
    }
}