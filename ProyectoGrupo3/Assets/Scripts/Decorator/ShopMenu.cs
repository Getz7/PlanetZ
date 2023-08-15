using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.SceneManagement;

    public class ShopMenu : MonoBehaviour
    {
        public static ShopMenu instance;
        [SerializeField] public Shop shop;
        public PlayerController playerController;
        public static bool GameIsPaused = false;
        public GameObject pauseMenuUI;
        public ControladorPuntos controladorPuntos;
        public FlyWeight flyWeight;
        public IFlyWeightFactory iflyWeightFactory;
        
        void Start()
        {
            pauseMenuUI.SetActive(false);
            iflyWeightFactory = new IFlyWeightFactory();


        }


        void Update()
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                if (GameIsPaused)
                {
                    Input.GetKeyDown(KeyCode.B);
                    Resume();
                }
                else
                {
                    Pause();

                }
            }
        }

        public void Resume()
        {
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            GameIsPaused = false;
        }

        void Pause()
        {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;
        }


        public void SpeedPotion1()
        {
        FlyWeight flyweight = shop.GetItemFlyweight("SpeedPotion1");
        if (HasEnoughPoints(flyweight.itemPrice))
        {
            DeductPoints(flyweight.itemPrice);
            IDecorator decorator = new SpeedBoostDecorator(3f);
            playerController.ApplyDecorator(decorator);
        }
        else
            {
           
            }

            Resume();
        }

        public void SpeedPotion2()
        {
            FlyWeight flyweight = shop.GetItemFlyweight("SpeedPotion2");
            if (HasEnoughPoints(flyweight.itemPrice))
            {
                DeductPoints(flyweight.itemPrice);
                IDecorator decorator = new SpeedBoostDecorator(9f);
                playerController.ApplyDecorator(decorator);
            
            }
            else
            {
            
            }

          Resume();

        }
        public void OnePunchMan()
        {
            FlyWeight flyweight = shop.GetItemFlyweight("One-Punch Man");
            if (HasEnoughPoints(flyweight.itemPrice))
            {
                DeductPoints(flyweight.itemPrice);
                IDecorator decorator = new DamageBoostDecorator(99999);
                playerController.ApplyDecorator(decorator);
           

            }
            else
            {

            }
            Resume();
      

        }

        public void JumpPotion1()
        {
            FlyWeight flyweight = shop.GetItemFlyweight("JumpPotion1");
            if (HasEnoughPoints(flyweight.itemPrice))
            {
                DeductPoints(flyweight.itemPrice);
                IDecorator decorator = new jumpBoostDecorator(3f);
                playerController.ApplyDecorator(decorator);
            
            }
            else
            {
           
            }
            Resume();
       

        }
        public void JumpPotion2()
        {
            FlyWeight flyweight = shop.GetItemFlyweight("JumpPotion2");
            if (HasEnoughPoints(flyweight.itemPrice))
            {
                DeductPoints(flyweight.itemPrice);
                IDecorator decorator = new jumpBoostDecorator(7f);
                playerController.ApplyDecorator(decorator);
            
            }
            else
            {
           
            }
            Resume();
        

        }
        private bool HasEnoughPoints(int amount)
        {
            return controladorPuntos.CantidadPuntos >= amount;
        }

        private void DeductPoints(int amount)
        {
            controladorPuntos.CantidadPuntos -= amount;
        }
     
    }
