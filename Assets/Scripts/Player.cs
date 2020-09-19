using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    float _speed = 5f;
    [SerializeField]
    float _gravity = 1.0f;
    [SerializeField]
    float _jumpHeight = 15.0f;
    [SerializeField]
    int _coins = 0;
    [SerializeField]
    private UIManager _uiManager;

    private float _yVelocity;

    private CharacterController _controller;
    private bool _canDoubleJump;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(horizontal, 0, 0);
        Vector3 velocity = direction *_speed;

        if (_controller.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _yVelocity = _jumpHeight;
                _canDoubleJump = true;
            }
        }
        else
        {
            if (_canDoubleJump && Input.GetKeyDown(KeyCode.Space))
            {
                _canDoubleJump = false;
                _yVelocity += 1.5f * _jumpHeight;
            }
            _yVelocity -= _gravity;
        }

        velocity.y = _yVelocity;
        _controller.Move(velocity * Time.deltaTime);
    }

    public void CollectCoin()
    {
        _coins++;
        _uiManager.UpdateCoins(_coins);
    }
}
