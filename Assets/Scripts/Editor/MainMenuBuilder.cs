using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Tools > Build Main Menu: creates the menu scene with a card for each game,
/// and sets the list of scenes that go into the build.
/// </summary>
public static class MainMenuBuilder
{
    private const string ScenePath = "Assets/Scenes/MainMenu.unity";

    [MenuItem("Tools/Build Main Menu")]
    public static void Build()
    {
        Scene scene = SceneParts.NewScene();
        SceneParts.CreateCamera(new Color(0.05f, 0.05f, 0.06f), 5f);

        MainMenu menu = new GameObject("Main Menu").AddComponent<MainMenu>();
        SerializedObject fields = new SerializedObject(menu);
        SerializedProperty games = fields.FindProperty("games");
        games.arraySize = 3;
        SetCard(games.GetArrayElementAtIndex(0), "Light in the Tunnel", SceneNames.Tunnel,
            "You wake up in a cell. Sneak past the security camera, take the water bottle from the storage room and bring it back to the mattress.",
            "Move: WASD or the arrow keys.\nMap: M.");
        SetCard(games.GetArrayElementAtIndex(1), "Buried Bitcoin", SceneNames.Landfill,
            "Trucks dump trash on the belt. Buy machines that sort it for you, and find the red toolbox on the sorting table before the day ends.",
            "Mouse: pick a machine, click a slot.\nClick an item on the table, then choose.");
        SetCard(games.GetArrayElementAtIndex(2), "Vino Blend Bar", SceneNames.WineBar,
            "A guest describes a wine in words. Guess the grapes: pour a blend, taste it, fix it and serve it before the guest loses patience.",
            "Mouse: click a bottle to pour.\nTaste, then Serve a full glass.");
        fields.ApplyModifiedPropertiesWithoutUndo();

        SceneParts.Save(scene, ScenePath);
        SetBuildScenes();
    }

    private static void SetCard(SerializedProperty card, string title, string scene, string description, string controls)
    {
        card.FindPropertyRelative("title").stringValue = title;
        card.FindPropertyRelative("scene").stringValue = scene;
        card.FindPropertyRelative("description").stringValue = description;
        card.FindPropertyRelative("controls").stringValue = controls;
    }

    /// <summary>The scenes that go into the build, in order. The first one is where the game starts.</summary>
    private static void SetBuildScenes()
    {
        EditorBuildSettings.scenes = new[]
        {
            new EditorBuildSettingsScene(ScenePath, true),
            new EditorBuildSettingsScene("Assets/Scenes/Tutorial.unity", true),
            new EditorBuildSettingsScene("Assets/Scenes/Landfill.unity", true),
            new EditorBuildSettingsScene("Assets/Scenes/WineBar.unity", true),
        };
        AssetDatabase.SaveAssets();
    }
}
