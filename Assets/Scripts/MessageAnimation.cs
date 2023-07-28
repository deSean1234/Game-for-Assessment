using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageAnimation : MonoBehaviour
{
    public static void Play(GameObject obj, float start, int limit, float increment, bool active, bool isText, bool needDelay, float delay)
    {
        Instance.StartCoroutine(Instance.Animations(obj, start, limit, increment, active, isText, needDelay, delay));
    }

    private static MessageAnimation instance;

    private static MessageAnimation Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<MessageAnimation>();
                if (instance == null)
                {
                    Debug.LogError("MessageAnimation instance not found in the scene.");
                }
            }
            return instance;
        }
    }

    private IEnumerator Animations(GameObject obj, float start, int limit, float increment, bool active, bool isText, bool needDelay, float delay)
    {
        // if the thing is a text object
        if (isText) {
            obj.SetActive(active);
            var objText = obj.transform.GetChild(0).GetComponent<Text>();

            for (float transparency = start; transparency < limit; transparency += increment)
            {
                objText.GetComponent<Text>().color = new Color(1f, 1f, 1f, transparency);
                yield return new WaitForSeconds(0.02f);
                if (transparency < 0) { break; }
            }
        } else if (!isText) {
            if (needDelay) { yield return new WaitForSeconds(delay); }
            for (float transparency = start; transparency < limit; transparency += increment)
            {
                var img = obj.transform.GetChild(0).GetComponent<Image>();
                img.color = new Color(0, 0, 0, transparency);
                yield return new WaitForSeconds(0.02f);
                if (transparency < 0) { break; }
            }
        }
    }
}
