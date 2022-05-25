using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Height : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _text;

    void Update()
    {
        int tempText = (int)_player.transform.position.y;
       _text.text = tempText.ToString();
    }
}