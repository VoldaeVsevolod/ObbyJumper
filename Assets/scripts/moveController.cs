using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class moveController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private Animator _animator;

    [SerializeField] private float _speed;
    [SerializeField] private Vector3 _jumpPower;
    private bool _jumpFlag = true;

    public void Jump()
    {
        if (_jumpFlag)
        {
            _rigidbody.velocity += _jumpPower;
            _animator.SetBool("Jump", true);
            _jumpFlag = false;
            Debug.Log(_jumpFlag);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        _animator.SetBool("Jump", false);
        _jumpFlag = true;
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector3(_joystick.Horizontal * _speed, _rigidbody.velocity.y, _joystick.Vertical * _speed);

        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(-(_rigidbody.velocity));
            _animator.SetBool("Move", true);
        }

        else
        {
            _animator.SetBool("Move", false);
        }
    }
}
