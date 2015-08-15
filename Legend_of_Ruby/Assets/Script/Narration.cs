using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Narration : MonoBehaviour {

    private float _time;
    private Text _script;
    private List<string> _collections = new List<string>();
    private int line_num;
    private int curr_line_num = 0;
    // Use this for initialization
	void Start () {
        _script = this.GetComponent<Text>();
        _collections.Add("내 이름은 루비. 이 가게의 주인이다.");
        _collections.Add("그 전까지는 모자랄 것 없는 삶을 살고 있었지만, 남편이 죽은 후 내게 남은건 이 잡화상점 뿐이다.");
        _collections.Add("마지막 희망인 내 가게가 번창하기 위해 하루도 쉬지않고 노오오오오력하고 있다.");
        _collections.Add("루비 : 어서오세요~");
        _collections.Add("가게에 들어온 아주머니는 과일을 집고 계산대로 온 후, 나에게 말을 걸기 시작했다.");
        _collections.Add("아주머니 : 어머, 주인장. 지금 같은 상황에 이렇게 항아리들을 진열하면 안돼.");
        _collections.Add("루비 : 네? 무슨 소리세요?");
        _collections.Add("아주머니 : 그 소문 못들었어? 벌건 대낮부터 갑자기 집안으로 쳐들어와서 항아리를 다 깨부수고 다닌다는 ");
        _collections.Add("초록색 옷을 입은 괴한 이야기. 이름이... 젤다였나?");
        _collections.Add("루비 : 에이, 그런 사람이 세상에 어디있어요.");
        _collections.Add("아주머니 : 어제도 저쪽 마을 주택에 있는 항아리가 몽땅 박살이 났다니깐? 조심하는게 좋을거야.");
        _collections.Add("아주머니는 의미심장한 정보를 주고 가게를 나갔다.");
        _collections.Add("몇 시간 후... ");
        _collections.Add("한산한 가게에 손님이 한명 들어왔다.");
        _collections.Add("루비 : 어서오세... 음?");
        _collections.Add("손님은 지나치게 초록색인 복장을 하고서, 가게에 있는 항아리들을 둘러보았다.");
        _collections.Add("루비 : '저.. 손님.. 설마?'");
        _collections.Add("손님은 히죽 웃더니, 주변 시선은 상관도 하지 않은채, 항아리를 향해서 칼을 빼들었다.");
        _collections.Add("루비 : 거...거기!! 잠깐!!");

        line_num = _collections.Count;
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Display();
        }
        _time += Time.deltaTime;
        //Display(_time.ToString());
	}

      void Display()
    {
        if (curr_line_num < line_num)
        {
            _script.text = _collections[curr_line_num];
            curr_line_num++;
        }
        else
        {
            _script.text = "Finish Script";
        }
    }
}
