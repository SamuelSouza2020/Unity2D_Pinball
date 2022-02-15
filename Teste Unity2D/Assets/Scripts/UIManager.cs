using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    /// <summary>
    /// Nesse script esta o maior controle do UI no jogo.
    /// Do simples tutorial do menu inicial at� a
    /// exibi��o da pontua��o atual do player.
    /// </summary>
    public Text txtPontos, txtUser, lastScore;
    GameManager gameM;
    public GameObject cvMenu, listScore;
    Button btPlay, btWorld, btCloseL;
    InputField inputName;
    [SerializeField]
    SalvarScore salvaPontos;

    void Awake()
    {
        //Quando o jogo � iniciado o tempo � congelado (Time.timeScale)
        Time.timeScale = 0;
        txtPontos = GameObject.Find("txtPontos").GetComponent<Text>();
        gameM = GameObject.Find("Gerenc").GetComponent<GameManager>();
        cvMenu = GameObject.Find("CanvasMenu");
        btPlay = GameObject.Find("btPlay").GetComponent<Button>();
        btWorld = GameObject.Find("BtWorld").GetComponent<Button>();
        btCloseL = GameObject.Find("BtClose").GetComponent<Button>();
        inputName = GameObject.Find("InputName").GetComponent<InputField>();
        txtUser = GameObject.Find("txtUser").GetComponent<Text>();
        lastScore = GameObject.Find("lastScore").GetComponent<Text>();
        salvaPontos = GameObject.Find("ScorePlayer").GetComponent<SalvarScore>();
        listScore = GameObject.Find("ListScore");
        listScore.SetActive(false);
        //Fun��o que adiciona comando ao bot�o "Ao clicar"
        //Chamando o void Mencionado nos parenteses.
        btPlay.onClick.AddListener(IniciarGame);
        btWorld.onClick.AddListener(ListaOp);
        btCloseL.onClick.AddListener(ListaCl);
    }
    void Update()
    {
        //Aqui atualiza em todo o tempo a pontua��o do jogador
        txtPontos.text = gameM.pontosPlayer.ToString();
        if(cvMenu.activeSelf)
        {
            lastScore.text = gameM.lastPontos.ToString();
        }
    }
    void SalvaRapido()
    {
        salvaPontos.saveScore();
    }
    void IniciarGame()
    {
        /*
         * Assim que o jogador inicia a partida o tempo volta 
         * ao normal e o menu � desativado.
         */
        /*if (txtUser.text == "")
        {
            //Mensagem de erro, mas por enquanto deixa esse codigo
            txtAviso.text = "Escreva seu usu�rio";
            txtAviso.color = Color.red;
            //pfm.SaveAppearance();
        } 

        else
        {
            //salvaPontos.VerificarUser();
            //StartCoroutine(salvaPontos.getPlayerisExist(txtUser.text));
            //pfm.RegisterButton();
            cvMenu.SetActive(false);
            gameM.gameIniciou = true;
            Time.timeScale = 1;
        }*/

        cvMenu.SetActive(false);
        gameM.gameIniciou = true;
        Time.timeScale = 1;
    }
    void ListaOp()
    {
        listScore.SetActive(true);
    }
    void ListaCl()
    {
        listScore.SetActive(false);
    }
}
