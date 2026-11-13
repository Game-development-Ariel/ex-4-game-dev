/// <summary>
/// The data assets of the tunnel game (events and settings), in one place for the setup tools.
/// Each one is created the first time it is asked for.
/// </summary>
public static class TunnelAssets
{
    private const string Folder = "Assets/Data/Tunnel/";

    public static GameEvent PlayerCaught => SetupTools.Asset<GameEvent>(Folder + "Events/PlayerCaught.asset");
    public static GameEvent BottlePicked => SetupTools.Asset<GameEvent>(Folder + "Events/BottlePicked.asset");
    public static GameEvent BottleDelivered => SetupTools.Asset<GameEvent>(Folder + "Events/BottleDelivered.asset");
    public static GameEvent LevelWon => SetupTools.Asset<GameEvent>(Folder + "Events/LevelWon.asset");
    public static GameEvent LevelLost => SetupTools.Asset<GameEvent>(Folder + "Events/LevelLost.asset");
    public static TextEvent HintRequested => SetupTools.Asset<TextEvent>(Folder + "Events/HintRequested.asset");
    public static TextEvent MemoryFound => SetupTools.Asset<TextEvent>(Folder + "Events/MemoryFound.asset");

    public static TunnelLevelSettings LevelSettings => SetupTools.Asset<TunnelLevelSettings>(Folder + "TutorialLevelSettings.asset");
    public static VisionStats CameraVision => SetupTools.Asset<VisionStats>(Folder + "SecurityCameraVision.asset");
}
