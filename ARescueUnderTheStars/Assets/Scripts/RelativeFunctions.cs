using UnityEngine;
using System.Collections;


public class RelativeFunctions : MonoBehaviour {

    public static RelativeFunctions functs;
    Camera cam;

    void Awake()
    {
        cam =  GetComponent<Camera>();
        if (functs == null)
        {
            functs = this;
        }
        else if(functs != this)
        {
            Destroy(gameObject);
        }

        //Sets to not be destroyed on loading a new scene
        DontDestroyOnLoad(gameObject);
    }

    public RelativeFunctions getFuncts()
    {
        return functs;
    }

    public float mouseAngle (GameObject originObject)
    {
        //var returnValue = Vector2.Angle(new Vector2(originObject.transform.position.x, originObject.transform.position.y), Input.mousePosition);
        Vector2 ObjectPos = new Vector2(originObject.transform.position.x, originObject.transform.position.y);
        var translatedMousePos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, originObject.transform.position.z));
        var returnValue = Vector2.Angle(ObjectPos, new Vector2(translatedMousePos.x, translatedMousePos.y));
        return returnValue;
    }

    public Vector3 getMousePos (GameObject originObject)
    {
        var levelMousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, originObject.transform.position.z);
        var translatedMousePos = cam.ScreenToWorldPoint(levelMousePos);
        return translatedMousePos;
    }
}
