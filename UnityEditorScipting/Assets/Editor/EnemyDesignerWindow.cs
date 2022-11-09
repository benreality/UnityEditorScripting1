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
    Texture2D mageTexture;
    Texture2D warriorTexture;
    Texture2D rogueTexture;

    Color headerSectionColor = new Color(13f / 255f, 32f / 255f, 44f / 255f, 1f);
    Color mageSectionColor = new Color(0f / 255f, 0f / 255f, 225f / 255f, 1f);
    Color warriorSectionColor = new Color(127f / 255f, 0f / 255f, 225f / 255f, 1f);
    Color rogueSectionColor = new Color(255f / 255f, 255f / 255f, 0f / 255f, 1f);
    

    Rect headerSection;
    Rect mageSection;
    Rect warriorSection;
    Rect rogueSection;
    Rect mageIconSection;
    Rect warriorIconSection;
    Rect rogueIconSection;
    // Add in for font 
    GUISkin skin;

    //adding static variables for holding the reference to our data
    static MageData mageData;
    static WarriorData warriorData;
    static RogueData rogueData;

    //create public properties counterparts for our data
    public static MageData MageInfo { get { return mageData; } }
    public static WarriorData WarriorInfo { get { return warriorData; } }
    public static RogueData RogueInfo { get { return rogueData; } }


    float iconSize = 80;


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
        skin = Resources.Load<GUISkin>("guiStyles/EnemyDesignerSkin");
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

        mageTexture = Resources.Load<Texture2D>("icons/mageicon");
        warriorTexture = Resources.Load<Texture2D>("icons/warrioricon");
        rogueTexture = Resources.Load<Texture2D>("icons/rogueicon");

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
        headerSection.width = position.width;
        // height will be 50 s
        headerSection.height = 150;

        
        mageSection.x = 0;
        mageSection.y = 150;
        mageSection.width = position.width/ 3f;
        mageSection.height = position.width - 50;

        mageIconSection.x = (mageSection.x + mageSection.width / 2f) - iconSize/2f;
        mageIconSection.y = mageSection.y + 8;
        mageIconSection.width = iconSize;
        mageIconSection.height = iconSize;

        warriorIconSection.x = (warriorSection.x + warriorSection.width / 2f) - iconSize / 2f;
        warriorIconSection.y = warriorSection.y + 8;
        warriorIconSection.width = iconSize;
        warriorIconSection.height = iconSize;

        rogueIconSection.x = (rogueSection.x + rogueSection.width / 2f) - iconSize / 2f;
        rogueIconSection.y = rogueSection.y + 8;
        rogueIconSection.width = iconSize;
        rogueIconSection.height = iconSize;

        warriorSection.x = position.width/3f;
        warriorSection.y = 150;
        warriorSection.width = position.width / 3f;
        warriorSection.height = position.width - 50;

        rogueSection.x = (position.width/3f) *2;
        rogueSection.y = 150;
        rogueSection.width = position.width / 3f;
        rogueSection.height = position.width - 50;

        // pass the rect and texture
        GUI.DrawTexture(headerSection, headerSectionTexture);
        GUI.DrawTexture(mageSection, mageSectionTexture);
        GUI.DrawTexture(warriorSection, warriorSectionTexture);
        GUI.DrawTexture(rogueSection, rogueSectionTexture);
        GUI.DrawTexture(mageIconSection, mageTexture);
        GUI.DrawTexture(warriorIconSection, warriorTexture);
        GUI.DrawTexture(rogueIconSection, rogueTexture);
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

        GUILayout.Space(iconSize + 8);
        //Label for Mage
        GUILayout.Label("Mage", skin.GetStyle("Header1"));

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

        GUILayout.Space(iconSize + 8);
        //Label for Warrior
        GUILayout.Label("Warrior", skin.GetStyle("Header1"));

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

        GUILayout.Space(iconSize + 8);
        //Label for Rogue
        GUILayout.Label("Rogue", skin.GetStyle("Header1"));

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

    void OnGUI()
    {
        switch (dataSetting)
        {
            case SettingsType.MAGE:
                DrawSettings((CharacterData)EnemyDesignerWindow.MageInfo);
                break;
            case SettingsType.WARRIOR:
                DrawSettings((CharacterData)EnemyDesignerWindow.WarriorInfo);
                break;
            case SettingsType.ROGUE:
                DrawSettings((CharacterData)EnemyDesignerWindow.RogueInfo);
                break;

        }
    }

    void DrawSettings(CharacterData charData)
    {
        // Creating FloatField for user input of Health and Energy
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Prefab");
        // "false" to only allow prefabs and not objects from the scene
        charData.prefab = (GameObject)EditorGUILayout.ObjectField(charData.prefab,typeof(GameObject), false);
        EditorGUILayout.EndHorizontal();

        // Creating FloatField for user input of Health and Energy
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Max Health");
        charData.maxHealth = EditorGUILayout.FloatField(charData.maxHealth);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Max Energy");
        charData.maxEnergy = EditorGUILayout.FloatField(charData.maxEnergy);
        EditorGUILayout.EndHorizontal();

        // Creating slider for Power and Crit Chance
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Power");
        charData.Power = EditorGUILayout.Slider(charData.Power, 0, 100);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("% Crit Chance");
        // max will be based on max Power
        charData.CritChance = EditorGUILayout.Slider(charData.CritChance, 0, charData.Power);
        EditorGUILayout.EndHorizontal();

        //TextField for input of names
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Name");
        charData.name = EditorGUILayout.TextField(charData.name);
        EditorGUILayout.EndHorizontal();


        //Help box if Prefab & Name are not inside
        if (charData.prefab == null)
        {
            EditorGUILayout.HelpBox("This enemy needs a [Prefab] before it can be created", MessageType.Warning);
        }
        else if (charData.name == null || charData.name.Length < 1)
        {
            EditorGUILayout.HelpBox("This enemy needs a [Name] before it can be created", MessageType.Warning);
        }
        else if (GUILayout.Button("Finish and Save", GUILayout.Height(30)))
        {
            // saving character data
            SaveCharacterData();
            window.Close();
        }

    }


    void SaveCharacterData()
    {
        string prefabPath; //path to the base prefab
        string newPrefabPath = "Assets/prefabs/characters/";
        string dataPath = "Assets/resources/characterData/data/";

        switch(dataSetting)
        {
                case SettingsType.MAGE:
                //create the .asset file
                dataPath += "mage/" + EnemyDesignerWindow.MageInfo.name + ".asset";
                AssetDatabase.CreateAsset(EnemyDesignerWindow.MageInfo, dataPath);

                newPrefabPath += "mage/" + (EnemyDesignerWindow.MageInfo.name + ".prefab");
                //get prefab path
                prefabPath = AssetDatabase.GetAssetPath(EnemyDesignerWindow.MageInfo.prefab);
                AssetDatabase.CopyAsset(prefabPath, newPrefabPath);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();

                GameObject magePrefab = (GameObject)AssetDatabase.LoadAssetAtPath(newPrefabPath, typeof(GameObject));
                if (!magePrefab.GetComponent<Mage>())
                    magePrefab.AddComponent(typeof(Mage));
                magePrefab.GetComponent<Mage>().mageData = EnemyDesignerWindow.MageInfo;
                break;

            case SettingsType.WARRIOR:
                //create the .asset file
                dataPath += "warrior/" + EnemyDesignerWindow.WarriorInfo.name + ".asset";
                AssetDatabase.CreateAsset(EnemyDesignerWindow.WarriorInfo, dataPath);

                newPrefabPath += "warrior/" + (EnemyDesignerWindow.WarriorInfo.name + ".prefab");
                //get prefab path
                prefabPath = AssetDatabase.GetAssetPath(EnemyDesignerWindow.WarriorInfo.prefab);
                AssetDatabase.CopyAsset(prefabPath, newPrefabPath);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();

                GameObject warriorPrefab = (GameObject)AssetDatabase.LoadAssetAtPath(newPrefabPath, typeof(GameObject));
                if (!warriorPrefab.GetComponent<Warrior>())
                    warriorPrefab.AddComponent(typeof(Warrior));
                warriorPrefab.GetComponent<Warrior>().warriorData = EnemyDesignerWindow.WarriorInfo;
                break;

            case SettingsType.ROGUE:
                //create the .asset file
                dataPath += "rogue/" + EnemyDesignerWindow.RogueInfo.name + ".asset";
                AssetDatabase.CreateAsset(EnemyDesignerWindow.RogueInfo, dataPath);

                newPrefabPath += "rogue/" + (EnemyDesignerWindow.RogueInfo.name + ".prefab");
                //get prefab path
                prefabPath = AssetDatabase.GetAssetPath(EnemyDesignerWindow.RogueInfo.prefab);
                AssetDatabase.CopyAsset(prefabPath, newPrefabPath);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();

                GameObject roguePrefab = (GameObject)AssetDatabase.LoadAssetAtPath(newPrefabPath, typeof(GameObject));
                if (!roguePrefab.GetComponent<Rogue>())
                    roguePrefab.AddComponent(typeof(Rogue));
                roguePrefab.GetComponent<Rogue>().rogueData = EnemyDesignerWindow.RogueInfo;
                break;

        }


    }
}