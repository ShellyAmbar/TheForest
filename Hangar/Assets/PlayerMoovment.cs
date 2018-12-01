using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoovment : MonoBehaviour {


    [SerializeField] private string HorizontalInputName;
    [SerializeField] private string VerticalInputName;
    [SerializeField] private float MovementSpeed;

    private CharacterController characterController;
    private bool IsJumping;

    [SerializeField] private AnimationCurve JumpingFallOff;
    [SerializeField] private KeyCode JumpKey;
    [SerializeField] private float JumpMultiplier;


    private void Awake()
    {
        characterController = GetComponent<CharacterController>();

    }
    private void Update()
    {
        PlayerMovement();
    }
    private void PlayerMovement()
    {
        float VerticalInputAxis = Input.GetAxis(VerticalInputName) * MovementSpeed;
        float HorizonalInputAxis = Input.GetAxis(HorizontalInputName) * MovementSpeed;

        Vector3 ForwardMovement = transform.forward * VerticalInputAxis; //Axis Z
        Vector3 RightMovment = transform.right * HorizonalInputAxis; //Axis X

        characterController.SimpleMove(ForwardMovement + RightMovment);
        JumpInput();

    }
    private void JumpInput()
    {
        if (Input.GetKeyDown(JumpKey) && !IsJumping)
        {
            IsJumping = true;
            StartCoroutine(JumpEvent());
        }

    }

    private IEnumerator JumpEvent()
    {
        characterController.slopeLimit = 90.0f;
        float TimeInAir = 0.0f;
        do
        {
            float JumpForce = JumpingFallOff.Evaluate(TimeInAir);
            characterController.Move(Vector3.up * JumpForce * JumpMultiplier * Time.deltaTime);
            TimeInAir += Time.deltaTime;

            yield return null;
        } while (!characterController.isGrounded && characterController.collisionFlags != CollisionFlags.Above);
        IsJumping = false;
        characterController.slopeLimit = 45.0f;
    }
}
