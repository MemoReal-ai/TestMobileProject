using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharecterController : MonoBehaviour, IControllebl
{
    [SerializeField,Range(1,1000)] private float speed = 1f;
    [SerializeField] private float gravity = 9.81f;

    private CharacterController _characterController;
    private Vector3 _moveDirection;
    private float _velocity;
    private bool _isGrounded=true;
    private readonly float _basicVelocityOnFall = -2f;

    private void OnValidate()
    {
        gravity = 9.81f;
    }

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
       
        if (_characterController == null)
            throw new System.Exception("Nothing characterController");

    }

    private void FixedUpdate()
    {    if (_isGrounded==true)
        {
            _velocity = _basicVelocityOnFall;
        }
        MoveInternal();
        DoGraviti();
       
    }

    public void Move(Vector3 direction)
    {
      _moveDirection = direction;
    }

    private void MoveInternal()
    {
        _characterController.Move(_moveDirection * speed * Time.fixedDeltaTime);
    }

    private void DoGraviti()
    {
        _velocity += gravity * Time.fixedDeltaTime;
        _characterController.Move(Vector3.up*_velocity*Time.fixedDeltaTime);
    }
}
