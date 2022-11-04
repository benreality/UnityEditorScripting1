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
    Color mageSectionColor = new Color(0f / 255f, 0f / 255f, 225f / 255f, 1f);
    Color warriorSectionColor = new Color(127f / 255f, 0f / 255f, 225f / 255f, 1f);
    Color rogueSectionColor = new Color(255f / 255f, 255f / 255f, 0f / 255f, 1f);

    Rect headerSection;
    Rect mageSection;
    Rect warriorSection;
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
              

        mageSectionTexture = new Texture2D(1, 1);
        mageSectionTexture.SetPixel(0, 0, mageSectionColor);
        mageSectionTexture.Apply();

        warriorSectionTexture = new Texture2D(1, 1);
        warriorSectionTexture.SetPixel(0, 0, warriorSectionColor);
        warriorSectionTexture.Apply();

        rogueSectionTexture = new Texture2D(1, 1);
        rogueSectionTexture.SetPixel(0, 0, rogueSectionColor);
        rogueSectionTexture.Apply();
    }
    /// <summary>
    /// Similar to any Update function,
    /// Not called once per frame, called 1 or more times per interaction
    /// </summary>
    void OnGUI()
    {
        DrawLayouts();
        DrawHeader();
        DrawMageSettings();
        DrawWarriorSettings();
        DrawRogueSettings();
    }
    /// <summary>
    /// Defines Rect values and paints textures based on Rects which are defined on top
    /// </summary>
    void DrawLayouts()
    {
        // x and y position will be 0, it will be at the top left corner of the window at all time
        headerSection.x = 0;
        headerSection.y = 0;
        // width will be according to the screen width
        headerSection.width = Screen.width;
        // height will be 50 
        headerSection.height = 50;

    
        mageSection.x = 0;
        mageSection.y = 50;
        mageSection.width = Screen.width/ 3f;
        mageSection.height = Screen.width - 50;

        warriorSection.x = Screen.width/3f;
        warriorSection.y = 50;
        warriorSection.width = Screen.width / 3f;
        warriorSection.height = Screen.width - 50;

        rogueSection.x =Screen.width/3f *2;
        rogueSection.y = 50;
        rogueSection.width = Screen.width / 3f;
        rogueSection.height = Screen.width - 50;

        // pass the rect and texture
        GUI.DrawTexture(headerSection, headerSectionTexture);
        GUI.DrawTexture(mageSection, mageSectionTexture);
        GUI.DrawTexture(warriorSection, warriorSectionTexture);
        GUI.DrawTexture(rogueSection, rogueSectionTexture);
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
