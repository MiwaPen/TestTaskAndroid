using TMPro;
using UnityEngine;
using Zenject;

public class EnemiesCounterUIScript : MonoBehaviour
{
    [Inject] private EnemySpawner _enemySpawner;
    private const string labeText = "Enemies left: ";
    private TMP_Text _textLabel;

    private void Awake()
    {
        _textLabel = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        _enemySpawner.OnEnemyCounterChange += UpdateLabel;
    }

    private void OnDisable()
    {
        _enemySpawner.OnEnemyCounterChange -= UpdateLabel;
    }
    private void UpdateLabel(int enemycounter)
    {
        _textLabel.text = labeText + enemycounter.ToString();
    }
}
