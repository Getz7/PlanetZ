using UnityEngine;

// Client
public class PlayerInputHandler : MonoBehaviour
{
    private ICommand _jumpCommand;
    private ICommand _specialJumpCommand;
    private bool _presionada;
    private float _PressTime;
    private float _intervaloT = 0.3f;

    public void SetJumpCommand(ICommand command)
    {
        _jumpCommand = command;
    }

    public void SetSpecialJumpCommand(ICommand command)
    {
        _specialJumpCommand = command;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_presionada && Time.time - _PressTime <= _intervaloT)
            {
                _specialJumpCommand?.Execute();
                _presionada = false;
            }
            else
            {
                _presionada = true;
                _PressTime = Time.time;
                _jumpCommand?.Execute();
            }
        }
    }
}
