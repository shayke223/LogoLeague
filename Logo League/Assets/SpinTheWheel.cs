using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpinTheWheel : MonoBehaviour {

    public bool TestMode = false;
    public UpdateUIText Money;
    public UpdateUIText2 Spins;
    public string[] Rewards;

    public float FadingRate;
    [SerializeField]
    private float Timer;
    [SerializeField]
    private float Speed;

    public GameObject ButtonBlocker;

    private bool FinishedSpinning,AlreadyWon;

    public Text[] RewardsText;

    public GameObject[] RewardsImage;
    public Sprite[] AllSymbols;

    public GameManagerObject ManagerObject;
    public GameObject Particle;
    public Text ThePrice;

    public GameObject Sound;

    public int[] Prices;
    public int[] PricesAll4;

    public GameObject NoSpins;

    void Start () {
        ManagerObject = GameObject.Find("GameManagerObject").GetComponent<GameManagerObject>();
        ButtonBlocker.SetActive(false);
        FinishedSpinning = false;
        AlreadyWon = false;
        New4Rewards();
    }
	
	
	void Update () {
       


        if (!AlreadyWon) { if (Timer < 0) { ButtonBlocker.SetActive(false); FinishedSpinning = true; CheckReward(); AlreadyWon = true; } }
        if (!FinishedSpinning)
        {
            if (Timer > 0)
            {
                transform.Rotate(0, 0, Speed *Time.deltaTime * 10);
                Timer -= 1 * Time.deltaTime;
                if (Timer < 3.5f && Timer > 0)
                {
                    if (Speed > 0)
                    {
                        Speed -= FadingRate* 10 * Time.deltaTime;

                    }
                }
            }
        }
	}
    public void Roll()
    {

        ManagerObject.PlaySound();
        if (ManagerObject.Spins > 0)
        {


            New4Rewards();
            Timer = Random.Range(3, 4.5f);
            Speed = Random.Range(90, 100);
            if (TestMode) { Speed = 0.1f; Timer = 0.1f; }
            FinishedSpinning = false;
            AlreadyWon = false;
            ButtonBlocker.SetActive(true);
            ManagerObject.Spins--;
        }
        else NoSpins.gameObject.SetActive(true);
        CancelInvoke("DisableText");
        Invoke("DisableText",2);
    }
    public void CheckReward()
    {
        float Pos = transform.localRotation.eulerAngles.z;
        if (Pos > 0 && Pos <= 45)
        {
            if (PricesAll4[1] == 3333) { ManagerObject.Spins += 2; ThePrice.text = "2 Free Spins!"; }
            else
            if (PricesAll4[1] == 1111) { ManagerObject.Spins += 1; ThePrice.text = "1 Free Spins!"; }
            else
            {
                ManagerObject.Cash += PricesAll4[1];
                ThePrice.text = PricesAll4[1] + " Coins!";
            }
           
        }
        if (Pos > 45 && Pos <= 90)
        {
            if (PricesAll4[2] == 3333) { ManagerObject.Spins += 2; ThePrice.text = "2 Free Spins!"; }
            else
            if (PricesAll4[2] == 1111) { ManagerObject.Spins += 1; ThePrice.text = "1 Free Spins!"; }
            else
            {
                ManagerObject.Cash += PricesAll4[2];
                ThePrice.text = PricesAll4[2] + " Coins!";
            }
        }
        if (Pos > 90 && Pos <= 135)
        {
            if (PricesAll4[3] == 3333) { ManagerObject.Spins += 2; ThePrice.text = "2 Free Spins!"; }
            else
            if (PricesAll4[3] == 1111) { ManagerObject.Spins += 1; ThePrice.text = "1 Free Spins!"; }
            else
            {
                ManagerObject.Cash += PricesAll4[3];
                ThePrice.text = PricesAll4[3] + " Coins!";
            }
        }
        if (Pos > 135 && Pos <= 180)
        {
            if (PricesAll4[4] == 3333) { ManagerObject.Spins += 2; ThePrice.text = "2 Free Spins!"; }
            else
            if (PricesAll4[4] == 1111) { ManagerObject.Spins += 1; ThePrice.text = "1 Free Spins!"; }
            else
            {
                ManagerObject.Cash += PricesAll4[4];
                ThePrice.text = PricesAll4[4] + " Coins!";
            }
        }
        if (Pos > 180 && Pos <= 225)
        {
            if (PricesAll4[5] == 3333) { ManagerObject.Spins += 2; ThePrice.text = "2 Free Spins!"; }
            else
            if (PricesAll4[5] == 1111) { ManagerObject.Spins += 1; ThePrice.text = "1 Free Spins!"; }
            else
            {
                ManagerObject.Cash += PricesAll4[5];
                ThePrice.text = PricesAll4[5] + " Coins!";
            }
        }
        if (Pos > 225 && Pos <= 270)
        {
            if (PricesAll4[6] == 3333) { ManagerObject.Spins += 2; ThePrice.text = "2 Free Spins!"; }
            else
            if (PricesAll4[6] == 1111) { ManagerObject.Spins += 1; ThePrice.text = "1 Free Spins!"; }
            else
            {
                ManagerObject.Cash += PricesAll4[6];
                ThePrice.text = PricesAll4[6] + " Coins!";
            }
        }
        if (Pos > 270 && Pos <= 315)
        {
            if (PricesAll4[7] == 3333) { ManagerObject.Spins += 2; ThePrice.text = "2 Free Spins!"; }
            else
            if (PricesAll4[7] == 1111) { ManagerObject.Spins += 1; ThePrice.text = "1 Free Spins!"; }
            else
            {
                ManagerObject.Cash += PricesAll4[7];
                ThePrice.text = PricesAll4[7] + " Coins!";
            }
        }


        if (Pos > 315 && Pos <= 360)
        {
            if (PricesAll4[0] == 3333) { ManagerObject.Spins += 2; ThePrice.text = "2 Free Spins!"; }
            else
            if (PricesAll4[0] == 1111) { ManagerObject.Spins += 1; ThePrice.text = "1 Free Spins!"; }
            else
            {
                ManagerObject.Cash += PricesAll4[0];
                ThePrice.text =  PricesAll4[0] + " Coins!";
            }
        }
        Money.UpdateMoney();
        Spins.UpdateSpins();

        Instantiate(Particle, transform.position, Quaternion.identity);
        Instantiate(Sound, transform.position, Quaternion.identity);
        ManagerObject.Save();
    }


    public void New4Rewards()
    {
        RewardsText[0].text = Rewards[0];
        for(int i = 1; i < 8; i++)
        {
            int Randomizer = Random.Range(1, Rewards.Length);
            RewardsText[i].text = Rewards[Randomizer];
            PricesAll4[i] = Prices[Randomizer];
            if (Randomizer < 8)
            {
                RewardsImage[i].GetComponent<Image>().sprite = AllSymbols[0];
           
            }
            else
            {
              
                RewardsImage[i].GetComponent<Image>().sprite = AllSymbols[1];   // אם זה 0-7 אז זה זהב אם לא אז כנראה שזה עוד ספינים
            }
        }
    }
    public void AddSpins()
    {
        ManagerObject.ShowAd30sec();
        Spins.UpdateSpins();
    }
    public void AddSpinsDev() //Delete after
    {
        ManagerObject.Spins += 10;
        Spins.UpdateSpins();
    }
    public void DisableText()
    {
        NoSpins.gameObject.SetActive(false);
    }
}
