using UnityEngine;

[RequireComponent(typeof(Player))]
public class AnimatorPlayerController : MonoBehaviour
{
    public static class States
    {
        public const string MoveState = nameof(MoveState);
        public const string Jump = nameof(Jump);
    }
}
