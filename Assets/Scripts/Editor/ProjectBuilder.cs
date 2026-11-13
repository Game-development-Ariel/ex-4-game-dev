using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

/// <summary>
/// Rebuilds the scenes of the project from the setup tools, in the right order.
/// The methods are public so they can also run from the command line (Unity -batchmode -executeMethod).
/// </summary>
public static class ProjectBuilder
{
    [MenuItem("Tools/Tunnel/Rebuild Whole Level")]
    public static void BuildTunnel()
    {
        EditorSceneManager.OpenScene(TunnelLevelSetup.LevelScenePath);
        TutorialMapBuilder.Build();
        TunnelLevelSetup.Setup();
        GameFeelSetup.Setup();
        AssetDatabase.SaveAssets();
    }

    [MenuItem("Tools/Rebuild All Scenes")]
    public static void BuildAllScenes()
    {
        BuildTunnel();
        LandfillSceneBuilder.Build();
        WineBarSceneBuilder.Build();
        MainMenuBuilder.Build();
    }

    /// <summary>Builds the game for the browser into Build/WebGL, ready to zip and upload to itch.io.</summary>
    [MenuItem("Tools/Build WebGL")]
    public static void BuildWebGL()
    {
        // Gzip with the fallback loader works on itch.io, which doesn't send the compression headers.
        PlayerSettings.WebGL.compressionFormat = WebGLCompressionFormat.Gzip;
        PlayerSettings.WebGL.decompressionFallback = true;

        var options = new BuildPlayerOptions
        {
            scenes = System.Array.ConvertAll(EditorBuildSettings.scenes, scene => scene.path),
            locationPathName = "Build/WebGL",
            target = BuildTarget.WebGL,
        };
        Debug.Log("WebGL build: " + BuildPipeline.BuildPlayer(options).summary.result);
    }
}
