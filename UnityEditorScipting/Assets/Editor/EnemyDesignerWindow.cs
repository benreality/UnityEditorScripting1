using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Add UnityEditor
using UnityEditor;

public class EnemyDesignerWindow : EditorWindow
{
  //Where the Window is accessible to
  [MenuItem("Window/Enemy Designer")]
  static void OpenWindow()
    {
        //Get Window Call
        EnemyDesignerWindow window = (EnemyDesignerWindow)GetWindow(typeof(EnemyDesignerWindow));
        //Window Size
        window.minSize = new Vector2(600, 300);
        //Show Window
        window.Show();
        
    }
}
