Trnth Hierarchy Visual Script
=============================

Whats's Trnth Hierarchy Visual Script(THVS) ?
-------

THVS is a visual-script library for unity3d . It can help you make game-logic , level design , fx , etc without coding . This toolkit is under developement now.

THVS 是個 coding hater 福音，主要是用來幫助我與我的 coding hater 小夥伴們使用 unity 而不用撰寫任何一行程式碼。

Features 
--------

- fully surrport version control ( like git , mercury )
- using native unity ui , no extra ui needs to learn 
- work with native unity Hierarchy view
- source code included
- no variable . please using script instead .

- 完全支援版本控管軟體，與隔壁棚的 playmaker 比起來是大勝利
- 因為很懶惰完全沒有任何特製 ui 與額外得 editor 視窗，適合懶得學習新 ui 的使用者
- 配合內建的 Hierarchy view 即可運作
- 內建原始碼

Core Concept 
------------

There are two major structures in THVS : `Condition` , `Action` . `Condition`s listen to the unity messages , then send to `Action`s to do something . you can pair conditions and actions to achieve many effect . like 

	Condition : Awake
	Action : Activae a gameObject  

or 

	Condition : OnEnable
	Action : Deactviate a gameObject


架構
--------

- Conditon : 進入點 , 為了效能問題，不建議使用 update 
- Action : 執行內容
- Fx : 每幀 update 效果

說明
-----

請只使用在遊戲邏輯、不要使用在需要每幀運算的部分。

衝殺