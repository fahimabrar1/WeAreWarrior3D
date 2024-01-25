

using UnityEngine;

// Class for calculating random points within a bounds
public class RandomPointGenerator
{
    // Generates a random point given bounds
    public static Vector3 RandomPointInBounds(Bounds bounds)
    {
        // Return new vector3 with random x, bottom y, random z within bounds
        return new Vector3(
            // Generate random x within bounds.min.x and bounds.max.x
            Random.Range(bounds.min.x, bounds.max.x),
            // Set y to bottom of the bounds
            bounds.min.y,
            // Generate random z within bounds.min.z and bounds.max.z
            Random.Range(bounds.min.z, bounds.max.z)
        );
    }
}