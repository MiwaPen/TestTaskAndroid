using UnityEngine;

public class FPSLockerScript : MonoBehaviour
{
    [SerializeField] private int _targetFrameRate;

    private void Awake()
    {
        Application.targetFrameRate = _targetFrameRate;
    }
}
