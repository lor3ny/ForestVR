using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BucketFill : MonoBehaviour
{
    public GameObject waterChild;  // Reference to the water GameObject
    public XRGrabInteractable grabInteractable;  // Reference to the XRGrabInteractable component
    private GameObject fireNearPlayer;  // Reference to the fire near the player

    private bool isNearWater = false;  // Check if bucket is near the water
    private bool isActivated = false; // Track if the button is pressed
    private bool isWaterFilled = false; // Track if the water has been filled
    private bool isNearFire = false;  // Check if the bucket is near a fire
    private bool isWaterFillingInProgress = false;  // Prevent rapid water filling

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        // Ensure waterChild starts inactive
        if (waterChild != null)
        {
            waterChild.SetActive(false);
            Debug.Log("WaterChild is initially inactive.");
        }
    }

    void Update()
    {
        // Prevent multiple fillings: only refill the bucket once when button is pressed near water
        if (isNearWater && isActivated && !isWaterFilled && !isWaterFillingInProgress)
        {
            // Start filling the bucket with water when button is pressed and near the water
            isWaterFillingInProgress = true;  // Prevent rapid refill
            if (waterChild != null)
            {
                waterChild.SetActive(true);  // Show the water when near the river and button pressed
                isWaterFilled = true;  // Mark the bucket as filled with water
                Debug.Log("Bucket filled with water.");
                PlaySound();
            }
        }

        // If the button is pressed and the player is near a fire and has water in the bucket
        if (isNearFire && isWaterFilled && isActivated && fireNearPlayer != null && fireNearPlayer.activeInHierarchy)
        {
            ExtinguishFire(fireNearPlayer);  // Extinguish the fire near the player
            RemoveWater();     // Remove water from the bucket after it's used
        }
    }

    // This method will be called by the XR Interaction Toolkit's event system
    public void OnActivatePressed()
    {
        isActivated = true;
        Debug.Log("Activate button pressed.");
    }

    // This method will be called when the player releases the activate button
    public void OnActivateReleased()
    {
        isActivated = false;
        Debug.Log("Activate button released.");
        isWaterFillingInProgress = false;  // Reset water filling progress when the button is released
    }

    // Method to extinguish the specific fire near the player
    private void ExtinguishFire(GameObject fire)
    {
            // Disable or destroy fire to simulate extinguishing it
            fire.SetActive(false);  // You can also use Destroy(fire) if you want to completely remove it
            Debug.Log("Fire extinguished.");
            PlaySound();
    }

    // Method to remove the water from the bucket
    private void RemoveWater()
    {
        if (waterChild != null)
        {
            waterChild.SetActive(false);  // Hide the water when it's used
            isWaterFilled = false;  // Mark the bucket as empty
            Debug.Log("Water removed from bucket.");
        }
    }

    // Detect when the bucket enters the river zone (trigger area)
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Lake"))
        {
            isNearWater = true;  // The bucket is near water
            Debug.Log("Bucket is near water.");
        }
        if (other.CompareTag("Fire"))
        {
            isNearFire = true;  // The bucket is near a fire
            fireNearPlayer = other.gameObject;  // Set the fire that is near the player
            Debug.Log("Bucket is near a fire.");
        }
    }

    // Detect when the bucket leaves the river zone or fire zone (trigger area)
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Lake"))
        {
            isNearWater = false;  // The bucket is no longer near water
            Debug.Log("Bucket left the water zone.");

            if (!isWaterFilled) // Reset state only if it's not already filled
            {
                // Allow for the bucket to be refilled only when near water and not filled
                isWaterFilled = false;  // Ensures the water can be filled again
                Debug.Log("Bucket can be refilled now.");
            }
        }
        if (other.CompareTag("Fire"))
        {
            isNearFire = false;  // The bucket is no longer near a fire
            fireNearPlayer = null;  // Reset the reference to the fire
            Debug.Log("Bucket left the fire zone.");
        }
    }

    public void PlaySound()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }

}
