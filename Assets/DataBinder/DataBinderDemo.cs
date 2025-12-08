using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using SimpleJSON;
using TMPro;

public class DataBinderDemo : MonoBehaviour
{
    [SerializeField]
    private DataBinder m_dataBinder;                            //Element that registers data and binds it to all connected dataBinder components

    [SerializeField]
    private DataBinderList m_dataList;                          //Element that generates and controls a list of dataBinder prefabs

    [SerializeField]
    private Animator m_chartWipe;                               //Animator that controls the animation of the wipe that covers the chart during data transition

    private const string PATH_TO_JSON_FILE = "/JSONData/";      //Path (relative to the streaming assets path) pointing to the JSON files
    private const string STARTUP_DATA = "Nasdaq.json";          //Specifies the JSON file to read from on app start

    private void Start()
    {
        SetStartupData();
    }

    /// <summary>
    /// Read from the startup data json file and bind the data to the dataBinder and dataBinder list, bypassing the wipe animation
    /// </summary>
    private void SetStartupData()
    {
        JSONNode json = FileReader.ReadJSONFromFile(Application.streamingAssetsPath + PATH_TO_JSON_FILE + STARTUP_DATA);
        if (json != null)
            StartCoroutine(ChangeData(json, false));
        else
            Debug.LogError($"JSON file {STARTUP_DATA} does not exist. Could not change data.");
    }

    /// <summary>
    /// Reads from the JSON file requested and if the JSON data exists, change the data
    /// </summary>
    /// <param name="JSONFile"></param>
    public void TryChangeData(string JSONFile)
    {
        JSONNode json = FileReader.ReadJSONFromFile(Application.streamingAssetsPath + PATH_TO_JSON_FILE + JSONFile);
        if (json != null)
            StartCoroutine(ChangeData(json));
        else
            Debug.LogError($"JSON file {JSONFile} does not exist. Could not change data.");
    }

    /// <summary>
    /// Function that registers data to the dataBinder and dataBinder list, and the generates the list of prefabs accordingly and binds the data to the data binder 
    /// Both the dataBinder and the dataBinder list use the same json data in this example but target different nodes within 
    /// </summary>
    /// <param name="json">JSON data to pass to the dataBinder elements</param>
    /// <returns></returns>
    private IEnumerator ChangeData(JSONNode json, bool playAnimation = true)
    {
        //Generates a list of dataBinders based on the json provided
        m_dataList.GenerateList(json);

        //Registers the json data provided to the dataBinder
        m_dataBinder.RegisterData(json);

        //Plays the animation for the chart wipe and waits for half of the animation
        if(playAnimation)
            yield return StartCoroutine(AnimationDispatcher.TriggerAnimation(m_chartWipe, "Play", 0.5f));

        //Bind the new data to all databinder components tied to the dataBinder
        m_dataBinder.BindData(); 
    }
}
