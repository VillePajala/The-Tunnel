using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour {

	// this codes makes the mouse cursor active on outro scene
	void Start () {

        // Cursor is visible when scene loads
        Cursor.visible = true;
        Screen.lockCursor = false;

    } // Start
	
	
	void Update () {
		
	} // Update
}
