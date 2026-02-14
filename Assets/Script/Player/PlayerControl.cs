using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    public  bool disable=false;
    public float speed = 1;
    public float jumpForce = 1;
    private float _moveInput;
    public GameObject Image;
    private SpriteRenderer _renderer;
    private PlayerState _playerState;
    private Rigidbody2D _rb;

    
    

    public IEnumerator OffPlayerControl()//暂时取消玩家移动
    {
        disable = true;
        yield return new WaitForSeconds(0.3f);
        disable = false;
    }
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        
        _renderer = Image.GetComponent<SpriteRenderer>();
        _playerState = GetComponent<PlayerState>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<float>();
        
        if (_moveInput < 0)
            _renderer.flipX = true;
        if(_moveInput > 0)
            _renderer.flipX = false;
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if(_playerState.OnGround&&Mathf.Abs(_rb.velocity.y)<3 &&context.phase==InputActionPhase.Performed)
            _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    public void OnDown(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed)
        {
            RaycastHit2D hit = Physics2D.Raycast(_rb.position, Vector2.down, 1.5f, ~(1 << 3));
            if (hit.collider != null)
            {
                
                if (hit.transform.CompareTag("platform"))
                {
                    
                    Platform platform = hit.collider.GetComponent<Platform>();
                    platform.StartTurnOff();
                }
            }
        }
        
    }

    public void OnESC(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed)
        {
            if (GameManager.Instance.GetGameState() == GameState.InGame)
            {
                //只有在游戏内才能暂停
                GameManager.Instance.ChangeGameState(GameState.Pause);
                return;
            }

            if (GameManager.Instance.GetGameState() == GameState.Pause)
            {
                //如果已经暂停直接取消
                GameManager.Instance.ChangeGameState(GameState.InGame);
                return;
            }
        }
    }
    
    void Update()
    {
        if(!disable)
        {
            //左右移动
            var vector2 = _rb.velocity;
            vector2.x = _moveInput * (speed);
            _rb.velocity = vector2;
        }
        
    }
}
