using UnityEngine;
using Assets.Core.Logic.Controllers;
using Assets.GameCore.Logic.Enums;
using System.Collections.Generic;

public class Graphic : MonoBehaviour
{

    private void Awake()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        buyMenu = new Rect(Screen.width - 185.0f, 10.0f, 175.0f, Screen.height - 100.0f);
        firstTower = new Rect(buyMenu.x + 12.5f, buyMenu.y + 30.0f, 150.0f, 50.0f);

        playerStats = new Rect(10.0f, 10.0f, 150.0f, 100.0f);
        playerStatsPlayerMoney = new Rect(playerStats.x + 12.5f, playerStats.y + 30.0f, 125.0f, 25.0f);
        
        
    }


    public Rect buyMenu; //квадрат меню покупки
    public Rect firstTower; //квадрат кнопки покупки первой башни
    public Rect playerStats; //квадрат статистики игрока
    public Rect playerStatsPlayerMoney; //квадрат зоны отображения денег игрока
    private GameObject standartTower;



    private RaycastHit hit; // переменная для рейкаста, хз что это
    public LayerMask raycastLayers = 1; // тоже хз
    private GameObject ghost;
    private GameController gameController;
    private TowerType currTower;
    

    // Update is called once per frame
    void Update()
    {
        switch (gameController.MouseState)
        {
            case ClickState.buildTower:
                buildingTower();
                break;
            default:
                break;
        }
    }

    private void buildingTower()
    {
        if (ghost == null)
        {
            ghost = Instantiate(gameController.GetTowerObject(currTower));
        }
        else
        {
            Ray scrRay = Camera.main.ScreenPointToRay(Input.mousePosition); //создаём луч, бьющий от координат мыши по координатам в игре
            if (Physics.Raycast(scrRay, out hit, Mathf.Infinity, raycastLayers)) // бьём этим лучем в заданном выше направлении (т.е. в землю)
            {
                Quaternion normana = Quaternion.FromToRotation(Vector3.up, hit.normal); //получаем нормаль от столкновения
                ghost.transform.position = hit.point; //задаём позицию призрака равной позиции точки удара луча по земле
                ghost.transform.rotation = normana; //тоже самое и с вращением, только не от точки, а от нормали
                if (Input.GetMouseButtonDown(0)) //при нажатии ЛКМ
                {
                    GameObject tower = Instantiate(gameController.GetTowerObject(currTower), ghost.transform.position, ghost.transform.rotation) as GameObject; //Спауним башенку на позиции призрака
                    if (tower != null)
                    {
                        //gv.PlayerMoney -= tower.GetComponent<PlasmaTurretAI>().towerPrice;
                    }
                    Destroy(ghost); //уничтожаем призрак башни
                    gameController.MouseState = ClickState.Default;
                }
            }
        }
    }

    private void OnGUI()
    {
        GUI.Box(buyMenu, "Buying menu"); //Делаем гуевский бокс на квадрате buyMenu с заголовком, указанным между ""

        if (GUI.Button(firstTower, "Обычная башенка\n100 монеток")) //если идёт нажатие на первую кнопку
        {
            gameController.MouseState = ClickState.buildTower;
            currTower = TowerType.StandartTower;
        }

        //GUI.Box(playerStats, "Player Stats");
        //GUI.Label(playerStatsPlayerMoney, "Money: " + gameController.PlayerMoney + "монеток");
    }
}
