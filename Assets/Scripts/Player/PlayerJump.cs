using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerJump : MonoBehaviour
{
    public float JumpForce;
    public Transform GroundCheck;
    public LayerMask WhatIsGround;
    public float CheckSizeX;
    public float CheckSizeY;

    private Player _player;
    private bool _isGrounded;

    void Start()
    {
        _player = GetComponent<Player>();
    }

    void Update()
    {
        // ���� �� ��� �ִ��� üũ
        _isGrounded = Physics2D.OverlapBox(GroundCheck.position - new Vector3(0, 0.5f - (CheckSizeY / 2f)), new Vector2(CheckSizeX, CheckSizeY), 0f, WhatIsGround);

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _player.Rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnDrawGizmos()
    {
        // üũ ���� �ð�ȭ
        Gizmos.DrawCube(GroundCheck.position - new Vector3(0, 0.5f - (CheckSizeY / 2f)), new Vector2(CheckSizeX, CheckSizeY));
    }
}