using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

/// <summary>
/// Lets the player leave a game: a small "Menu" button in a corner, and the Esc key.
/// </summary>
public class BackToMenu : MonoBehaviour
{
    private const int CanvasSortingOrder = 25;

    [Tooltip("The corner of the screen for the button. (1,1) is the top right, (1,0) the bottom right")]
    [SerializeField] private Vector2 corner = new Vector2(1f, 0f);

    [Tooltip("Where the button's center is, measured from that corner, in UI pixels")]
    [SerializeField] private Vector2 offset = new Vector2(-100f, 50f);

    private void Start()
    {
        UiFactory.EnsureEventSystem();
        Canvas canvas = UiFactory.CreateCanvas("Menu Button Canvas", CanvasSortingOrder);
        canvas.transform.SetParent(transform, false);

        Button button = UiFactory.CreateButton(canvas.transform, "Menu", corner, new Vector2(150f, 56f), 28, new Color(1f, 1f, 1f, 0.7f));
        ((RectTransform)button.transform).anchoredPosition = offset;
        button.onClick.AddListener(GoToMenu);
    }

    private void Update()
    {
        if (Keyboard.current != null && Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            GoToMenu();
        }
    }

    private void GoToMenu()
    {
        ScreenFader.FadeAndLoad(SceneNames.Menu);
    }
}
