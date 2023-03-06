using TMPro;
using UnityEngine;

[RequireComponent(typeof (UnitDrag))]

public class Unit : MonoBehaviour
{
    [SerializeField] private UnitCard _nextCard;
    [SerializeField] private UnitCard _unitCard;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private TMP_Text _tmpText;

    private Unit _saveUnit;
    private EnemySpawner _spawner;
    private float _currentTime = 0;
    private bool _isGround = true;

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
        Shoot();

        if (_isGround)
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

    public void GroundChange()
    {
        _isGround = !_isGround;
    }

    public void SetSpawner(EnemySpawner enemySpawner)
    {
        _spawner = enemySpawner;
    }    

    private void Shoot()
    {
        if (_currentTime <= 0)
        {
            Bullet bullet = null;
            bullet = Instantiate(_bullet, transform.position, Quaternion.identity);
            bullet.SetValue(_unitCard.Damage, _unitCard.BulletSpeed, _unitCard.ParticleSystem, _spawner);
            _currentTime = _unitCard.AttackSpeed;
        }
    }

    private void DragEnd(bool drag)
    {
        Drag.ChangeCombineValue();
        Instantiate(_nextCard.Tamplate, Point.transform).GetComponent<Unit>().SetSpawner(_spawner);
        _saveUnit.Point.ChangeValue();
        Destroy(_saveUnit.gameObject);
        Destroy(this.gameObject);
    }
}
