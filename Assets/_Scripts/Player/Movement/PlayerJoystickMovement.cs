using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class PlayerJoystickMovement : BasePlayerMovement
    {
        [SerializeField] private float rotateSpeed;
        [SerializeField] private float maxAngleToMove;
        
        private Joystick _joystick;

        protected override void Awake()
        {
            base.Awake();
            _joystick = FindObjectOfType<Joystick>(); 
        }

        
        protected override void Update()
        {
            if (player.State != PlayerState.Moving)
            {
                rb.angularVelocity = Vector3.zero;
                return;
            }
            
            base.Update();

            if (canMoveForwards)
            {
                HandleMovement();	
            }
        }
        
        public void HandleMovement()
        {
            Vector3 move = new Vector3(_joystick.Horizontal, 0, _joystick.Vertical);

            Transform cameraTransform = Helpers.Camera.transform;
            Vector3 camForward = cameraTransform.forward;
            Vector3 camRight = cameraTransform.right;

            camForward.y = 0;
            camRight.y = 0;
            camForward = camForward.normalized;
            camRight = camRight.normalized;

            Vector3 camRelativeDir = (camForward * move.z + camRight * move.x); 
            
            if (move != Vector3.zero)
            {
                IsMoving = true;
                HandleRotation(camRelativeDir);
            }
            else
            {
                IsMoving = false; 
            }

            float angleToDirection = Vector3.Angle(transform.forward, camRelativeDir); 
            
            if(angleToDirection <= maxAngleToMove)
                transform.position += camRelativeDir * forwardsSpeed * Time.deltaTime;
        }

        private void HandleRotation(Vector3 targetDir)
        {
            float step = rotateSpeed * Time.deltaTime;
            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
            Debug.DrawRay(transform.position, newDir, Color.red);
            transform.rotation = Quaternion.LookRotation(newDir); 
        }
    }
}
