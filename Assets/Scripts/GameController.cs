using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance = null;

    [Tooltip("The speed at which the object will rotate")] [Range(-10, 10)]
    public float speed = 1.0f;
    
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
        if (this.speed != 0.0f) {
            this._previousSpeed = this.speed;
            this.speed = 0.0f;
        }
        else
        {
            this.speed = this._previousSpeed == 0.0f ? 1.0f : this._previousSpeed;
        }
    }
}