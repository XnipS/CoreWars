using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ui_notification : MonoBehaviour
{
    public Image img;
    public Text tex;
    public Image icon;
    public enum NotifyIconType
    {
        none = 0, plus = 1
    }
    public NotifyIconType type;
    public enum NotifyColourType
    {
        green = 0
    }
    public Color[] colors;
    public Sprite[] icons;

    void Start()
    {
        StartCoroutine(Think());
    }

    public void Setup(string msg, ui_notification.NotifyColourType colourType, ui_notification.NotifyIconType iconType)
    {
        tex.text = msg;
        img.color = colors[(int)colourType];
        icon.sprite = icons[(int)iconType];
    }

    IEnumerator Think()
    {
        Color x = img.color;
        Color y = tex.color;
        Color z = icon.color;
        float fadein = 0f;
        while (fadein < 1f)
        {
            fadein += Time.deltaTime * 2f;
            img.color = Color.Lerp(Color.clear, x, fadein);
            tex.color = Color.Lerp(Color.clear, y, fadein);
            icon.color = Color.Lerp(Color.clear, z, fadein);
            yield return null;
        }
        //Fade
        float max = 3f;
        float timer = max;
        while (timer > 0)
        {
            timer -= Time.deltaTime;
            img.color = Color.Lerp(img.color, Color.clear, (1f / max) * max - timer);
            tex.color = Color.Lerp(tex.color, Color.clear, (1f / max) * max - timer);
            icon.color = Color.Lerp(icon.color, Color.clear, (1f / max) * max - timer);
            yield return null;
        }
        Destroy(gameObject);
    }
}
