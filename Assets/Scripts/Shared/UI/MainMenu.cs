using System;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// The first screen: one card for each of the three games, with a line about what you do in it and a Play button.
/// The UI is created here in code.
/// </summary>
public class MainMenu : MonoBehaviour
{
    [Serializable]
    public class GameCard
    {
        public string title;
        public string scene;

        [TextArea]
        public string description;

        [TextArea]
        public string controls;
    }

    private const float CardWidth = 540f;
    private const float CardHeight = 560f;
    private const float CardGap = 50f;

    private static readonly Vector2 Center = new Vector2(0.5f, 0.5f);

    [SerializeField] private GameCard[] games;

    private void Start()
    {
        UiFactory.EnsureEventSystem();
        Transform canvas = UiFactory.CreateCanvas("Menu Canvas", 0).transform;

        Image background = UiFactory.CreateImage(canvas, "Background", null, new Color(0.05f, 0.05f, 0.06f));
        UiFactory.Stretch(background.rectTransform);

        Text title = UiFactory.CreateTitle(canvas, "Title", Center, new Vector2(1600f, 120f), 84, UiTheme.TextColor);
        title.rectTransform.pivot = Center;
        title.rectTransform.anchoredPosition = new Vector2(0f, 420f);
        title.text = "Three games, three core loops";

        Text subtitle = UiFactory.CreateText(canvas, "Subtitle", Center, new Vector2(1600f, 50f), 30, TextAnchor.MiddleCenter);
        subtitle.rectTransform.pivot = Center;
        subtitle.rectTransform.anchoredPosition = new Vector2(0f, 340f);
        subtitle.color = UiTheme.Muted;
        subtitle.text = "Pick a game. Esc or the Menu button brings you back here.";

        for (int i = 0; i < games.Length; i++)
        {
            // Spreads the cards around the middle of the screen.
            float x = (i - (games.Length - 1) / 2f) * (CardWidth + CardGap);
            CreateCard(canvas, games[i], x);
        }
    }

    private void CreateCard(Transform canvas, GameCard game, float x)
    {
        Image card = UiFactory.CreatePanel(canvas, game.title, "Panel");
        UiFactory.Place(card.rectTransform, Center, new Vector2(x, -40f), new Vector2(CardWidth, CardHeight));
        card.rectTransform.pivot = Center;

        Text name = UiFactory.CreateTitle(card.transform, "Name", Center, new Vector2(CardWidth - 40f, 80f), 52, UiTheme.Hope);
        name.rectTransform.pivot = Center;
        name.rectTransform.anchoredPosition = new Vector2(0f, 210f);
        name.text = game.title;

        Text description = UiFactory.CreateText(card.transform, "Description", Center, new Vector2(CardWidth - 80f, 190f), 26, TextAnchor.UpperLeft);
        description.rectTransform.pivot = Center;
        description.rectTransform.anchoredPosition = new Vector2(0f, 60f);
        description.text = game.description;

        Text controls = UiFactory.CreateText(card.transform, "Controls", Center, new Vector2(CardWidth - 80f, 120f), 24, TextAnchor.UpperLeft);
        controls.rectTransform.pivot = Center;
        controls.rectTransform.anchoredPosition = new Vector2(0f, -100f);
        controls.color = UiTheme.Muted;
        controls.text = game.controls;

        Button play = UiFactory.CreateButton(card.transform, "Play", Center, new Vector2(300f, 80f), 40, Color.white);
        ((RectTransform)play.transform).anchoredPosition = new Vector2(0f, -210f);
        string scene = game.scene; // A copy for the click handler below.
        play.onClick.AddListener(() => ScreenFader.FadeAndLoad(scene));
    }
}
