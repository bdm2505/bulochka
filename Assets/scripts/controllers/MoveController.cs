using UnityEngine;

[RequireComponent(typeof(BaseCharacter))]
public abstract class MoveController : MonoBehaviour
{
    public abstract Vector2 Movies();
}