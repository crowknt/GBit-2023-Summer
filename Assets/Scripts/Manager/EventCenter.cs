using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IEventInfo
{
    
}

//无参数事件
public class EventInfo : IEventInfo
{
    public UnityAction Actions;

    public EventInfo(UnityAction action)
    {
        Actions += action;
    }
}
//有参数事件：（若需要更多参数，可依此为基准重载更多，UnityAction最多支持4个参数）
public class EventInfo<T> : IEventInfo
{
    public UnityAction<T> Actions;

    public EventInfo(UnityAction<T> action)
    {
        Actions += action;
    }
}

public class EventInfo<T, X> : IEventInfo
{
    public UnityAction<T, X> Actions;

    public EventInfo(UnityAction<T, X> action)
    {
        Actions += action;
    }
}

public class EventInfo<T, X, Y> : IEventInfo
{
    public UnityAction<T, X, Y> Actions;

    public EventInfo(UnityAction<T, X, Y> action)
    {
        Actions += action;
    }
}

public class EventCenter
{
    private static EventCenter _instance;

    public static EventCenter Instance
    {
        get { return _instance ??= new EventCenter(); }
    }

    private EventCenter()
    {
        
    }
    
    
    private readonly Dictionary<string, IEventInfo> _eventDictionary = new();


    #region 添加事件监听 Add Event Listener
    /// <summary>
    /// Add Event Listener with no parameter. Call the corresponding remove func when the object which listens the event is destroyed
    /// </summary>
    /// <param name="name"></param>
    /// <param name="action"></param>
    public void AddListener(string name, UnityAction action)
    {
        if (_eventDictionary.TryGetValue(name,out var value))
        {
            if (value is EventInfo eventInfo)
            {
                eventInfo.Actions += action;
            }
            else
            {
                Debug.LogWarning($"请检查事件类型，需要是{typeof(EventInfo)}");
            }
        }
        else
        {
            _eventDictionary.Add(name,new EventInfo(action));
        }
    }
    /// <summary>
    /// Add Event Listener with 1 parameter. Call the corresponding remove func when the object which listens the event is destroyed
    /// </summary>
    /// <param name="name"></param>
    /// <param name="action"></param>
    /// <typeparam name="T"></typeparam>
    public void AddListener<T>(string name, UnityAction<T> action)
    {
        if (_eventDictionary.TryGetValue(name,out var value))
        {
            if (value is EventInfo<T> eventInfo)
            {
                eventInfo.Actions += action;
            }else
            {
                Debug.LogWarning($"请检查事件类型，需要是{typeof(EventInfo<T>)}");
            }
        }
        else
        {
            _eventDictionary.Add(name,new EventInfo<T>(action));
        }
    }
    /// <summary>
    /// Add Event Listener with 2 parameter. Call the corresponding remove func when the object which listens the event is destroyed
    /// </summary>
    /// <param name="name"></param>
    /// <param name="action"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="X"></typeparam>
    public void AddListener<T, X>(string name, UnityAction<T, X> action)
    {
        if (_eventDictionary.TryGetValue(name, out var value))
        {
            if (value is EventInfo<T, X> eventInfo)
            {
                eventInfo.Actions += action;
            }
            else
            {
                Debug.LogWarning($"请检查事件类型，需要是{typeof(EventInfo<T,X>)}");
            }
        }
        else
        {
            _eventDictionary.Add(name,new EventInfo<T,X>(action));
        }
    }
    /// <summary>
    /// Add Event Listener with 3 parameter. Call the corresponding remove func when the object which listens the event is destroyed
    /// </summary>
    /// <param name="name"></param>
    /// <param name="action"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="X"></typeparam>
    /// <typeparam name="Y"></typeparam>
    public void AddListener<T, X, Y>(string name, UnityAction<T, X, Y> action)
    {
        if (_eventDictionary.TryGetValue(name, out var value))
        {
            if (value is EventInfo<T, X, Y> eventInfo)
            {
                eventInfo.Actions += action;
            }
            else
            {
                Debug.LogWarning($"请检查事件类型，需要是{typeof(EventInfo<T,X,Y>)}");
            }
        }
        else
        {
            _eventDictionary.Add(name,new EventInfo<T,X,Y>(action));
        }
    }

    #endregion


    #region 移除事件监听 Remove Event Listener
    
    /// <summary>
    /// Remove event listener with No parameter.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="action"></param>
    public void RemoveEventListener(string name, UnityAction action)
    {
        if (_eventDictionary.TryGetValue(name, out var value))
        {
            if (value is EventInfo eventInfo)
            {
                eventInfo.Actions -= action;
            }
            else
            {
                Debug.LogWarning($"请检查事件类型，需要是{typeof(EventInfo)}");
            }
        }
        else
        {
            Debug.LogWarning($"没有{name}事件");
        }
    }
    
    /// <summary>
    /// Remove event listener with 1 parameter.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="action"></param>
    /// <typeparam name="T"></typeparam>
    public void RemoveEventListener<T>(string name, UnityAction<T> action)
    {
        if (_eventDictionary.TryGetValue(name, out var value))
        {
            if (value is EventInfo<T> eventInfo)
            {
                eventInfo.Actions -= action;
            }
            else
            {
                Debug.LogWarning($"请检查事件类型，需要是{typeof(EventInfo<T>)}");
            }
        }
        else
        {
            Debug.LogWarning($"没有{name}事件");
        }
    }

    /// <summary>
    /// Remove event listener with 2 parameter.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="action"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="X"></typeparam>
    public void RemoveEventListener<T, X>(string name, UnityAction<T, X> action)
    {
        if (_eventDictionary.TryGetValue(name, out var value))
        {
            if (value is EventInfo<T, X> eventInfo)
            {
                eventInfo.Actions -= action;
            }
            else
            {
                Debug.LogWarning($"请检查事件类型，需要是{typeof(EventInfo<T,X>)}");
            }
        }
        else
        {
            Debug.LogWarning($"没有{name}事件");
        }
    }

    /// <summary>
    /// Remove event listener with 3 parameter.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="action"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="X"></typeparam>
    /// <typeparam name="Y"></typeparam>
    public void RemoveEventListener<T, X, Y>(string name, UnityAction<T, X, Y> action)
    {
        if (_eventDictionary.TryGetValue(name, out var value))
        {
            if (value is EventInfo<T, X, Y> eventInfo)
            {
                eventInfo.Actions -= action;
            }
            else
            {
                Debug.LogWarning($"请检查事件类型，需要是{typeof(EventInfo<T,X,Y>)}");
            }
        }
        else
        {
            Debug.LogWarning($"没有{name}事件");
        }
    }

    #endregion


    #region 触发事件 Trigger Event

    /// <summary>
    /// Trigger a event based on the name. No parameter. Please ensure the name is correct.
    /// </summary>
    /// <param name="name"></param>
    public void EventTrigger(string name)
    {
        if (_eventDictionary.TryGetValue(name, out var value))
        {
            if (value is EventInfo eventInfo)
            {
                eventInfo.Actions?.Invoke();
            }
            else
            {
                Debug.LogWarning($"请检查事件类型，需要是{typeof(EventInfo)}");
            }
        }
        else
        {
            Debug.LogWarning($"没有{name}事件");
        }
    }

    /// <summary>
    /// Trigger a event based on the name. 1 parameter. Please ensure the name is correct.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="arg"></param>
    /// <typeparam name="T"></typeparam>
    public void EventTrigger<T>(string name, T arg)
    {
        if (_eventDictionary.TryGetValue(name, out var value))
        {
            if (value is EventInfo<T> eventInfo)
            {
                eventInfo.Actions?.Invoke(arg);
            }
            else
            {
                Debug.LogWarning($"请检查事件类型，需要是{typeof(EventInfo<T>)}");
            }
        }
        else
        {
            Debug.LogWarning($"没有{name}事件");
        }
    }

    /// <summary>
    /// Trigger a event based on the name. 2 parameter. Please ensure the name is correct.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="arg1"></param>
    /// <param name="arg2"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="X"></typeparam>
    public void EventTrigger<T, X>(string name, T arg1, X arg2)
    {
        if (_eventDictionary.TryGetValue(name, out var value))
        {
            if (value is EventInfo<T, X> eventInfo)
            {
                eventInfo.Actions?.Invoke(arg1,arg2);
            }
            else
            {
                Debug.LogWarning($"请检查事件类型，需要是{typeof(EventInfo<T,X>)}");
            }
        }
        else
        {
            Debug.LogWarning($"没有{name}事件");
        }
    }

    /// <summary>
    /// Trigger a event based on the name. 3 parameter. Please ensure the name is correct.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="arg1"></param>
    /// <param name="arg2"></param>
    /// <param name="arg3"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="X"></typeparam>
    /// <typeparam name="Y"></typeparam>
    public void EventTrigger<T, X, Y>(string name, T arg1, X arg2, Y arg3)
    {
        if (_eventDictionary.TryGetValue(name, out var value))
        {
            if (value is EventInfo<T, X, Y> eventInfo)
            {
                eventInfo.Actions?.Invoke(arg1,arg2,arg3);
            }
            else
            {
                Debug.LogWarning($"请检查事件类型，需要是{typeof(EventInfo<T,X,Y>)}");
            }
        }
        else
        {
            Debug.LogWarning($"没有{name}事件");
        }
    }

    #endregion
}
