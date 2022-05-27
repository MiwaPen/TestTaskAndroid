using UnityEngine;
using DG.Tweening;

public class HealthBarController : MonoBehaviour
{
    [SerializeField] private Color _startColor;
    [SerializeField] private Color _endColor;
    [SerializeField] private float _BarChangeSpeed;
    private Transform _healthBar;
    private SpriteRenderer _spriteRenderer;
    private int _maxHealPoints;
    private int _currentHealPoints;
    private float _healthBarMaxSize = 1;

    private void Awake()
    {
        _healthBar = GetComponent<Transform>();
        _healthBarMaxSize = _healthBar.localScale.x;
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void UpdateHealthBar(int newCurrentHealPoints)
    {
        _currentHealPoints = newCurrentHealPoints;
        float currentHpInPercent = (float)_currentHealPoints/(float)_maxHealPoints;
        float healthBarSize = _healthBarMaxSize * currentHpInPercent;
        _healthBar.DOScaleX(healthBarSize, _BarChangeSpeed);
        _spriteRenderer.color = Color.Lerp(_endColor, _startColor, currentHpInPercent);
    }

    public void SetHealPointsInfo(int maxHealPoints,int currentHealPoints)
    {
        _maxHealPoints = maxHealPoints;
        _currentHealPoints = currentHealPoints;
        UpdateHealthBar(currentHealPoints);
    }

    private void OnDestroy()
    {
        _healthBar.DOKill(true);
    }
}
