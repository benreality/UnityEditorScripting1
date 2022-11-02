using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Add UnityEditor
using UnityEditor;

public class EnemyDesignerWindow : EditorWindow
{

    Texture2D headerSectionTexture;
    Texture2D mageSectionTexture;
    Texture2D warriorSectionTexture;
    Texture2D rogueSectionTexture;

    Color headerSectionColor = new Color(13f / 255f, 32f / 255f, 44f / 255f, 1f);

    Rect headerSection;
    Rect mageSection;
    Rect WarriorSection;
    Rect rogueSection; 


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
    /// <summary>
    /// Similar to Start() or Awake()
    /// </summary>
    void OnEnable()
    {
        InitTextures();
    }
    /// <summary>
    /// Initialize Texture2D values
    /// </summary>
    void InitTextures()
    {
        //Define new Texture2D by 1 pixel wide and 1 pixel high
        headerSectionTexture = new Texture2D(1, 1);
        //Set the pixel at 0,0 position and colour according to headerSectionColor on top.
        headerSectionTexture.SetPixel(0, 0, headerSectionColor);
        //Apply to headerSectionTexture
        headerSectionTexture.Apply();
    }
    /// <summary>
    /// Similar to any Update function,
    /// Not called once per frame, called 1 or more times per interaction
    /// </summary>
    void OnGUI()
    {
        
    }
    /// <summary>
    /// Defines Rect values and paints textures based on Rects which are defined on top
    /// </summary>
    void DrawLayouts()
    {

    }
    /// <summary>
    /// Draw contents of Header region
    /// </summary>
    void DrawHeader()
    {

    }
    /// <summary>
    /// Draw contents of Mage region
    /// </summary>
    void DrawMageSettings()
    {

    }
    /// <summary>
    /// Draw contents of Warrior region
    /// </summary>
    void DrawWarriorSettings()
    {

    }
    /// <summary>
    /// Draw contents of Rogue region
    /// </summary>
    void DrawRogueSettings()
    {

    }
}
