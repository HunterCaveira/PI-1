using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.UI;

public class MENU : MonoBehaviour
{
    [SerializeField] private GameObject menuPrincipal;
    [SerializeField] private GameObject menuConfigs;
    [SerializeField] private GameObject menuCreditos;
    [SerializeField] private Slider sliderVolume;
    [SerializeField] private Scrollbar scrollbarFonte;
    [SerializeField] private TMP_Text textNome;


    public void LoadGameScene()
    {

        SceneManager.LoadScene(1);

    }

    public void CONFIG()
    {
        menuPrincipal.SetActive(false);
        menuConfigs.SetActive(true);


    }

    public void Voltar()
    {
        if (menuConfigs == true)
        {
            menuConfigs.SetActive(false);
            menuPrincipal.SetActive(true);
        }
        if (menuCreditos == true)
        {
            menuPrincipal.SetActive(true);
            menuCreditos.SetActive(false);
        }


    }

    public void OnVolumeChange()
    {
        Debug.Log(sliderVolume.value);
    
    }

    public void TamanhoFonte()
    {

        Debug.Log(scrollbarFonte.value);
    }
    

     
    public void Creditos()
    {

        menuPrincipal.SetActive(false);
        menuCreditos.SetActive(true);


    
    }

    public void Sair()
    {
        menuPrincipal.SetActive(false);
    
    
    }  

    public void SetPlayername(TMP_InputField input)
    {
        textNome.text = input.text;
    }



  
}
