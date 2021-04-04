using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
 
    public string CurrentScore = "0";
    public string playerName = "";

    [SerializeField]
    private Text nameText;
    [SerializeField]
    private Text scoreText;
    /*[SerializeField]
    private GameObject menu;

    private bool isPaused = false;

    private void Awake()
    {
        Pause();
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void Pause()
    {
        menu.SetActive(true);
        Cursor.visible = true;
        Time.timeScale = 0;
        isPaused = true;
    }

    public void Unpause()
    {
        menu.SetActive(false);
        Cursor.visible = false;
        Time.timeScale = 1;
        isPaused = false;
    }

    public bool IsGamePaused()
    {
        return isPaused;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (isPaused)
            {
                Unpause();
            }
            else
            {
                Pause();
            }
        }
    }
    */
    
    public void SaveGame()
    {
        // 1
        Save save = CreateSaveGameObject();

        // 2
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");
        bf.Serialize(file, save);
        file.Close();

        // 3
        CurrentScore = "";
        playerName = "";
        scoreText.text = CurrentScore;
        nameText.text = playerName;

        Debug.Log("Game Saved");
    }

    public void NewGame()
    {
        CurrentScore = "";
        playerName = "";
        scoreText.text = "Score: " + scoreText;
        nameText.text = "Name: " + playerName;

        //Unpause();
    }

    private Save CreateSaveGameObject()
    {
        Save save = new Save();
       // int i = 0;
       /* foreach (GameObject targetGameObject in targets)
        {
            Target target = targetGameObject.GetComponent<Target>();
            if (target.activeRobot != null)
            {
                save.livingTargetPositions.Add(target.position);
                i++;
            }
        }*/

        save.CurrentScore = CurrentScore;
        save.playerName = playerName;

        return save;
    }

    public void LoadGame()
    {
        // 1
        if (File.Exists(Application.persistentDataPath + "/gamesave.save"))
        {
          

            // 2
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
            Save save = (Save)bf.Deserialize(file);
            file.Close();

           

            // 4
            scoreText.text = save.CurrentScore;
            nameText.text = save.playerName;
            CurrentScore = save.CurrentScore;
            playerName = save.playerName;

            Debug.Log("Game Loaded");

            //Unpause();
        }
        else
        {
            Debug.Log("No game saved!");
        }
    }
 
    public void SaveAsJSON()
    {
        Save save = CreateSaveGameObject();
        string json = JsonUtility.ToJson(save);

        Debug.Log("Saving as JSON: " + json);
    }
}
