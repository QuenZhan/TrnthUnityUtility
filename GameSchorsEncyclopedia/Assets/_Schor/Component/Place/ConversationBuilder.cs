using TRNTH.SchorsInventory.DeadDatabase;
namespace TRNTH.SchorsInventory
{
    public class ConversationBuilder
    {
        DeadDatabase.Character Dad;
		DeadDatabase.Character Teacher;
		DeadDatabase.Character Sjia;
		DeadDatabase.Character RudeClassMate;
		DeadDatabase.Character PoliteClassMate;
		void CreateOrFindConversation(string title,int primaryKey){

		}
		
		public void FirstLesson(){
			CreateOrFindConversation("第一堂課",1);
			d(Teacher,Emotion.Smile,"各位好，最近過的還好嗎？");
            d(PoliteClassMate,Emotion.Smile,"老師好！");
            d(RudeClassMate,Emotion.Lazy,"…額，普通…");
            d(Sjia,Emotion.NervousSmile,"…");
            d(Teacher,Emotion.Smile,"如各位所見，今天有一位新人，歡迎思嘉加入我們。");
            d(Sjia,Emotion.Nervous,"啊！謝謝老師…兩位好");
            d(PoliteClassMate,Emotion.Smile,"你好！");
            d(RudeClassMate,Emotion.Lazy,"…");
            d(RudeClassMate,Emotion.Lazy,"…唷");
            d(Sjia,Emotion.NervousSmile,"…");
            d(Teacher,Emotion.Smile,"好的，那麼繼續上次的進度，思嘉因為是中途加入，若有不明白的部分要儘快提出的");
            d(Sjia,Emotion.Nervous,"…好…好的！");
            d(Teacher,Emotion.Doubt,"上次是到哪邊…？喔…接下來是ㄛㄜㄡ的部分…");
			d(Sjia,Emotion.Scared,"…（什麼！注音？是教這麼簡單的東西嗎？）");
			d(Sjia,Emotion.Doubt,"（難道我對學校有什麼錯誤的認知嗎…？）");
            d(Sjia,Emotion.Boring,"（…");
			d(Sjia,Emotion.Boring,"（天啊，無聊死了…）");
			d(Sjia,Emotion.LookAside,"（其他人也這麼覺得吧？）");
			d(RudeClassMate,Emotion.Doubt,"…（看起來很困惑苦惱的樣子）");
			d(Sjia,Emotion.Weird,"（…額？）");
			d(PoliteClassMate,Emotion.Serious,"…（念念有詞，認真的抄寫）");
			d(Sjia,Emotion.Weird,"…");
			d(Sjia,Emotion.Doubt,"（只有我覺得這很簡單嗎？）");
			d(Sjia,Emotion.Lazy,"（…天啊，什麼狀況）");
			BlackIn();
			d("（思嘉度過坐立難安的兩小時。）");
			BlackOut();
			d(Teacher,Emotion.None,"好了，今天就到這邊為止，下次上課的時候，記得繳交寫字本。");
			d(PoliteClassMate,Emotion.Nervous,"…老…老師，等一下，可以在講一次剛剛那個部分嗎？");
			d(Teacher,Emotion.Patient,"好的…這邊就是這樣…再這樣…");
			d(RudeClassMate,Emotion.Lazy,"…老師，我上次的作業可以嗎？");
			d(Teacher,Emotion.Patient,"喔對，說到那個，很可惜，你還是要再交一份");
			d(RudeClassMate,Emotion.Painfull,"喔不！我寫了三天啊！");
			d(Sjia,Emotion.BitterSmile,"…");
			d(Teacher,Emotion.Noticed,"");
			d(Teacher,Emotion.Smile,"思嘉…今天的內容還跟的上嗎？");
			d(Sjia,Emotion.Nervous,"啊，恩，還行的…");
			d(Teacher,Emotion.Smile,"如果不懂要講出來的喔，因為害羞而不敢說那可是很大的損失的");
			d(Sjia,Emotion.Nervous,"沒有的事…這些我都會的");
            d(RudeClassMate,Emotion.Lazy,"…");
			d(RudeClassMate,Emotion.Lazy,"…唉唷，才來第一天的傢伙，話可不能亂說啊，到時候被拆穿可是更丟臉的喔…我跟你講。");
			d(Sjia,Emotion.Nervous,"…我沒有亂說！我真的都會的！");
            d(Teacher,Emotion.Serious,"…");
            d(RudeClassMate,Emotion.Contempt,"…你都會？噗，我看不行吧。");
            d(Sjia,Emotion.Angry,"當然的！這麼簡單的東西！");
			d(RudeClassMate,Emotion.Contempt,"…簡單…哈哈，齁，那你說，這個是什麼？");
		}
        public void FirstTrailPass(){
            CreateOrFindConversation("第一次的勝利",2);
            d(RudeClassMate,Emotion.Pride,"嘖…");
		}
		public void FirstTrailFail(){
            CreateOrFindConversation("第一次的失敗",3);
            d(Sjia,Emotion.Humiliated,"…");
			d(RudeClassMate,Emotion.Pride,"嘿，有人糗了，是不是啊。");
		}
        public void AfterFirstBattle(){
            CreateOrFindConversation("第一次的戰鬥",4);
			d(Teacher,Emotion.Serious,"好了！你們兩個，馬上停止。");
            d(Teacher,Emotion.Serious,"今天就到此結束，你們先回去了；{0}你留下，我有話得跟你溝通。",RudeClassMate.Name);
            d(RudeClassMate,Emotion.Lazy,"喔…不…");
            d(Teacher,Emotion.Serious,"解散了，回去小心。");
            BlackIn();
            BlackOut();
            d(Sjia,Emotion.Heavy,"…呼…");
            d(PoliteClassMate,Emotion.Carefull,"那個…思嘉…小姐對吧");
            d(Sjia,Emotion.Scared,"啊！不好意思…對！抱歉！啊不對…婀。");
            d(PoliteClassMate,Emotion.Carefull,"唉嘿嘿，不用道歉啦。那個…{0}他講話總是比較直的，希望你不要介意",RudeClassMate.Name);
            d(Sjia,Emotion.Scared,"我…沒錯！…不對，其實…恩");
            d(PoliteClassMate,Emotion.Speachless,"…");
            d(Sjia,Emotion.Scared,"…對不起我不知道我在說什麼。");
            d(PoliteClassMate,Emotion.Speachless,"…雖然講話直也不能當作原諒的藉口啦，他也常常惹我生氣的。");
            d(Sjia,Emotion.Umm,"…是…是嗎？");
            d(PoliteClassMate,Emotion.Speachless,"但還是希望思嘉小姐能原諒他的，他最近的狀況不太好…");
            d(PoliteClassMate,Emotion.Speachless,"…");
            d(PoliteClassMate,Emotion.Smile,"…可以嗎？");
            d(Sjia,Emotion.Scared,"恩…好…好的。");
            d(Sjia,Emotion.Umm,"那個，不用加小姐的…叫我");
            interrupt(PoliteClassMate,Emotion.Smile,"那就這樣囉！下次見！");
            d(Sjia,Emotion.BitterSmile,"…好…下次見…");
            d(Sjia,Emotion.BitterSmile,"…（我好像還不知道他的名字的）");
        }
        public void FirstSchoolDayMirror(){
            CreateOrFindConversation("第一天入學的感想",5);
			d(Sjia,Emotion.Lazy,"（今天第一次上課，總覺得不是好的開始啊。）");
            d(Sjia,Emotion.Annoying,"（那個人到底怎麼回事啊，有什麼毛病！）");
            d(Sjia,Emotion.Irritable,"（超生氣！這該死的…）");
            d(Sjia,Emotion.Irritable,"（我連他的名字都不知道！生氣！）");
            d(Sjia,Emotion.Doubt,"（而且上課內容竟然是這樣的…感覺很不對啊…）");
            d(Sjia,Emotion.Doubt,"（去學校真的是正確的選擇嗎？）");
            d(Sjia,Emotion.Lazy,"（…想太多也想不透，再看看吧…）");
            d(Sjia,Emotion.Doubt,"（…下一堂課…是什麼來著。");
        }
        public void ReadHomeTheLetterForParent(){
            CreateOrFindConversation("朗讀信件",8);
			d(Dad,Emotion.Thinking,"妹妹，來一下。");
            d(Sjia,Emotion.Doubt,"什麼事，拔？");
            d(Dad,Emotion.Thinking,"…又有公所來的信了，你幫我念一下。");
            d(Sjia,Emotion.ActingCute,"…可是我的墨水好像用完了的，什麼都寫不出來的");
            d(Dad,Emotion.Speachless,"…");
            d(Dad,Emotion.Speachless,"…下次我進城的時候再買吧，先幫我念下");
            d(Sjia,Emotion.Happy,"耶！");
        }
        public void ReadHomeTheLetterForParentAfter(){
            CreateOrFindConversation("朗讀信件後",9);
			d(Dad,Emotion.Thinking,"恩…要我去公所幹嘛來著…好啦，妹妹謝謝。");
            d(Sjia,Emotion.NervousSmile,"好喔。（雖然我看得懂每一個字，可是不懂上面在講什麼呢）");
        }
        public void LanguageLesson2(){
            CreateOrFindConversation("第二堂語言課",6);
			d(Teacher,Emotion.Smile,"各位好，最近過的還好嗎？");
            d(PoliteClassMate,Emotion.Smile,"老師好！");
            d(Sjia,Emotion.Doubt,"（那個討厭的人…今天不在呢…）");
            d(Sjia,Emotion.Doubt,"（…）");
            d(Sjia,Emotion.YesYesYes,"好！");
            d(Sjia,Emotion.Embarrassed,"（啊…不小心說出來了）");
            d(Teacher,Emotion.Smile,"思嘉很有精神呢。那麼，繼續上次的內容…");
            d(Sjia,Emotion.Boring,"（喔…天啊，雖然有好的開始，但這個內容要持續多久啊…）");
            d(Sjia,Emotion.Boring,"（…）");
            d(Sjia,Emotion.Boring,"（額…意識模糊了…）");
            BlackIn();
            BlackOut();
            d(Teacher,Emotion.Smile,"…思嘉…思嘉，結束了喔。");
            d(Sjia,Emotion.AwakeScared,"…蛤！");
            d(PoliteClassMate,Emotion.Chuckle,"…嘻嘻");
            d(Sjia,Emotion.Embarrassed,"…！");
            d(Sjia,Emotion.Embarrassed,"不好意思！我…");
            d(Teacher,Emotion.Smile,"…");
            d(Teacher,Emotion.Smile,"今天就解散了吧；{0}等等，我得跟你溝通一下",Sjia.Name);
            d(PoliteClassMate,Emotion.Chuckle,"…嘻嘻");
            d(Sjia,Emotion.NervousSmile,"…");
            d(Sjia,Emotion.NervousSmile,"(哀，怎麼辦…糗了…)");
            BlackIn();
            BlackOut();
            d(Teacher,Emotion.Serious,"…");
            d(Sjia,Emotion.Regretful,"(要被罵了…嗚…)");
            d(Teacher,Emotion.Serious,"{0}，老師先跟妳說不好意思，這裡只是鄉下的小學校。");
            d(Sjia,Emotion.Regretful,"…是…對不起…");
            d(Sjia,Emotion.Scared,"唉？");
            d(Sjia,Emotion.Scared,"唉唉唉？");
            d(Teacher,Emotion.Serious,"老師猜測你是覺得目前的教學進度對你來說太簡單了？");
            d(Sjia,Emotion.Scared,"啊…沒有的事…");
            d(Teacher,Emotion.Serious,"真的？");
            d(Sjia,Emotion.Embarrassed,"…不對，的確是的，這兩次上課的內容我已經都會的。");
            d(Teacher,Emotion.Serious,"誠實是好事，不用擔心傷害到老師。");
            d(Sjia,Emotion.Embarrassed,"是…");
            d(Teacher,Emotion.Serious,"老師好奇了，你之前怎麼學會的呢？又是在哪裡學的？你的資料並沒有其他就學紀錄的。");
            d(Sjia,Emotion.Nervous,"這個…");
            d(Sjia,Emotion.Embarrassed,"家裡有書，我沒有事就每天看書…");
            d(Teacher,Emotion.Surprised,"喔？你家長會教你識字嗎？");
            d(Sjia,Emotion.Doubt,"…沒有唉，他們看不懂字。");
            d(Sjia,Emotion.Doubt,"家裡有信件，還是我得讀給他們聽。");
            d(Teacher,Emotion.Surprised,"…這真的很奇怪，不尋常啊。");
            d(Sjia,Emotion.Embarrassed,"…老師，我說的是真的，爸爸媽媽可以作證…");
            d(Teacher,Emotion.Thinking,"不不不，老師不是懷疑你…");
            d(Teacher,Emotion.Thinking,"…");
            d(Sjia,Emotion.Embarrassed,"…");
            d(Teacher,Emotion.Thinking,"…你對其他兩位同學…");
            d(Sjia,Emotion.Embarrassed,"唉？");
            d(Teacher,Emotion.Thinking,"雖然只有兩天…你對其他兩位同學看法怎麼樣，他們的學習進度？");
            d(Sjia,Emotion.Doubt,"…恩…他們學習得很辛苦的樣子？");
            d(Teacher,Emotion.Thinking,"…恩…");
            d(Teacher,Emotion.Thinking,"這樣好了，老師有個提議，既然目前的進度{0}已經會的話，這邊是語言課的結業測驗。",Sjia.Name);
            d(Teacher,Emotion.Thinking,"如果你可以全部做完，老師就讓你直接跳過目前的進度，你覺得如何？");
            d(Sjia,Emotion.Surprised,"啊？真的可以嗎？");
            d(Teacher,Emotion.Smile,"前提是要全部答對的喔。");
            d(Sjia,Emotion.Excited,"好！我會努力的！");
            // 新增一個契約
            BlackIn();
            BlackOut();
            d(Teacher,Emotion.Thinking,"（…這小鬼能做完嗎？有點難呢。）");
            d(PoliteClassMate,Emotion.None,"老師，你找我嗎？");
            d(Teacher,Emotion.Thinking,"啊，你來了。幫老師把這個信件寄出去吧");
            d(PoliteClassMate,Emotion.Reading,"好的，到公所的信？");
            d(Teacher,Emotion.Thinking,"上面有寫的，別多問，出去吧。");
            d(PoliteClassMate,Emotion.None,"好的。");
            BlackIn();
            BlackOut();
            d(Teacher,Emotion.Thinking,"（…這麼作好嗎？…但我需要證據…）");
        }
        public void MirrorDay2(){
            CreateOrFindConversation("第二堂語言課的感想",7);
			d(Sjia,Emotion.Excited,"（哇，今天有意外的展開呢）");
            d(Sjia,Emotion.Excited,"（雙重好事！機掰人不在，老師還給我特別進度！）");
            d(Sjia,Emotion.Doubt,"（但是那個機掰人…？為什麼不在呢）");
            d(Sjia,Emotion.Contempt,"（算了，機掰人怎麼樣也不關我的事，我也不想知道）");
            d(Sjia,Emotion.Doubt,"（…我還是不知道他的名字）");
            d(Sjia,Emotion.Contempt,"（沒關係，他就叫機掰人了！哼！）");
        }
        public void LanguageLesson3(){
            CreateOrFindConversation("第三堂語言課",10);
			d(Teacher,Emotion.Smile,"各位好，最近過的還好嗎？");
            d(PoliteClassMate,Emotion.Smile,"老師好！");
            d(Sjia,Emotion.Smile,"老師好！最近很好！");
            d(RudeClassMate,Emotion.Lazy,"…唷");
            d(Sjia,Emotion.Contempt,"（哎呀，這個機掰人這次出現了）");
            d(Sjia,Emotion.Contempt,"（哼！一大早就讓我心情差！）");
            d(Teacher,Emotion.Smile,"各位看起來不錯喔，那麼，接著上次的進度…");
            d(RudeClassMate,Emotion.Serious,"老師！等一下！");
            d(Sjia,Emotion.Scared,"（伊！嚇我一跳）");
            d(RudeClassMate,Emotion.Serious,"上次的版本！還行嗎？");
            d(Teacher,Emotion.Smile,"有很大的進步的喔！");
            d(RudeClassMate,Emotion.Excited,"真的嗎！好！");
            d(Teacher,Emotion.Smile,"…但，很遺憾，還是沒通過呢…");
            d(RudeClassMate,Emotion.Painfull,"不，會，吧…");
            d(RudeClassMate,Emotion.Irritable,"不～～～～～～");
            d(Teacher,Emotion.Smile,"好吧，老師會再幫你加強的，先安靜下，往後面的進度前進吧。");
            d(RudeClassMate,Emotion.Lazy,"…我永遠也過不了的");
            d(PoliteClassMate,Emotion.Chuckle,"…嘻嘻");
            d(RudeClassMate,Emotion.Annoying,"…笑勒，你最好了，每天只要待在老");
            interrupt(PoliteClassMate,Emotion.Smile,"老婆家，好玩嗎？");
            d(RudeClassMate,Emotion.Serious,"…");
            d(PoliteClassMate,Emotion.Smile,"♪～");
            d(Sjia,Emotion.NervousSmile,"（…好奇怪的氣氛。）");
            d(Sjia,Emotion.NervousSmile,"（…而且他們在講什麼，我一句都聽不懂）");
            d(Teacher,Emotion.Speachless,"好了，別聊天了，讓我們開始吧");
        }
        public void MirrorDay3(){
            CreateOrFindConversation("第三堂語言課的感想",11);
            d(Sjia,Emotion.Doubt,"（今天的氣氛好怪的…他們在講什麼啊？）");
            d(Sjia,Emotion.Doubt,"（而且還是不知道兩個同學的名字？）");
            d(Sjia,Emotion.Doubt,"（機掰人就叫他機掰人了，他今天依然很機掰？）");
            d(Sjia,Emotion.Doubt,"（但是另一個女生呢？她雖然很有禮貌的，但總覺得…）");
            d(Sjia,Emotion.Thinking,"（…學習以外的事情，困難的多呢，不理解啊。）");
        }
		void BlackIn(){}
		void BlackOut(){}
		public Conversation Conversation;
		void d(DeadDatabase.Character character,DeadDatabase.Emotion emotion,string content){
			Conversation.Dialogues.Add(new DeadDatabase.Dialogue(content,character,emotion));
		}
        void interrupt(DeadDatabase.Character character,DeadDatabase.Emotion emotion,string content){
			Conversation.Dialogues.Add(new DeadDatabase.Dialogue(content,character,emotion));
		}
        void d(DeadDatabase.Character character,DeadDatabase.Emotion emotion,string content,string arg1){
            d(character,emotion,string.Format(content,arg1));
		}
		void d(string content){
		}
	}

}