using UnityEngine;

/// <summary>
/// What hope does to the hero's body, saved as an asset. Each pair is the value with no hope and with full hope,
/// and the real value slides between them. From the design: without hope you can't escape.
/// </summary>
[CreateAssetMenu(menuName = "Tunnel/Hope Effects")]
public class HopeEffects : ScriptableObject
{
    [Tooltip("Walking speed, as a multiplier of the normal speed")]
    public Vector2 speedFactor = new Vector2(0.7f, 1.5f);

    [Tooltip("How far the hero's eyes see in the dark, in tiles")]
    public Vector2 sightRadius = new Vector2(2.2f, 5.2f);

    [Tooltip("From how far the hero hears a guard's steps, in tiles")]
    public Vector2 hearingRange = new Vector2(2f, 12f);

    [Tooltip("At this hope and above the hero is steady")]
    public int steadyHope = 50;

    [Tooltip("At this hope and above the hero is full of faith")]
    public int faithHope = 75;
}
