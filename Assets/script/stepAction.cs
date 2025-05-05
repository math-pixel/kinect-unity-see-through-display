using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class stepAction : MonoBehaviour
{
    
    public List<GameObject> listObjects;
    private GameObject currentObject;
    private int idObject = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (listObjects[idObject] != null)
        {
            currentObject = Instantiate(listObjects[0], gameObject.transform.position, Quaternion.identity);
            currentObject.transform.localScale = new Vector3(0.28f, 0.28f, 0.28f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (idObject + 1 < listObjects.Count)
            {
                previousStep();
            }
        }
        
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (idObject - 1 >= 0)
            {
                nextStep();
            }
        }
    }

    bool objectIsValid()
    {
        bool validateState = true;

        // if object is valid

        return validateState;
    }

    void nextStep()
    {
        Destroy(currentObject);
        idObject--;
        currentObject = Instantiate(listObjects[idObject], gameObject.transform.position, Quaternion.identity);
        currentObject.transform.localScale = new Vector3(0.28f, 0.28f, 0.28f);
    }

    void previousStep()
    {
        Destroy(currentObject);
        idObject++;
        currentObject = Instantiate(listObjects[idObject], gameObject.transform.position, Quaternion.identity);
        currentObject.transform.localScale = new Vector3(0.28f, 0.28f, 0.28f);
    }
}
