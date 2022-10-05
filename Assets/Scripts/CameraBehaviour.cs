using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public enum CameraState 
    {
        Gameplay,
        ScriptedCinematic,
        Death
    }

    [Header("References and Misc")]
    public GameObject player;
    public CameraState currentState = new CameraState();

    [Header("Gameplay State following Parameters")]
    public bool shouldAlwaysFollowPlayerInGameplay = false;

    public Vector2 screenEdgeForFollow;

    public float followDamping;

    public AnimationCurve dampingScreenEdgeDistance;

    private Camera cam;

    private Vector3 initialCameraOffset;

    [SerializeField] private float lookAheadDistance;


    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        initialCameraOffset = transform.position - player.transform.position;
    }


    // Update is called once per frame
    void LateUpdate()
    {
        switch (currentState)
        {
            case CameraState.Gameplay:
                UpdateOnGameplay();
                break;

            case CameraState.Death:
                UpdateOnDeath();
                break;

            case CameraState.ScriptedCinematic:
                UpdateOnScriptedCinematic();
                break;

            default:
                break;
        }
    }

    private void UpdateOnGameplay()
    {
        if (shouldAlwaysFollowPlayerInGameplay)
        {
            Vector2 lookAhead2D = player.GetComponent<PlayerMovementController>().GetLookStick() * lookAheadDistance;
            Vector3 lookAheadPosition = player.transform.position + new Vector3(lookAhead2D.x, 0, lookAhead2D.y);
            transform.position = Vector3.Lerp(transform.position, lookAheadPosition + initialCameraOffset, followDamping * Time.deltaTime);
            
            return;
        }


      
        Vector2 playerRelativeScreenPosition = cam.WorldToViewportPoint(player.transform.position);
        playerRelativeScreenPosition += player.GetComponent<PlayerMovementController>().GetLookStick() * lookAheadDistance;

        float adjustedDamping = followDamping;

        if(playerRelativeScreenPosition.x <= screenEdgeForFollow.x)
        {
            adjustedDamping *= dampingScreenEdgeDistance.Evaluate(1-(playerRelativeScreenPosition.x / screenEdgeForFollow.x));
            transform.Translate(transform.right * Time.deltaTime * adjustedDamping * -1);
        }
        if(playerRelativeScreenPosition.x > (1 - screenEdgeForFollow.x))
        {
            adjustedDamping *= dampingScreenEdgeDistance.Evaluate(1-((1-playerRelativeScreenPosition.x) / screenEdgeForFollow.x));
            transform.Translate(transform.right * Time.deltaTime * adjustedDamping);
        }
        if(playerRelativeScreenPosition.y <= screenEdgeForFollow.y)
        {
            adjustedDamping *= dampingScreenEdgeDistance.Evaluate(1-(playerRelativeScreenPosition.y / screenEdgeForFollow.y));
            transform.position -= Vector3.forward * Time.deltaTime * adjustedDamping;
        }
        if(playerRelativeScreenPosition.y > (1 - screenEdgeForFollow.y))
        {
            adjustedDamping *= dampingScreenEdgeDistance.Evaluate(1 - ((1-playerRelativeScreenPosition.y) / screenEdgeForFollow.y));
            transform.position += Vector3.forward * Time.deltaTime * adjustedDamping;
        }
    }

    private void UpdateOnScriptedCinematic()
    {

    }

    private void UpdateOnDeath()
    {

    }
}
