using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    int aktifSahneIndex;
    int yüklenecekSahneIndex;

    void Awake()
    {
        aktifSahneIndex = SceneManager.GetActiveScene().buildIndex;

        //oyun yeni açıldıysa
        if (aktifSahneIndex == 0)
        {
            int gelinenLevel = PlayerPrefs.GetInt("GelinenLevel", 1);
            SceneManager.LoadScene(gelinenLevel);
        }
    }

    public void LoadNextLevel()
    {
        GelinenLeveliArttır();
        SceneManager.LoadScene(yüklenecekSahneIndex);
    }

    void GelinenLeveliArttır()
    {
        int gelinenLevel = PlayerPrefs.GetInt("GelinenLevel", 1);

        //son levelde oyunun tekrar etmesini sağlar
        if (SonLevelMi())
            yüklenecekSahneIndex = gelinenLevel;
        else
            yüklenecekSahneIndex = gelinenLevel + 1;

        PlayerPrefs.SetInt("GelinenLevel", yüklenecekSahneIndex);
    }

    bool SonLevelMi()
    {
        int toplamLevelSayısı = SceneManager.sceneCount - 1;

        if (aktifSahneIndex < toplamLevelSayısı)
            return false;
        else
            return true;
    }
}
