using System.Collections.Generic;
using UnityEngine;

public class ViewManager : MonoBehaviour
{
    private static ViewManager s_instance;

    [SerializeField] private View _startingView;
    [SerializeField] private View[] _views;

    private View _currentView;

    private readonly Stack<View> _history = new Stack<View>();
    private void Awake() => s_instance = this;

    public static T GetView<T>() where T : View
    {
        foreach (var t in s_instance._views)
        {
            if (t is T tView)
            {
                return tView;
            }
        }

        return null;
    }

    public static void Show<T>(bool remember = true) where T : View
    {
        foreach (var t in s_instance._views)
        {
            if (t is T)
            {
                if (s_instance._currentView != null)
                {
                    s_instance._history.Push(s_instance._currentView);
                }
            }
            
            t.Show();

            s_instance._currentView = t;
        }
    }

    public static void Show(View view, bool remember = true)
    {
        if (s_instance._currentView != null)
        {
            if (remember)
            {
                s_instance._history.Push(s_instance._currentView);
            }
            
            s_instance._currentView.Hide();
        }
        
        view.Show();
        s_instance._currentView = view;
    }

    public static void ShowLast()
    {
        if (s_instance._history.Count != 0)
        {
            Show(s_instance._history.Pop(),false);
        }
    }
}
