using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

    public class ViewManager : MonoBehaviour
    {
        private static ViewManager instance;

        [SerializeField] private List<View> views = new List<View>();
        [SerializeField] private View startingView;
        [SerializeField] private View currentView;

        private readonly Stack<View> history = new Stack<View>();


        /**
         * Este es un método estático que busca una vista específica de tipo T en el arreglo de vistas views de la
         * instancia actual de ViewManager.
         * Si la vista se encuentra, se devuelve esa vista, de lo contrario se devuelve null.
         */
        public static T GetView<T>() where T : View
        {
            foreach (var t in instance.views)
            {
                if (t is T tView)
                {
                    return tView;
                }
            }

            return null;
        }


        /**
         * Este método estático muestra la vista de tipo T en la pantalla.
         * Si remember es true, la vista actual se guarda en una pila para que pueda ser recuperada más tarde.
         * Si hay una vista actual, se oculta antes de mostrar la nueva vista.
         * El campo currentView se establece en la nueva vista.
         * T debe existir en la lista
         */
        public static void Show<T>(bool remember = true)
        {
            foreach (var t in instance.views.Where(t => t is T))
            {
                if (instance.currentView != null)
                {
                    if (remember)
                    {
                        instance.history.Push(instance.currentView);
                    }

                    instance.currentView.Hide();
                }

                t.Show();
                instance.currentView = t;
            }
        }

        /**
         * Este método estático muestra una vista específica en la pantalla.
         * Si remember es true, la vista actual se guarda en una pila para que pueda ser recuperada más tarde.
         * Si hay una vista actual, se oculta antes de mostrar la nueva vista. El campo currentView se establece en la nueva vista.
         */
        static void Show(View view, bool remember = true)
        {
            if (instance.currentView != null)
            {
                if (remember)
                {
                    instance.history.Push(instance.currentView);
                }

                instance.currentView.Hide();
            }

            view.Show();

            instance.currentView = view;
        }

        /**
         * Este método estático muestra la última vista guardada en la pila history.
         * Si la pila no está vacía, la última vista se muestra y se elimina de la pila.
         * El parámetro false se usa para que no se guarde la vista actual en la pila.
         */
        public static void ShowLast()
        {
            if (instance.history.Count != 0)
            {
                Show(instance.history.Pop(), false);
            }
        }

        private void Awake() => instance = this;

        private void Start()
        {
            foreach (var t in views)
            {
                t.Initialize();
                t.Hide();
            }

            if (startingView != null)
            {
                Show(startingView);
            }
        }
    }