using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CardController : MonoBehaviour
{
    [SerializeField] private Transform cardTransform;
    [SerializeField] private Image cardImage;

    public IEnumerator FlipWith(Sprite back)
    {
        float elapsed = 0;
        float half = Const.Timing.Flip / 2;
        Vector3 scale;

        while (elapsed <= half)
        {
            float progress = (half - elapsed) / half;
            scale = cardTransform.localScale;
            scale.x = progress;
            cardTransform.localScale = scale;
            elapsed += Time.deltaTime;
            yield return null;
        }

        cardImage.sprite = back;
        while (elapsed <= Const.Timing.Flip)
        {
            float progress = (elapsed - half) / half;
            scale = cardTransform.localScale;
            scale.x = progress;
            cardTransform.localScale = scale;
            elapsed += Time.deltaTime;
            yield return null;
        }

        scale = cardTransform.localScale;
        scale.x = 1;
        cardTransform.localScale = scale;
    }

    public IEnumerator FlipOff()
    {
        Vector3 scale;
        for (float elapsed = 0; elapsed <= Const.Timing.Flip;)
        {
            float progress = (Const.Timing.Flip - elapsed) / Const.Timing.Flip;
            scale = cardTransform.localScale;
            scale.x = progress;
            cardTransform.localScale = scale;
            elapsed += Time.deltaTime;
            yield return null;
        }

        scale = cardTransform.localScale;
        scale.x = 0;
        cardTransform.localScale = scale;
    }

    public IEnumerator FlipOn()
    {
        Vector3 scale;
        for (float elapsed = 0; elapsed <= Const.Timing.Flip;)
        {
            float progress = elapsed / Const.Timing.Flip;
            scale = cardTransform.localScale;
            scale.x = progress;
            cardTransform.localScale = scale;
            elapsed += Time.deltaTime;
            yield return null;
        }

        scale = cardTransform.localScale;
        scale.x = 1;
        cardTransform.localScale = scale;
    }
}