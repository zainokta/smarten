using UnityEngine;
using UnityEngine.UI;

public class deathcamController : MonoBehaviour {
    public Text textbox;
    Color alpha;
    Color fadeOut;
    Color Now;
    float duration = 0.15f;

    private void Awake()
    {
        sceneManager.instance.PlayDisastah();
        alpha = textbox.GetComponent<Text>().color;
        Now = new Color(textbox.color.r, textbox.color.g, textbox.color.b, 0f);
        fadeOut = new Color(textbox.color.r, textbox.color.g, textbox.color.b, 1f);
    }

    void Update () {
        textbox.color = Color.Lerp(Now, fadeOut, duration);
        duration += 0.2f * Time.deltaTime;

        if (duration >= 1.0f)
        {
            duration = 1.0f;
        }
    }
}
