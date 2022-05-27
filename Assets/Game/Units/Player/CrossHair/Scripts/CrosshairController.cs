using UnityEngine;

public class CrosshairController : MonoBehaviour
{
    [SerializeField] private GameObject crossHair;
    [SerializeField] private Joystick _joystick;
    public float _radius = 1;
    private Transform _transform;
    private Vector2 _crossPos = Vector2.zero;
    public Transform CrossPos => crossHair.transform;
    public float fi = 1;
    public float _crossSpeed = 1;

    private void Awake()
    {
        _transform = transform;
    }

    private void FixedUpdate()
    {
        if(_joystick.IsUsed)
            fi = Mathf.Acos(_joystick.Horizontal);
        UpdateCrossPosition();
    }

    private void UpdateCrossPosition()
    {
        float x = _radius * Mathf.Cos(fi);
        float y = _radius * Mathf.Sin(fi);
        _crossPos = new Vector2(_transform.position.x + x,
            _transform.position.y + y);
        crossHair.transform.position = _crossPos;
    }
}
