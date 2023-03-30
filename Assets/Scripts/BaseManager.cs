using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseManager<T> : MonoBehaviour where T: BaseManager<T>            // buộc T phải là con của BaseManager để làm kiểu dữ liệu cho instance
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance ==null)
            {
                instance = Object.FindObjectOfType<T>();
                if (instance == null)
                {
                    Debug.Log($"No {typeof(T).Name} Singleton Instance");          //chưa từng thấy chạy
                }    
            }
            return instance;
        }
    }

    

    public static bool HasInstance
    {
        get
        {
            return (instance != null);
        }
    }    
    protected virtual void Awake()
    {
        CheckInstance();
    } 
    protected bool CheckInstance()
    {
        if ( instance == null )
        {
            instance = (T)this;
            DontDestroyOnLoad(this);
            return true;
        }
        else if (instance== this)
        {

            DontDestroyOnLoad(this);
            return true;
        }
        Object.Destroy(this.gameObject);
        return false;
    }    

}
