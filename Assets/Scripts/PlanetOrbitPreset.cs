using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]

public class PlanetOrbitPreset : ScriptableObject
{
    [Range(-100, 1000)]
    [Tooltip("The speed of the planet's rotation in degree per second")]
    public float orbitalSpeed;
    
    [Range(0, 10000)]
    [Tooltip("Distance of the planet from the sun (orbit) in units")]
    public float orbitalRadius;
}
