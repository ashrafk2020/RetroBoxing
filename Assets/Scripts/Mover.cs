using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] Transform frontShape;
     [SerializeField] Transform backShape;
     [SerializeField] Transform upShape;
     [SerializeField] Transform downShape;
    [SerializeField] Fighter fighter;
     [SerializeField] float hitDistance = .5f;
     [SerializeField] LayerMask hittableLayer;
     [SerializeField] CircleCollider2D colliderShape;

     [SerializeField] bool enableMovment;


    private void Update()
    {
        //check movent forward
        HandleHorizontalMovment();
        HandleVerticalMovment();

        if (enableMovment)
        {
            HandleMove();

        }

    }
    private void HandleMove()
    {
        Vector2 moveVector = GetMoveVectors();

        float disX = moveVector.x * moveSpeed * Time.deltaTime;
        float disY = moveVector.y * moveSpeed * Time.deltaTime;

        transform.position = new Vector2(transform.position.x + disX, transform.position.y + disY);
    }

    private  Vector2 GetMoveVectors()
    {
        Vector2 moveVectors = new Vector2();
        if(fighter.GetPlayerLeft())
        {
            if(Input.GetKey(KeyCode.D))
            {
                moveVectors.x = 1f;
            }
            if(Input.GetKeyUp(KeyCode.D))
            {
                moveVectors.x = 0f;

            }

            if(Input.GetKey(KeyCode.A))
            {
                moveVectors.x = -1f;
            }
            if(Input.GetKeyUp(KeyCode.A))
            {
                moveVectors.x = 0f;

            }

             if(Input.GetKey(KeyCode.W))
            {
                moveVectors.y = 1f;
            }
            if(Input.GetKeyUp(KeyCode.W))
            {
                moveVectors.y = 0f;

            }
               if(Input.GetKey(KeyCode.S))
            {
                moveVectors.y = -1f;
            }
            if(Input.GetKeyUp(KeyCode.S))
            {
                moveVectors.y = 0f;

            }
        }
        else
        {
            if(Input.GetKey(KeyCode.RightArrow))
            {
                moveVectors.x = 1f;
            }
            if(Input.GetKeyUp(KeyCode.RightArrow))
            {
                moveVectors.x = 0f;

            }

            if(Input.GetKey(KeyCode.LeftArrow))
            {
                moveVectors.x = -1f;
            }
            if(Input.GetKeyUp(KeyCode.LeftArrow))
            {
                moveVectors.x = 0f;

            }

             if(Input.GetKey(KeyCode.UpArrow))
            {
                moveVectors.y = 1f;
            }
            if(Input.GetKeyUp(KeyCode.UpArrow))
            {
                moveVectors.y = 0f;

            }
               if(Input.GetKey(KeyCode.DownArrow))
            {
                moveVectors.y = -1f;
            }
            if(Input.GetKeyUp(KeyCode.DownArrow))
            {
                moveVectors.y = 0f;

            }
        }
        // return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        return moveVectors;

    }

    public void OnMovement(Vector2 move)
    {
        Vector2 moveVector = new Vector2(move.x,move.y);

        float disX = moveVector.x * moveSpeed * Time.deltaTime;
        float disY = moveVector.y * moveSpeed * Time.deltaTime;

        transform.position = new Vector2(transform.position.x + disX, transform.position.y + disY);
    }

    private void HandleVerticalMovment()
    {
        RaycastHit2D raycastHitUp = Physics2D.Raycast(upShape.position, Vector2.up, hitDistance, hittableLayer);
        if (raycastHitUp.collider != null)
        {
            GoStepDown();
        }

        //check movment backward
        RaycastHit2D raycastHit2Ddown = Physics2D.Raycast(downShape.position, -Vector2.up, hitDistance, hittableLayer);
        if (raycastHit2Ddown.collider != null &&raycastHit2Ddown.collider != colliderShape)
        {
            GoStepUp();
        }
    }

    private void HandleHorizontalMovment()
    {
        RaycastHit2D raycastHitforward = Physics2D.Raycast(frontShape.position, fighter.GetDirection(), hitDistance, hittableLayer);
        if (raycastHitforward.collider != null&& raycastHitforward.collider != colliderShape)
        {
            ReturnStepBackward();
        }

        //check movment backward
        RaycastHit2D raycastHit2DBackward = Physics2D.Raycast(backShape.position, -fighter.GetDirection(), hitDistance, hittableLayer);
        if (raycastHit2DBackward.collider != null && raycastHit2DBackward.collider != colliderShape)
        {
            GoStepForward();
        }
    }


    private void GoStepForward()
    {
        GoStepHorizontal(1f);
    }
     private void ReturnStepBackward()
    {
        GoStepHorizontal(-1f);
    }

    

    private void GoStepDown()
    {
        GoStepVertical(-1f);
    }
    private void GoStepUp()
    {
        GoStepVertical(1f);
    }
     private void GoStepHorizontal(float direction)
    {
         float stepSpeed = 8f;
        float step = stepSpeed* Time.deltaTime;
        Vector3 disX =   direction* fighter.GetDirection()* step;
         transform.position = transform.position + disX;

    }

    private void GoStepVertical(float direction)
    {
         float stepSpeed = 8f;
        float step = stepSpeed* Time.deltaTime;
        Vector3 disY =   direction* Vector3.up* step;
         transform.position = transform.position + disY;

    }

    public bool IsMoving()
    {
        return Mathf.Abs(Input.GetAxisRaw("Horizontal")) > Mathf.Epsilon || Mathf.Abs(Input.GetAxisRaw("Vertical")) > Mathf.Epsilon;
    }

    public void OnTestFighter(Action tryAttack)
    {
        tryAttack();
    }
}
