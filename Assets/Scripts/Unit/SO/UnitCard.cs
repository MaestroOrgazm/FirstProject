using UnityEngine;

[CreateAssetMenu(fileName = "New Unit", menuName = "Unit/Create new Unit", order = 51)]

public class UnitCard : ScriptableObject
{
    [SerializeField] private int _grade = 0;
    [SerializeField] private int _price = 5;
    [SerializeField] private int _damage = 10;
    [SerializeField] private int _bulletSpeed = 5;
    [SerializeField] private float _attackSpeed = 1;
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private GameObject _template;

    public GameObject Tamplate => _template; 
    public int Price => _price;
    public int Grade => _grade;
    public int BulletSpeed => _bulletSpeed;
    public float AttackSpeed => _attackSpeed;
    public float Damage => _damage;
    public ParticleSystem ParticleSystem => _particleSystem;
}
