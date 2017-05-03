using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public float RollSpeed = 30.0f;
    public float PitchSpeed = 15.0f;
    public float YawSpeed = 0.1f;

    public float Speed = 5.0f;

    public GameObject[] Muzzles;
    public GameObject ProjectilePrefab;
    public Rigidbody PlayerRB;

    public GameObject MinimapCamera;

    private int currentMuzzle;

    public float FireRate = 0.2f;
    private float cooldownRemaining;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (cooldownRemaining <= 0)
        {
            if (Input.GetButton("Fire1"))
            {
                // reset the cooldown
                cooldownRemaining = FireRate;

                SoundManager.Instance.OnFireEvent(transform.position);

                GameManager.Instance.AdjustScore(1);

                // Get the location of the current muzzle
                Vector3 muzzleLocation = Muzzles[currentMuzzle].transform.position;

                // Spawn the projectile and position at the muzzle
                GameObject newProjectile = GameObject.Instantiate(ProjectilePrefab);
                newProjectile.transform.position = muzzleLocation;

                // Launch the projectile
                Rigidbody projectileRB = newProjectile.GetComponent<Rigidbody>();
                projectileRB.AddForce(transform.forward * 1000.0f); // MAGIC NUMBERS ARE BAD

                // cycle to the next muzzle
                currentMuzzle = (currentMuzzle + 1) % Muzzles.Length;
            }
        } // weapons on cooldown?
        else
        {
            cooldownRemaining -= Time.deltaTime;
        }

	    // Retrieve the input from the player
        float hInput = -Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical") * (GameManager.Instance.InvertY ? -1.0f : 1.0f);

        // Retrieve the roll angle
        float rollAngle = transform.eulerAngles.z;
        if (rollAngle > 180.0f) // if roll angle is over 180 then subtract 360 degrees
            rollAngle -= 360.0f;

        // Calculate the delta rotation
        Vector3 deltaRotation = new Vector3(vInput * PitchSpeed * Time.deltaTime,
                                            -rollAngle * YawSpeed * Time.deltaTime,
                                            hInput * RollSpeed * Time.deltaTime);

        // Apply the rotation
        transform.Rotate(deltaRotation);
	}

    void FixedUpdate()
    {
        // Move forwards
        PlayerRB.MovePosition(transform.position + transform.forward * Speed * Time.fixedDeltaTime);

        // move the minimap camera with the player
        MinimapCamera.transform.position = new Vector3(transform.position.x, MinimapCamera.transform.position.y, transform.position.z);
    }

    void OnTriggerEnter(Collider colliderInfo)
    {
        if (colliderInfo.gameObject.CompareTag(Tags.SpeedUp))
        {
            Speed *= 2;
        }
        else if (colliderInfo.gameObject.CompareTag(Tags.SpeedDown))
        {
            Speed *= 0.5f;
        }

        BaseBlock blockScript = colliderInfo.gameObject.GetComponent<BaseBlock>();
        if (blockScript != null)
        {
            blockScript.OnHit(gameObject, this);
        }
    }
}
