using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    private ICommand _jumpCommand;
    private ICommand _specialJumpCommand;
    private bool _spaceKeyPressed;
    private float _lastSpaceKeyPressTime;
    private float _doublePressInterval = 0.3f; // Adjust this value to set the double press interval

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
            if (_spaceKeyPressed && Time.time - _lastSpaceKeyPressTime <= _doublePressInterval)
            {
                _specialJumpCommand?.Execute();
                _spaceKeyPressed = false;
            }
            else
            {
                _spaceKeyPressed = true;
                _lastSpaceKeyPressTime = Time.time;
                _jumpCommand?.Execute();
            }
        }
    }
}
