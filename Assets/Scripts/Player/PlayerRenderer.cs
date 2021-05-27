using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRenderer : MonoBehaviour
{
    public enum PlayerRenderState
    {
        Static,
        Run,
        Attack1,
        Attack2,
        Attack3,
        Dash
    }
    [SerializeField]
    private List<string> animatorStringHeads;
    [SerializeField]
    private List<PlayerRenderState> renderStatesSetupSequence;

    private static readonly string[] directions = { "N", "NW", "W", "SW", "S", "SE", "E", "NE" };
    private Dictionary<PlayerRenderState, string> stateToStringHash;
    private Animator animator;
    private string lastRenderedDirectionString;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        SetupStateToStringHash();
        lastRenderedDirectionString = "S";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void SetupStateToStringHash()
    {
        stateToStringHash = new Dictionary<PlayerRenderState, string>();
        for (int i = 0; i < renderStatesSetupSequence.Count; i++)
        {
            stateToStringHash.Add(renderStatesSetupSequence[i], animatorStringHeads[i]);
        }
    }
    private void Render(PlayerRenderState renderState, string directionString)
    {
        string renderedString;
        if (directionString == "0")
        {
            renderedString = lastRenderedDirectionString;
        }
        else
        {
            renderedString = directionString;
        }
        animator.Play(stateToStringHash[renderState] + " " + renderedString);
        lastRenderedDirectionString = renderedString;
    }
    private int DirectionToIndex(Vector2 dir, int sliceCount)
    {
        //get the normalized direction
        Vector2 normDir = dir.normalized;
        //calculate how many degrees one slice is
        float step = 360f / sliceCount;
        //calculate how many degress half a slice is.
        //we need this to offset the pie, so that the North (UP) slice is aligned in the center
        float halfstep = step / 2;
        //get the angle from -180 to 180 of the direction vector relative to the Up vector.
        //this will return the angle between dir and North.
        float angle = Vector2.SignedAngle(Vector2.up, normDir);
        //add the halfslice offset
        angle += halfstep;
        //if angle is negative, then let's make it positive by adding 360 to wrap it around.
        if (angle < 0)
        {
            angle += 360;
        }
        //calculate the amount of steps required to reach this angle
        float stepCount = angle / step;
        return Mathf.FloorToInt(stepCount);
    }
    private string DirectionToString(Vector2 direction)
    {
        if(direction.magnitude < 0.001)
        {
            return "0";
        }
        return directions[DirectionToIndex(direction, 8)];
    }
    public void UpdateAnimation(PlayerRenderState renderState, Vector2 direction)
    {
        Render(renderState, DirectionToString(direction));
    }
}
