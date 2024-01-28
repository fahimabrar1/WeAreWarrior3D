using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMover : MonoBehaviour
{
    public Soldier soldier;

    private float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = soldier.soldierReusableData.ProjectileSpeed;
        UpdateRotation();
    }

    void UpdateRotation()
    {
        if (soldier.soldierReusableData.closestSoldier != null)
        {
            Vector3 direction = (soldier.soldierReusableData.closestSoldier.transform.position - transform.position).normalized;
            Quaternion newRotation = Quaternion.LookRotation(direction);

            // Apply the original X and Z rotations
            newRotation.eulerAngles = new Vector3(0, newRotation.eulerAngles.y, 0);
            transform.rotation = newRotation;
        }
        else
        {
            Vector3 direction = (soldier.soldierReusableData.soldierBaseTarget.transform.position - transform.position).normalized;

            Quaternion newRotation = Quaternion.LookRotation(direction);

            // Apply the original X and Z rotations
            newRotation.eulerAngles = new Vector3(0, newRotation.eulerAngles.y, 0);
            transform.rotation = newRotation;
        }
    }



    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        // Move the object forward in its local space
        transform.Translate(moveSpeed * Time.fixedDeltaTime * Vector3.forward);
    }
}
