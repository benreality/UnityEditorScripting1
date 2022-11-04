using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Add UnityEditor
using UnityEditor;
using Types;

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

    //adding static variables for holding the reference to our data
    static MageData mageData;
    static WarriorData warriorData;
    static RogueData rogueData;

    //create public properties counterparts for our data
    public static MageData MageInfo { get { return mageData; } }
    public static WarriorData WarriorInfo { get { return warriorData; } }
    public static RogueData RogueInfo { get { return rogueData; } }





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
        InitData();
    }
    /// <summary>
    /// Initialize our scriptable object properly by calling ScriptableObject.CreateInstance. Making sure we are casting that into the type of data that we have.
    /// </summary>
    public static void InitData()
    {
        mageData = (MageData)ScriptableObject.CreateInstance(typeof(MageData));
        warriorData = (WarriorData)ScriptableObject.CreateInstance(typeof(WarriorData));
        rogueData = (RogueData)ScriptableObject.CreateInstance(typeof(RogueData));



    }
    /// <summary>
    /// Initialize Texture2D values
    /// </summary>
    void InitTextures()
    {
        headerSectionTexture = Resources.Load<Texture2D>("icons/249logo");
        //Define new Texture2D by 1 pixel wide and 1 pixel high
        /*headerSectionTexture = new Texture2D(1, 1);
        //Set the pixel at 0,0 position and colour according to headerSectionColor on top.
        headerSectionTexture.SetPixel(0, 0, headerSectionColor);
        //Apply to headerSectionTexture
        headerSectionTexture.Apply();*/

        mageSectionTexture = Resources.Load<Texture2D> ("icons/rosevale");
        /*mageSectionTexture = new Texture2D(1, 1);
        mageSectionTexture.SetPixel(0, 0, mageSectionColor);
        mageSectionTexture.Apply();*/

        warriorSectionTexture = Resources.Load<Texture2D>("icons/rosybrown");
        /*warriorSectionTexture = new Texture2D(1, 1);
        warriorSectionTexture.SetPixel(0, 0, warriorSectionColor);
        warriorSectionTexture.Apply();*/

        rogueSectionTexture = Resources.Load<Texture2D>("icons/silver");
        /*rogueSectionTexture = new Texture2D(1, 1);
        rogueSectionTexture.SetPixel(0, 0, rogueSectionColor);
        rogueSectionTexture.Apply();*/
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
        headerSection.height = 100;

        
        mageSection.x = 0;
        mageSection.y = 100;
        mageSection.width = Screen.width/ 3f;
        mageSection.height = Screen.width - 50;

        warriorSection.x = Screen.width/3f;
        warriorSection.y = 100;
        warriorSection.width = Screen.width / 3f;
        warriorSection.height = Screen.width - 50;

        rogueSection.x = (Screen.width/3f) *2;
        rogueSection.y = 100;
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
        //opening curly braces for headerSection to begin with
        GUILayout.BeginArea(headerSection);

        //ending curly braces to end with 
        GUILayout.EndArea();
    }
    /// <summary>
    /// Draw contents of Mage region
    /// </summary>
    void DrawMageSettings()
    {
        //opening curly braces for mageSection to begin with
        GUILayout.BeginArea(mageSection);
        //Label for Mage
        GUILayout.Label("Mage");

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Damage Type:");
        //right side is to pass variable that we want to modify the value which is MageDmyType. Left side is to return whatever value that is modified into an actual variable
        mageData.dmgType = (MageDmgType)EditorGUILayout.EnumPopup(mageData.dmgType);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Weapon Type:");
        mageData.wpnType = (MageWpnType)EditorGUILayout.EnumPopup(mageData.wpnType);
        EditorGUILayout.EndHorizontal();

        // GUILayout.Button is going to return true or false if we pressed the button
        // First Parameters will be: String value of "Create!"
        // Second Parameters will be the button height of 40
        if (GUILayout.Button("Create!", GUILayout.Height(40)))
        {
            //Open window for MAGE
            GeneralSettings.OpenWindow(GeneralSettings.SettingsType.MAGE);
        }


        //ending curly braces to end with 
        GUILayout.EndArea();
    }
    /// <summary>
    /// Draw contents of Warrior region
    /// </summary>
    void DrawWarriorSettings()
    {
        //opening curly braces for warriorSection to begin with
        GUILayout.BeginArea(warriorSection);
        //Label for Warrior
        GUILayout.Label("Warrior");

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Class Type:");
        //right side is to pass variable that we want to modify the value which is MageDmyType. Left side is to return whatever value that is modified into an actual variable
        warriorData.classType = (WarriorClassType)EditorGUILayout.EnumPopup(warriorData.classType);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Weapon Type:");
        warriorData.wpnType = (WarriorWpnType)EditorGUILayout.EnumPopup(warriorData.wpnType);
        EditorGUILayout.EndHorizontal();

        if (GUILayout.Button("Create!", GUILayout.Height(40)))
        {
            //Open window for MAGE
            GeneralSettings.OpenWindow(GeneralSettings.SettingsType.WARRIOR);
        }

        //ending curly braces to end with 
        GUILayout.EndArea();
    }
    /// <summary>
    /// Draw contents of Rogue region
    /// </summary>
    void DrawRogueSettings()
    {
        //opening curly braces for rogueSection to begin with
        GUILayout.BeginArea(rogueSection);
        //Label for Rogue
        GUILayout.Label("Rogue");

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Weapon Type:");
        //right side is to pass variable that we want to modify the value which is MageDmyType. Left side is to return whatever value that is modified into an actual variable
        rogueData.wpnType = (RogueWpnType)EditorGUILayout.EnumPopup(rogueData.wpnType);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Strategy Type:");
        rogueData.strategyType = (RogueStrategyType)EditorGUILayout.EnumPopup(rogueData.strategyType);
        EditorGUILayout.EndHorizontal();

        if (GUILayout.Button("Create!", GUILayout.Height(40)))
        {
            //Open window for MAGE
            GeneralSettings.OpenWindow(GeneralSettings.SettingsType.ROGUE);
        }

        //ending curly braces to end with 
        GUILayout.EndArea();
    }
}


public class GeneralSettings : EditorWindow
{
    // enumeration for SettingsType, be passed as a parameters whenever we call OpenWindow
    // specific if we choose to create a mage, warrior or rogue
    public enum SettingsType
    {
        MAGE,
        WARRIOR,
        ROGUE
    }

    static SettingsType dataSetting;
    static GeneralSettings window;

    // Open window function
    public static void OpenWindow(SettingsType setting)
    {
        dataSetting = setting;
        window = (GeneralSettings)GetWindow(typeof(GeneralSettings));
        window.minSize = new Vector2(250, 200);
        window.Show();
    }


}