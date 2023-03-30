using System.Drawing;
using TMPro;
using UnityEngine;

[RequireComponent(typeof (UnitDrag))]

public class Unit : MonoBehaviour
{
    [SerializeField] private UnitCard _nextCard;
    [SerializeField] private UnitCard _unitCard;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private AudioSource _audioSource;

    private Unit _saveUnit;
    private EnemySpawner _spawner;
    private float _currentTime = 0;
    private bool _isShoot;

    public SpawnPoint Point { get; private set; }

    public UnitDrag Drag { get; private set; }

    public UnitCard Card => _unitCard;

    private void Start()
    {
        Drag = GetComponent<UnitDrag>();
        Point = transform.GetComponentInParent<SpawnPoint>();

        if (gameObject.GetComponentInParent<SpawnPoint>())
            _isShoot = true;
    }

    private void FixedUpdate()
    {
        _currentTime -= Time.deltaTime;

        if (_isShoot)
            Shoot();

    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.TryGetComponent(out Unit unit))
        {
            if (_unitCard.Grade == unit.Card.Grade)
            {
                if (unit.Drag.Dragging)
                {
                    if (unit._unitCard.Grade < 7)
                    _saveUnit = unit;
                    unit.Drag.OnDragging += DragEnd;
                }
            }
        }  
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.TryGetComponent(out Unit unit))
        {
            if (unit == _saveUnit)
            {
                unit.Drag.OnDragging -= DragEnd;
                _saveUnit = null;
            }
        }
    }

    public void SetSpawner(EnemySpawner enemySpawner)
    {
        _spawner = enemySpawner;
    }    

    private void Shoot()
    {
        if (_currentTime <= 0 && _spawner.EnemyList.Count > 0)
        {
            Bullet bullet = null;
            bullet = Instantiate(_bullet, transform.position, Quaternion.identity);
            bullet.Initialize(_unitCard.Damage, _unitCard.ParticleSystem, _spawner.EnemyList[0]);
            _currentTime = _unitCard.AttackSpeed; 
            _audioSource.Play();  
        }
    }

    private void DragEnd()
    {
        Drag.ChangeCombineValue();
        Instantiate(_nextCard.Tamplate, Point.transform).GetComponent<Unit>().SetSpawner(_spawner);
        _saveUnit.Point.ChangeValue();
        Destroy(_saveUnit.gameObject);
        Destroy(this.gameObject);
    }
}
