# Case Study: Data Binders

Designed and developed a "No-code" data binder system that allows simple generic data binding of JSON data to various UGUI components.

---

## Tools & Technologies
- Unity UGUI
- C#  
- JSON 
- Git version control  

---

## Role & Responsibilities 
- Designed the code architecture for the system
- Determined and prioritized needed components with mentality towards easy scalling 
- Built modular, data-binder components  
- Built single point of entry component for easy one line consumer implementation
- Built single point of entry component for generating prefabs from JSON array data

---

## Challenge
Creating data-driven graphics generally involves the hard coding of data mapped to various serialized components. This makes the creation of graphics a very programmer first approach and is not very agile. 
This also involves an ever increasing code base to maintain as the graphics increase in scope and new graphics are created.

---

## Solution
Take an MVVM approach and create reusable components that can specify what field from a JSON payload to use and how to bind that data to various UGUI components. 
Each of these binder components would then be attached to a parent Data Binder that would feed them the JSON data provided by the graphic class. 
In this way, the graphic class only has knowledge of the parent binder to allow for the transfer of data. 
This approach abstracts out all of the graphical binding logic from the graphic class and allows for very quick modifications with zero code manipulation once implemented.

---

## Outcome / Impact
Vastly improved turn-around speed and build stability for graphic modifications/additions and changes to data binding. 
- Before -> days of development time with extra QA required to catch bugs and issues
- After -> hours of implementation time with zero QA required since design/data modifications resulted in zero changes to code  

---

## Key Learnings
- Abstracting out data binding logic vastly helps reduce code complexity and improve scalability
- "No-Code" scalable systems allow for reduced scope of QA and vastly reduces the amount of code maintenance, as well as the chances for error

---

## Exhibit Space
Runtime results:
![Data-Binders Demo](Media/Data-Binder-Sample-Demo.gif)

Code required to bind all of the data to graphics for this demo:
<pre>public class DataBinderDemo : MonoBehaviour
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

    private void SetStartupData()
    {
        JSONNode json = FileReader.ReadJSONFromFile(Application.streamingAssetsPath + PATH_TO_JSON_FILE + STARTUP_DATA);
        if (json != null)
            StartCoroutine(ChangeData(json, false));
        else
            Debug.LogError($"JSON file {STARTUP_DATA} does not exist. Could not change data.");
    }

    public void TryChangeData(string JSONFile)
    {
        JSONNode json = FileReader.ReadJSONFromFile(Application.streamingAssetsPath + PATH_TO_JSON_FILE + JSONFile);
        if (json != null)
            StartCoroutine(ChangeData(json));
        else
            Debug.LogError($"JSON file {JSONFile} does not exist. Could not change data.");
    }

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
</pre>
