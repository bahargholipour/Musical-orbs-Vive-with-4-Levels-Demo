using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPointerwithoutteleport : MonoBehaviour {

    public Transform cameraRigTransform;
   // public Transform FlyingTransform;
    public Transform headTransform; // The camera rig's head
    public Vector3 teleportReticleOffset; // Offset from the floor for the reticle to avoid z-fighting
    public LayerMask teleportMask; // Mask to filter out areas where teleports are allowed

    private SteamVR_TrackedObject trackedObj;

    public GameObject laserPrefab; // The laser prefab
    private GameObject laser; // A reference to the spawned laser
    private Transform laserTransform; // The transform component of the laser for ease of use

    public GameObject teleportReticlePrefab; // Stores a reference to the teleport reticle prefab.
    private GameObject reticle; // A reference to an instance of the reticle
    private Transform teleportReticleTransform; // Stores a reference to the teleport reticle transform for ease of use
    private enum State {START, TELEPORT, FLYING, LANDED};
   // public GameObject flyingPrefab;
   // private GameObject flying;

    private Vector3 hitPoint; // Point where the raycast hits
    

    public GameObject landingPoint;
    

    //public Transform endMarker;
    public float speed = 1.0F;
    private float startTime;
    private float journeyLength;

    private State state = State.START;

    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    //new
    void Start()
    {
        laser = Instantiate(laserPrefab);
        laserTransform = laser.transform;
        reticle = Instantiate(teleportReticlePrefab);
        teleportReticleTransform = reticle.transform;
      //  flying = Instantiate(flyingPrefab);
      //  FlyingTransform = flying.transform;
        
    }

    void Update()
    {
        if (state != State.LANDED)
        {
            // Is the touchpad held down?
            if (Controller.GetPress(SteamVR_Controller.ButtonMask.Touchpad) & state == State.START)
            {
                RaycastHit hit;

                // Send out a raycast from the controller
                if (Physics.Raycast(trackedObj.transform.position, transform.forward, out hit, 1000, teleportMask))
                {
                    hitPoint = landingPoint.transform.position;
                    //  endMarker.position = hit.point;
                    ShowLaser(hit);

                    //Show teleport reticle
                    reticle.SetActive(true);
                    teleportReticleTransform.position = hit.point + teleportReticleOffset;
                }
            }
            else // Touchpad not held down, hide laser & teleport reticle
            {
                laser.SetActive(false);
                reticle.SetActive(false);
            }

            // Touchpad released this frame & valid teleport position found
            if (Controller.GetPressUp(SteamVR_Controller.ButtonMask.Touchpad))
            {
                startTime = Time.time;
                journeyLength = Vector3.Distance(this.transform.position, hitPoint);
                state = State.FLYING;
            }

            if (state == State.FLYING)
            {
                //float distCovered = (Time.time - startTime) * speed;
                float fracJourney = speed / journeyLength;
                cameraRigTransform.position = Vector3.Lerp(this.transform.position, hitPoint, fracJourney);

                Debug.Log(cameraRigTransform.position);
                Debug.Log(fracJourney);
                if (fracJourney > 0.1)
                {
                    state = State.LANDED;
                }
            }
        }
    }


    private void ShowLaser(RaycastHit hit)
    {
        laser.SetActive(true); //Show the laser
        laserTransform.position = Vector3.Lerp(trackedObj.transform.position, hitPoint, .5f); // Move laser to the middle between the controller and the position the raycast hit
        laserTransform.LookAt(hitPoint); // Rotate laser facing the hit point
        laserTransform.localScale = new Vector3(laserTransform.localScale.x, laserTransform.localScale.y,
            hit.distance); // Scale laser so it fits exactly between the controller & the hit point
    }
}

