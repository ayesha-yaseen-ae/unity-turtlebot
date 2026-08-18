using UnityEngine;

public class circularmotion : MonoBehaviour
{
    [Header("Physics Motor Tuning")]
    public float motorPower = 8000f;     // Power to drive the wheels forward
    public float turnMultiplier = 4.0f;  // Higher value = tighter, sharper circle turning

    [Header("Assign Wheel Links")]
    public ArticulationBody leftWheel;
    public ArticulationBody rightWheel;

    void Start()
    {
        // Double check everything is awake on startup
        ArticulationBody[] bodies = GetComponentsInChildren<ArticulationBody>();
        foreach (ArticulationBody body in bodies)
        {
            body.enabled = true;
        }
    }

    void FixedUpdate()
    {
        if (leftWheel == null || rightWheel == null) return;

        float leftForce = 0f;
        float rightForce = 0f;

        // PRESS W + D (or UP + RIGHT) to drive in a tight circle
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && 
            (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)))
        {
            // Left wheel surges forward, right wheel holds back -> forces a sharp clockwise circle
            leftForce = motorPower * turnMultiplier;
            rightForce = motorPower / turnMultiplier;
        }
        // PRESS W + A (or UP + LEFT) to drive in a tight counter-clockwise circle
        else if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && 
                 (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)))
        {
            leftForce = motorPower / turnMultiplier;
            rightForce = motorPower * turnMultiplier;
        }
        // PRESS ONLY W (or UP) to go straight
        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            leftForce = motorPower;
            rightForce = motorPower;
        }
        // PRESS ONLY S (or DOWN) to reverse straight
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            leftForce = -motorPower;
            rightForce = -motorPower;
        }
        // IF NO BUTTONS ARE PRESSED -> Complete Stop
        else
        {
            leftForce = 0f;
            rightForce = 0f;
        }

        // Send forces straight to the physics engine solver
        ApplyPhysicsVelocity(leftWheel, leftForce);
        ApplyPhysicsVelocity(rightWheel, rightForce);
    }

    void ApplyPhysicsVelocity(ArticulationBody wheel, float forceValue)
    {
        ArticulationDrive drive = wheel.xDrive;
        drive.targetVelocity = forceValue;
        wheel.xDrive = drive;
    }
}
