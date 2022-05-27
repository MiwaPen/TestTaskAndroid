using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RaycastWeapon : WeaponBase
{
    [SerializeField] private LineRenderer _rayLine;
    [SerializeField] private Transform _rayStartPoint;
    [SerializeField] protected LayerMask _layerMask;
    private Transform _transform;
    
    private void Awake()
    {
        _transform = transform;
    }
    protected override void MakeShoot()
    {
        _rayLine.SetPosition(0, _rayStartPoint.position);

        RaycastHit2D hit = Physics2D.Raycast(_transform.position, _transform.right, Mathf.Infinity,_layerMask );
        if (hit != false)
        {
            _rayLine.SetPosition(1, hit.point);

            if (hit.transform.gameObject.TryGetComponent<IDamageable>(out IDamageable damageable))
                damageable.TryApplyDamage(_damage);

            if (hit.transform.gameObject
                .TryGetComponent<TilemapCollider2D>(out TilemapCollider2D tileMapCollider))
                TryBreakTile(tileMapCollider,hit.point);                        
        }
        else
            _rayLine.SetPosition(1, _transform.right*100);

        ShowRayLine();
        PlaySound();
    }

    private void TryBreakTile(TilemapCollider2D tileMapCollider, Vector2 point)
    {
        Tilemap tilemap = tileMapCollider.GetComponent<Tilemap>();
        Vector3Int tilePos = tilemap.WorldToCell(point);
        tilemap.SetTile(tilePos, null);
    }

    private async void ShowRayLine()
    {
        _rayLine.enabled = true;
        await UniTask.Delay(100);
        _rayLine.enabled = false;
    }

    private void PlaySound()
    {
        if (_shootSound != null)
            _shootSound.Play();
    }
}
