using System.Drawing;
using TMPro;
using UnityEngine;

[RequireComponent(typeof (UnitDrag))]

public class Unit : MonoBehaviour
{
    [SerializeField] private UnitCard _nextCard;
    [SerializeField] private UnitCard _unitCard;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private TMP_Text _tmpText;
    [SerializeField] private AudioSource _audioSource;

    private Unit _saveUnit;
    private EnemySpawner _spawner;
    private float _currentTime = 0;
    private SpawnPoint _spawnPoint;

    public SpawnPoint Point { get; private set; }

    public UnitDrag Drag { get; private set; }

    public UnitCard Card => _unitCard;

    private void Start()
    {
        Drag = GetComponent<UnitDrag>();
        Point = transform.GetComponentInParent<SpawnPoint>();
    }

    private void FixedUpdate()
    {
        _currentTime -= Time.deltaTime;

        if (gameObject.GetComponentInParent<SpawnPoint>())
            Shoot();

        if (gameObject.GetComponentInParent<SpawnPoint>())
            _tmpText.text = $"Lvl. {_unitCard.Grade}";
        else
            _tmpText.text = null;
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
        else if (collider.gameObject.TryGetComponent<Box>(out Box box))
        {
            _spawnPoint = box.gameObject.GetComponentInParent<SpawnPoint>();
            if (_spawnPoint != null)
            {
                if (_spawnPoint.IsEmployed)
                {
                    this.Drag.OnDragging += ChangeCell;
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
        else if (collider.gameObject.TryGetComponent(out Box box))
        {
            this.Drag.OnDragging -= ChangeCell;
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

    private void ChangeCell()
    {
        transform.SetParent(_spawnPoint.gameObject.transform);
    }
}
