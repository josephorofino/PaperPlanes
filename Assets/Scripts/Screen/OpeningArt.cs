using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class OpeningArt : MonoBehaviour
{
    public List<Sprite> art = new List<Sprite>();
    public List<string> cutsceneText = new List<string>();
    public TextMeshProUGUI textObject; 
    public Animator transition;
    public float transitionTime = 1f;

    private int curr = 0;
    private bool transitioning = false;

    void Start()
    {
        GetComponent<Image>().sprite = art[curr];
        textObject.text = cutsceneText[curr];
    }

    void Update()
    {
        if (Input.anyKey && !transitioning) {
            transitioning = true;
            StartCoroutine(SlideShow());
        }
    }

    IEnumerator SlideShow()
    {
        if (curr != 2) {
            transition.SetTrigger("Start");
            yield return new WaitForSeconds(transitionTime);
            GetComponent<Image>().sprite = art[++curr];
            textObject.text = cutsceneText[curr];
            transition.SetTrigger("End");
            yield return new WaitForSeconds(transitionTime);
            transitioning = false;
        } else {
            transition.SetTrigger("Start");
            yield return new WaitForSeconds(transitionTime);
            SceneManager.LoadScene("Tutorial");
        }
    }
}
