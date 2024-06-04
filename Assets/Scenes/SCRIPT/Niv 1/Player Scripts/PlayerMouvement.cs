

using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

	public PlayerData Data;

	#region Variables
    public Rigidbody2D RB { get; private set; }

	public bool IsFacingRight { get; private set; }
	public bool IsJumping { get; private set; }
	public bool IsWallJumping { get; private set; }
	public bool IsSliding { get; private set; }


	public float LastOnGroundTime { get; private set; }
	public float LastOnWallTime { get; private set; }
	public float LastOnWallRightTime { get; private set; }
	public float LastOnWallLeftTime { get; private set; }


	public bool _isJumpCut;
	public bool _isJumpFalling;


	public float _wallJumpStartTime;
	public int _lastWallJumpDir;

	public Vector2 _moveInput;
	public float LastPressedJumpTime { get; private set; }

	public bool CanMoove = true;


	[Header("Checks")] 
	[SerializeField] public Transform _groundCheckPoint;

	[SerializeField] public Vector2 _groundCheckSize = new Vector2(0.49f, 0.03f);
	[Space(5)]
	[SerializeField] public Transform _frontWallCheckPoint;
	[SerializeField] public Transform _backWallCheckPoint;
	[SerializeField] public Vector2 _wallCheckSize = new Vector2(0.5f, 1f);

    [Header("Layers & Tags")]
	[SerializeField] public LayerMask _groundLayer;
	#endregion

    public void Awake()
	{
		RB = GetComponent<Rigidbody2D>();
	}

	public void Start()
	{
		SetGravityScale(Data.gravityScale);
		IsFacingRight = true;
		CanMoove = true;
	}

	public void Update()
	{
        if (CanMoove == true)
		{
			#region TIMERS

			RB.constraints=RigidbodyConstraints2D.None;

			LastOnGroundTime -= Time.deltaTime;
			LastOnWallTime -= Time.deltaTime;
			LastOnWallRightTime -= Time.deltaTime;
			LastOnWallLeftTime -= Time.deltaTime;

			LastPressedJumpTime -= Time.deltaTime;
			#endregion

			#region INPUT HANDLER
			_moveInput.x = Input.GetAxisRaw("Horizontal");
			_moveInput.y = Input.GetAxisRaw("Vertical");

			if (_moveInput.x != 0)
				CheckDirectionToFace(_moveInput.x > 0);

			if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton1))
			{
				OnJumpInput();
			}

			if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton1))
			{
				OnJumpUpInput();
			}
			#endregion

			#region COLLISION CHECKS
			if (!IsJumping)
			{

				if (Physics2D.OverlapBox(_groundCheckPoint.position, _groundCheckSize, 0, _groundLayer) && !IsJumping)
				{
					LastOnGroundTime = Data.coyoteTime;
				}		


				if (((Physics2D.OverlapBox(_frontWallCheckPoint.position, _wallCheckSize, 0, _groundLayer) && IsFacingRight)
						|| (Physics2D.OverlapBox(_backWallCheckPoint.position, _wallCheckSize, 0, _groundLayer) && !IsFacingRight)) && !IsWallJumping)
					LastOnWallRightTime = Data.coyoteTime;


				if (((Physics2D.OverlapBox(_frontWallCheckPoint.position, _wallCheckSize, 0, _groundLayer) && !IsFacingRight)
					|| (Physics2D.OverlapBox(_backWallCheckPoint.position, _wallCheckSize, 0, _groundLayer) && IsFacingRight)) && !IsWallJumping)
					LastOnWallLeftTime = Data.coyoteTime;


				LastOnWallTime = Mathf.Max(LastOnWallLeftTime, LastOnWallRightTime);
			}
			#endregion

			#region JUMP CHECKS
			if (IsJumping && RB.velocity.y < 0)
			{
				IsJumping = false;

				if(!IsWallJumping)
					_isJumpFalling = true;
			}

			if (IsWallJumping && Time.time - _wallJumpStartTime > Data.wallJumpTime)
			{
				IsWallJumping = false;
			}

			if (LastOnGroundTime > 0 && !IsJumping && !IsWallJumping)
			{
				_isJumpCut = false;

				if(!IsJumping)
					_isJumpFalling = false;
			}


			if (CanJump() && LastPressedJumpTime > 0)
			{
				IsJumping = true;
				IsWallJumping = false;
				_isJumpCut = false;
				_isJumpFalling = false;
				Jump();
			}

			else if (CanWallJump() && LastPressedJumpTime > 0)
			{
				IsWallJumping = true;
				IsJumping = false;
				_isJumpCut = false;
				_isJumpFalling = false;
				_wallJumpStartTime = Time.time;
				_lastWallJumpDir = (LastOnWallRightTime > 0) ? -1 : 1;
				
				WallJump(_lastWallJumpDir);
			}
			#endregion

			#region SLIDE CHECKS
			if (CanSlide() && ((LastOnWallLeftTime > 0 && _moveInput.x < 0) || (LastOnWallRightTime > 0 && _moveInput.x > 0)))
				IsSliding = true;
			else
				IsSliding = false;
			#endregion

			#region GRAVITY

			if (IsSliding)
			{
				SetGravityScale(0);
			}
			else if (RB.velocity.y < 0 && _moveInput.y < 0)
			{

				SetGravityScale(Data.gravityScale * Data.fastFallGravityMult);

				RB.velocity = new Vector2(RB.velocity.x, Mathf.Max(RB.velocity.y, -Data.maxFastFallSpeed));
			}
			else if (_isJumpCut)
			{

				SetGravityScale(Data.gravityScale * Data.jumpCutGravityMult);
				RB.velocity = new Vector2(RB.velocity.x, Mathf.Max(RB.velocity.y, -Data.maxFallSpeed));
			}
			else if ((IsJumping || IsWallJumping || _isJumpFalling) && Mathf.Abs(RB.velocity.y) < Data.jumpHangTimeThreshold)
			{
				SetGravityScale(Data.gravityScale * Data.jumpHangGravityMult);
			}
			else if (RB.velocity.y < 0)
			{

				SetGravityScale(Data.gravityScale * Data.fallGravityMult);

				RB.velocity = new Vector2(RB.velocity.x, Mathf.Max(RB.velocity.y, -Data.maxFallSpeed));
			}
			else
			{

				SetGravityScale(Data.gravityScale);
			}
    	}
		
		if(CanMoove==false)
		{
			RB.constraints=RigidbodyConstraints2D.FreezePosition;
		}
		#endregion
	

	}

    public void FixedUpdate()
	{

		if (IsWallJumping)
			Run(Data.wallJumpRunLerp);
		else
			Run(1);


		if (IsSliding)
			Slide();
    }

    #region INPUT CALLBACKS

    public void OnJumpInput()
	{
		LastPressedJumpTime = Data.jumpInputBufferTime;
	}

	public void OnJumpUpInput()
	{
		if (CanJumpCut() || CanWallJumpCut())
			_isJumpCut = true;
	}
    #endregion

    #region GENERAL METHODS
    public void SetGravityScale(float scale)
	{
        RB.gravityScale = scale;		
	}
    #endregion


    #region RUN METHODS
    public void Run(float lerpAmount)
	{

		float targetSpeed = _moveInput.x * Data.runMaxSpeed;

		targetSpeed = Mathf.Lerp(RB.velocity.x, targetSpeed, lerpAmount);

		#region Calculate AccelRate
		float accelRate;



		if (LastOnGroundTime > 0)
			accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? Data.runAccelAmount : Data.runDeccelAmount;
		else
			accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? Data.runAccelAmount * Data.accelInAir : Data.runDeccelAmount * Data.deccelInAir;
		#endregion

		#region Add Bonus Jump Apex Acceleration

		if ((IsJumping || IsWallJumping || _isJumpFalling) && Mathf.Abs(RB.velocity.y) < Data.jumpHangTimeThreshold)
		{
			accelRate *= Data.jumpHangAccelerationMult;
			targetSpeed *= Data.jumpHangMaxSpeedMult;
		}
		#endregion

		#region Conserve Momentum
	
		if(Data.doConserveMomentum && Mathf.Abs(RB.velocity.x) > Mathf.Abs(targetSpeed) && Mathf.Sign(RB.velocity.x) == Mathf.Sign(targetSpeed) && Mathf.Abs(targetSpeed) > 0.01f && LastOnGroundTime < 0)
		{

			accelRate = 0; 
		}
		#endregion


		float speedDif = targetSpeed - RB.velocity.x;


		float movement = speedDif * accelRate;


		RB.AddForce(movement * Vector2.right, ForceMode2D.Force);

	}

	public void Turn()
	{

		Vector3 scale = transform.localScale; 
		scale.x *= -1;
		transform.localScale = scale;

		IsFacingRight = !IsFacingRight;
	}
    #endregion

    #region JUMP METHODS
    public void Jump()
	{

		LastPressedJumpTime = 0;
		LastOnGroundTime = 0;

		#region Perform Jump

		float force = Data.jumpForce;
		if (RB.velocity.y < 0)
			force -= RB.velocity.y;

		RB.AddForce(Vector2.up * force, ForceMode2D.Impulse);
		#endregion
	}

	public void WallJump(int dir)
	{

		LastPressedJumpTime = 0;
		LastOnGroundTime = 0;
		LastOnWallRightTime = 0;
		LastOnWallLeftTime = 0;

		#region Perform Wall Jump
		Vector2 force = new Vector2(Data.wallJumpForce.x, Data.wallJumpForce.y);
		force.x *= dir;

		if (Mathf.Sign(RB.velocity.x) != Mathf.Sign(force.x))
			force.x -= RB.velocity.x;

		if (RB.velocity.y < 0)
			force.y -= RB.velocity.y;


		RB.AddForce(force, ForceMode2D.Impulse);
		#endregion
	}
	#endregion

	#region OTHER MOVEMENT METHODS
	public void Slide()
	{

		float speedDif = Data.slideSpeed - RB.velocity.y;
		float movement = speedDif * Data.slideAccel;

		movement = Mathf.Clamp(movement, -Mathf.Abs(speedDif)  * (1 / Time.fixedDeltaTime), Mathf.Abs(speedDif) * (1 / Time.fixedDeltaTime));

		RB.AddForce(movement * Vector2.up);
	}
    #endregion


    #region CHECK METHODS
    public void CheckDirectionToFace(bool isMovingRight)
	{
		if (isMovingRight != IsFacingRight)
			Turn();
	}

    public bool CanJump()
    {
		return LastOnGroundTime > 0 && !IsJumping;
    }

	public bool CanWallJump()
    {
		return LastPressedJumpTime > 0 && LastOnWallTime > 0 && LastOnGroundTime <= 0 && (!IsWallJumping ||
			 (LastOnWallRightTime > 0 && _lastWallJumpDir == 1) || (LastOnWallLeftTime > 0 && _lastWallJumpDir == -1));
	}

	public bool CanJumpCut()
    {
		return IsJumping && RB.velocity.y > 0;
    }

	public bool CanWallJumpCut()
	{
		return IsWallJumping && RB.velocity.y > 0;
	}

	public bool CanSlide()
    {
		if (LastOnWallTime > 0 && !IsJumping && !IsWallJumping && LastOnGroundTime <= 0)
			return true;
		else
			return false;
	}
    #endregion


    #region EDITOR METHODS
    public void OnDrawGizmosSelected()
    {
		Gizmos.color = Color.green;
		Gizmos.DrawWireCube(_groundCheckPoint.position, _groundCheckSize);
		Gizmos.color = Color.blue;
		Gizmos.DrawWireCube(_frontWallCheckPoint.position, _wallCheckSize);
		Gizmos.DrawWireCube(_backWallCheckPoint.position, _wallCheckSize);
	}
    #endregion
}