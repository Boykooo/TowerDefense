﻿using Assets.Core.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.GameCore.Turrets.AbstractClasses;
using Assets.GameCore.Turrets.TurretsTypes;
using Assets.GameCore.Logic.Enums;

namespace Assets.Core.Logic.Controllers
{
    class GameController : MonoBehaviour, IGameController
    {
        public GameController()
        {
            mobsList = new List<GameObject>();
            towersList = new List<GameObject>();
            InitWayPoints();
            towerSettings = new Dictionary<string, BaseTower>()
            {
                {"StandartTower(Clone)", new StandartTower()}
            };
            MouseState = ClickState.Default;
        }
        private void Start()
        {
            towerObject = new Dictionary<TowerType, GameObject>()
            {
                { TowerType.StandartTower, standartTower}
            };
        }


        private List<GameObject> mobsList;
        private List<GameObject> towersList;
        private Dictionary<string, BaseTower> towerSettings;
        private Dictionary<TowerType, GameObject> towerObject;



        public GameObject standartTower;
        public GameObject arrow;


        public Vector3[] wayPoints { get; private set; } //множество точек маршрута
        public int PlayerMoney { get; set; }
        public int MobCount { get; set; }
        public ClickState MouseState { get; set; } //дефолтное состояние курсора


        private void InitWayPoints()
        {
            wayPoints = new Vector3[]
            {
                new Vector3(19,0,95),
                new Vector3(19,0,45),
                new Vector3(92,0,45),
                new Vector3(92,0,5),
            };
        }
        public GameObject GetTowerObject(TowerType towerType)
        {
            if (towerObject.ContainsKey(towerType))
            {
                return towerObject[towerType];
            }

            return null;
        }

        public void AddMob(GameObject obj)
        {

            MobCount++;
        }
        public void AddTower(GameObject obj)
        {

        }
        public void RemoveMob(GameObject obj)
        {
        }
        public void RemoveTower(GameObject obj)
        {

        }
        public BaseTower GetTower(string name)
        {
            if (towerSettings.ContainsKey(name))
            {
                return towerSettings[name];
            }
            return null;
        }

    }
}