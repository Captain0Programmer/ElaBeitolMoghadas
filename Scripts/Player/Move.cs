using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    CharacterController Contoroller;
    public float Speed = 10f;
    public float Gravity = -9.81f;
    Vector3 Velocity;
    public Vector3 GroundCheckPos;
    public float GroundCheckRaduis;
    public LayerMask GroundCheckLayerMask;
    bool IsGrounded = false;
    public float JumpPower;
    private void Start()
    {
        Contoroller = GetComponent<CharacterController>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Jump")&&IsGrounded == true)
        {
            Velocity.y = Mathf.Sqrt(JumpPower * -2f * Gravity);
        }
        IsGrounded = Physics.CheckSphere(transform.position + GroundCheckPos, GroundCheckRaduis, GroundCheckLayerMask);
        if (IsGrounded && Velocity.y < 0f)
        {
            Velocity.y = -2;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 Move = transform.right * x + transform.forward * z;
        Contoroller.Move(Move * Speed * Time.deltaTime);
        Velocity.y += Gravity * Time.deltaTime;
        Contoroller.Move(Velocity * Time.deltaTime);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position + GroundCheckPos, GroundCheckRaduis);
    }
}
