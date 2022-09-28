using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{

    public PlanetOrbitPreset preset;
    [Tooltip("Child planet")]
    public GameObject planet;
        
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<AutoRotate>().speed = this.preset.orbitalSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        this.Rotate();
        this.MovePlanetToRadius();
    }

    private void MovePlanetToRadius()
    {
        this.planet.transform.localPosition = new Vector3(this.preset.orbitalRadius, 0, 0);
    }

    private void Rotate()
    {
        float angle = this.preset.orbitalSpeed;
        float dt = Time.deltaTime;
        angle *= dt;

        if (GameController.Instance)
            angle = angle * GameController.Instance.Speed;

        this.transform.Rotate(Vector3.up, angle, Space.Self);
    }
}
