using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{
	public DataScript data;
	// Start is called before the first frame update
	void Start()
    {
		var toggle = GameObject.Find("1Toggle").GetComponent<Toggle>();
		toggle.isOn = data.OptAudioEnRu;
		toggle.onValueChanged.AddListener(b => data.OptAudioEnRu = b);
		var dropdown = GameObject.Find("2Dropdown").GetComponent<Dropdown>();
		dropdown.value = data.OptTopicName;
		dropdown.onValueChanged.AddListener(v => data.OptTopicName = v);

		data.GetWords(0);
		var text3 = GameObject.Find("3Text").GetComponent<Text>();
		var slider = GameObject.Find("3Slider").GetComponent<Slider>();
		slider.onValueChanged.AddListener(v =>
		{
			data.OptVolume = (int)v;
			text3.text = $" ”ровень громкости ({(int)v}):";
		});
		slider.value = data.OptVolume;
		GameObject.Find("3Button").GetComponent<Button>()
		.onClick.AddListener(() => data.PlayAudio(0));

		var text4 = GameObject.Find("4Text").GetComponent<Text>();
		var button4 = GameObject.Find("4Button").GetComponent<Button>();
		var button4Text = GameObject.Find("4Button").GetComponentInChildren<Text>();
		slider = GameObject.Find("4Slider1").GetComponent<Slider>();
		slider.onValueChanged.AddListener(v =>
		{
			data.OptMainButtonFontSize = (int)v;
			button4Text.fontSize = (int)v;
			text4.text = Opt4Comment();
		});
		slider.value = data.OptMainButtonFontSize;
		slider = GameObject.Find("4Slider2").GetComponent<Slider>();
		slider.onValueChanged.AddListener(v =>
		{
			data.OptMainButtonHeight = (int)v;
			data.SetHeight(button4, (int)v);
			text4.text = Opt4Comment();
		});
		slider.value = data.OptMainButtonHeight;
	}
	string Opt4Comment() =>
	$" Ўрифт ({data.OptMainButtonFontSize}) и высота "
	+ $"({data.OptMainButtonHeight})\n кнопок в списках:";
	// Update is called once per frame
	void Update()
    {
        
    }
}
