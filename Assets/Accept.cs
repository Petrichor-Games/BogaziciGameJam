using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Accept : MonoBehaviour
{
 

    public Button accept_button;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = accept_button.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TaskOnClick()
    {
     

    }




}
