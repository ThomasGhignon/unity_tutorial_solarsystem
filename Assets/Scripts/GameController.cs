using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public delegate void SpeedEvent(float newSpeed); 
    public event SpeedEvent OnSpeedChange;
    
    private static GameController _instance = null;
    public static GameController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameController>();
            }
            return _instance;
        }
        
        private set { _instance = value; }
    }

    [Tooltip("The speed at which the object will rotate")]
    private float _speed = 1;
    public float Speed
    {
        get => _speed;
        set
        {
            if (OnSpeedChange != null && value != _speed)
            {
                OnSpeedChange.Invoke(value);
            }
            _speed = value;
        }
    }
    //public float speed { get; set; }
    
    private float _previousSpeed = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        if (GameController.Instance == null)
            GameController.Instance = this;


        if (InputController.Instance)
            InputController.Instance.OnUserPause += Pause;
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    public void Pause() {
        if (this.Speed != 0.0f) {
            this._previousSpeed = this.Speed;
            this.Speed = 0.0f;
        }
        else
        {
            this.Speed = this._previousSpeed == 0.0f ? 1.0f : this._previousSpeed;
        }
    }
}