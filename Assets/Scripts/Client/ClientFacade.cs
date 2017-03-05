using System;
using Proxy;
using UnityEngine;
using System.Collections.Generic;

namespace Assets.Scripts.Client
{
    public class ClientFacade : MonoBehaviour, IClientFacade
    {
        private void Awake()
        {
            box = GameObject.FindGameObjectWithTag("ClientFacade").GetComponent<MessageBox>();
            actions = new List<Action>();
        }

        private MessageBox box;
        private List<Action> actions;
        private object key = new object();
        public event Action disconnect = () => { };


        private void Update()
        {
            lock (key)
            {
                while (actions.Count != 0)
                {
                    actions[0].Invoke();
                    actions.RemoveAt(0);
                }
            }
        }

        public void EnterTheGame(string login)
        {
            actions.Add(() => Application.LoadLevel(2));
        }

        public void ErrorSignIn(string message)
        {
            box.Show(message);
            disconnect();
        }

        public void ErrorSignUp(string message)
        {
            box.Show(message);
            disconnect();
        }

        public void SuccessfulSignUp()
        {
            box.Show("Регистрация прошла успешна");
        }
    }
}
