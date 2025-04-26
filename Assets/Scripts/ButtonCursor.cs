using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonCursor : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Texture2D cursor;
    public void OnPointerEnter(PointerEventData eventData)
    {
        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
