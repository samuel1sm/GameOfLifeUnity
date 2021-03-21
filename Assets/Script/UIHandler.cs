using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{

    [SerializeField] private Player _player;
    [SerializeField] private Image pauseImage; 
    
    // Start is called before the first frame update
    void Start()
    {
        _player.RunGame += RunGame;
    }

    private void RunGame(bool obj)
    {
        pauseImage.color = obj ? Color.green : Color.red ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
