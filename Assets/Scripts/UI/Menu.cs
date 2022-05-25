using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Sprite _mute;
    [SerializeField] private Image _image;
    
    private Sprite _loud;
    private bool _isSound = true;

    private void Start()
    {
        _loud = _image.sprite;
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Play ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void Mute()
    {
        if (_isSound == true)
        {
            AudioListener.volume = 0;
            _isSound = false;
            _image.sprite = _mute;
        }
        else
        {
            AudioListener.volume = 1;
            _isSound = true;
             _image.sprite = _loud;
        }

    }
}
