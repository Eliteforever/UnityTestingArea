using UnityEngine;
using System.Collections;

public class cursorHandler : MonoBehaviour 
{
	public Texture2D cursorImage;
	
	private int cursorWidth = 16;
	private int cursorHeight = 16;
	private bool showCursor = false;
	private string defaultResource = "MousePointer";

	private float xDir;
	private float yDir;

	public Vector3 mousePos;
	public float cursorSpeed;

	private int a = 0;
	
	void Start()
	{
		if(!cursorImage) {
			cursorImage = (Texture2D) Resources.Load(defaultResource);
			Debug.Log(cursorImage);
		}

		Screen.showCursor = false;
		//cursorImage = (Texture2D) Instantiate(cursorImage);
	}

	void Update()
	{

	}
	
	void OnMouseEnter()
	{
		Debug.Log("Entered");
		Screen.showCursor = false;
		//showCursor = true;
	}

	void OnGUI() {
		bool xDirPositive = false;
		bool yDirPositive = false;
		
		xDir = cursorSpeed * Input.GetAxis("Mouse X");
		yDir = cursorSpeed * Input.GetAxis("Mouse Y");
		
		if (xDir > 0)
			xDirPositive = true;
		if (yDir > 0)
			yDirPositive = true;
		
		if (xDirPositive) {
			
			if (mousePos.x > Screen.width)
			{
				mousePos.x = Screen.width;
				xDir = 0;
			}
		} else {
			
			if (mousePos.x < 0)
			{
				mousePos.x = 0;
				xDir = 0;
			}
		}
		
		if (yDirPositive) {
			
			if (mousePos.y > Screen.height)
			{
				mousePos.y = Screen.height;
				yDir = 0;
			}
		} else {
			
			if (mousePos.y < 0)
			{
				mousePos.y = 0;
				yDir = 0;
			}
		}
		
		mousePos.x += xDir;
		mousePos.y += yDir;

		GUI.DrawTexture(new Rect(mousePos.x, Screen.height - mousePos.y, cursorWidth, cursorHeight), cursorImage);
	}

	void OnMouseExit()
	{
		Debug.Log("Left");
		showCursor = false;

	}
}