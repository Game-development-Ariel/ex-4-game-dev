using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Creates the simple end-of-round screen: a dark cover, a title, a message,
/// and the "Play again" and "Menu" buttons. Used by the landfill and the wine bar.
/// </summary>
public static class ResultOverlay
{
    // Above everything else in the scene, below the scene fader.
    private const int SortingOrder = 60;

    private static readonly Vector2 Center = new Vector2(0.5f, 0.5f);

    public static void Show(string title, string message, Color titleColor)
    {
        UiFactory.EnsureEventSystem();
        Transform canvas = UiFactory.CreateCanvas("Result Canvas", SortingOrder).transform;

        Image cover = UiFactory.CreateImage(canvas, "Cover", null, new Color(0.03f, 0.03f, 0.04f, 0.9f));
        UiFactory.Stretch(cover.rectTransform);
        cover.raycastTarget = true; // Blocks clicks on the game behind it.

        Text titleText = UiFactory.CreateTitle(canvas, "Title", Center, new Vector2(1500f, 150f), 100, titleColor);
        titleText.rectTransform.pivot = Center;
        titleText.rectTransform.anchoredPosition = new Vector2(0f, 220f);
        titleText.text = title;

        Text messageText = UiFactory.CreateText(canvas, "Message", Center, new Vector2(1300f, 300f), 36, TextAnchor.MiddleCenter);
        messageText.rectTransform.pivot = Center;
        messageText.text = message;

        string thisScene = SceneManager.GetActiveScene().name;
        AddButton(canvas, "Play again", -220f, thisScene);
        AddButton(canvas, "Menu", 220f, SceneNames.Menu);
    }

    private static void AddButton(Transform canvas, string label, float x, string scene)
    {
        Button button = UiFactory.CreateButton(canvas, label, Center, new Vector2(380f, 84f), 40, Color.white);
        ((RectTransform)button.transform).anchoredPosition = new Vector2(x, -260f);
        button.onClick.AddListener(() => ScreenFader.FadeAndLoad(scene));
    }
}
