using UnityEngine;

[CreateAssetMenu(fileName = "PlayerInputConfig", menuName = "Input/PlayerInputConfig")]
public class PlayerInputManager : ScriptableObject
{
    [Header("Movimento")]
    public KeyCode moveLeft = KeyCode.A;
    public KeyCode moveRight = KeyCode.D;
    public KeyCode jump = KeyCode.Space;

    [Header("Ataque")]
    public KeyCode attack1 = KeyCode.J;
    public KeyCode attack2 = KeyCode.K;
    public KeyCode attack3 = KeyCode.L;
}