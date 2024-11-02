using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class loadScreenController : MonoBehaviour
{
    public Button myButton;

    // Start is called before the first frame update
    void Start()
    {
        myButton.onClick.AddListener(onButtonClick);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began)
            {
                Vector2 TouchPosition = touch.position;
                if (IsTouchOverButton(TouchPosition))
                {
                    myButton.onClick.Invoke();
                }

            }
        }
    }

    bool IsTouchOverButton(Vector2 touchPosition)
    {
        RectTransform rectTransform = myButton.GetComponent<RectTransform>();
        Vector2 LocalPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, touchPosition, null, out LocalPoint);
        return rectTransform.rect.Contains(LocalPoint);
    }

    public void onButtonClick()
    {
        SceneManager.LoadScene("GameScreen");
    }
}
