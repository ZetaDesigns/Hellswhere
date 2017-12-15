using UnityEngine;
using UnityEngine.UI;
public class MoneyUI : MonoBehaviour {

    public Text moneyText;
    public Text wavesText;

	// Update is called once per frame
	void Update () {
        moneyText.text = "$" + StatsManager.Money.ToString();
        wavesText.text = "Waves Survived: " + StatsManager.Waves.ToString();
    }
}
