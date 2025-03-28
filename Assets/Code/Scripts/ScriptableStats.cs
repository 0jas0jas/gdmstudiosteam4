using UnityEngine;

    [CreateAssetMenu]
    public class ScriptableStats : ScriptableObject
    {
        [Header("LAYERS")] [Tooltip("Layers that should be treated as ground")]
        public LayerMask GroundLayer;

        [Tooltip("Layers that can be walljumped off of")]
        public LayerMask ClimbableLayer;

        [Header("INPUT")] [Tooltip("Makes all Input snap to an integer. Prevents gamepads from walking slowly. Recommended value is true to ensure gamepad/keybaord parity.")]
        public bool SnapInput = true;

        [Tooltip("Minimum input required before you mount a ladder or climb a ledge. Avoids unwanted climbing using controllers"), Range(0.01f, 0.99f)]
        public float VerticalDeadZoneThreshold = 0.3f;

        [Tooltip("Minimum input required before a left or right is recognized. Avoids drifting with sticky controllers"), Range(0.01f, 0.99f)]
        public float HorizontalDeadZoneThreshold = 0.1f;

        [Header("MOVEMENT")] [Tooltip("The top horizontal movement speed")]
        public float MaxSpeed = 14;

        [Tooltip("The player's capacity to gain horizontal speed on the ground")]
        public float GroundAcceleration = 120;

        [Tooltip("The player's capacity to gain horizontal speed in the air")]
        public float AirAcceleration = 120;

        [Tooltip("The pace at which the player comes to a stop")]
        public float GroundDeceleration = 60;

        [Tooltip("Deceleration in air only after stopping input mid-air")]
        public float AirDeceleration = 30;

        [Tooltip("A constant downward force applied while grounded. Helps on slopes"), Range(0f, -10f)]
        public float GroundingForce = -1.5f;

        [Tooltip("The speed at which the player slides down a wall")]
        public float WallSlideForce = -2f;

        [Tooltip("The detection distance for grounding and roof detection"), Range(0f, 0.5f)]
        public float GrounderDistance = 0.05f;

        [Header("JUMP")] [Tooltip("The immediate velocity applied when jumping")]
        public float JumpPower = 36;

        [Tooltip("The maximum vertical movement speed")]
        public float MaxFallSpeed = 40;

        [Tooltip("The player's capacity to gain fall speed. a.k.a. In Air Gravity")]
        public float FallAcceleration = 110;

        [Tooltip("The gravity multiplier added when jump is released early")]
        public float JumpEndEarlyGravityModifier = 3;

        [Tooltip("The time before coyote jump becomes unusable. Coyote jump allows jump to execute even after leaving a ledge")]
        public float CoyoteTime = .15f;

        [Tooltip("The amount of time we buffer a jump. This allows jump input before actually hitting the ground")]
        public float JumpBuffer = .2f;

        [Header("Grapple")] [Tooltip("The player's capacity to gain horizontal speed while grappled")]
        public float GrappleAcceleration = 120;

        [Tooltip("The top horizontal movement speed while grappled")]
        public float MaxSpeedGrappled = 14;

        [Tooltip("The time after grappling when a mid-air jump is possible")]
        public float GrappleGrace = .30f;

        [Tooltip("The time after grappling when a large mid-air jump is possible")]
        public float BoostJumpWindow = .15f;

        [Tooltip("Immediate velocity applied on boosted jump")]
        public float BoostJumpPower = 50;

        [Header("Dash")] [Tooltip("Speed player moves while dashing")]
        public float DashSpeed = 40f;

        [Tooltip("Deceleration while dashing")]
        public float DashDeceleration = 40f;

        [Tooltip("Amount of time player dashses for")]
        public float DashTime = .5f;

        [Tooltip("Window of time player can change direction after dashing")]
        public float DashBuffer = .1f;
    }