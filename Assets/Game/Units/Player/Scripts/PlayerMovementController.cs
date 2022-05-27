using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Joystick joystick;
    [SerializeField] private Button _jumpButton;
    private float _horizontalMove =0;
    private bool _jump = false;
 
    private CharacterController2D _characterController2D;

    private void Awake()
    {
        _characterController2D = GetComponent<CharacterController2D>();
    }

    public async void DoJump()
    {
        if (_jump) return;
        _jump = true;
        await UniTask.Delay(10);
        _jump = false;
    }
    private void FixedUpdate()
    {
        _horizontalMove = joystick.Horizontal;
        _characterController2D.Move(_horizontalMove *_moveSpeed * Time.deltaTime, _jump);
    }
}
