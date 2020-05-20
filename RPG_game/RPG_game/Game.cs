using System;
using System.IO;

namespace RPG_game
{
	public class Game
	{
		//Переменные
		//(line означает - какая строка сохранения хранит её значение)

		string Path = "save.txt";//Сохранение в текущей папке

		int WalkLong = 0;//Насколько далеко Иван зашёл в лес?

		float ChargePower = 1;//Множитель заряда, здесь он, чтобы не становился опять 1 при перезагрузке метода Fight

		bool ForestDemon = false;//Дерётся ли Иван с Лесным Демоном?

		int StageBoss = 1;//Фаза Лесного Демона

		bool ItemCheck = true;//Костыль собственного производства, нужен для перемещения в магазин для того чтобы баффы предметов дались Ивану

		//Активирована ли соответствующая стадия у Лесного Демона?
		bool FirstStage = false;
		bool TwoStage = false;
		bool ThreeStage = false;

		//Рандом чисел для конфуза значения переменных жизней
		Random Confuse = new Random ();
		int ConfuseHP;

		//Статистика Ивана
		float Health = 100;//Жизни line0
		int MaxHealth = 100;

		int Defence = 0;//Броня line1
		int NumberDefence = 0;//Номер брони Line2

		float Damage = 10;//Урон line3
		int NumberDamage = 0;//Номер оружия line4

		int Money = 0;//Монеты line5

		//Зелье
		int PotionCount = 0;//Количество зелий line6
		int FinalPotionCost;

		//Ожерелья
		int NumberNecklet = 0;//Номер ожерелья line7

		//Характеристики врагов
		string EnemyName;

		float EnemyHP;

		int EnemyDef;

		float EnemyDMG;

		int Loot;
		int LootX = 1;

		//Промах
		int MissNumber;

		//От и до слабо
		int FromWeak;
		int ToWeak;

		//От и до средне
		int FromNormal;
		int ToNormal;

		//ЛЕСНОЙ ДЕМОН, ЭТО ФИНАЛ!!!

		//Массивы
		int[] Price = new int[14] {20, 55, 25, 60, 125, 135, 30, 265, 515, 280, 505, 500, 505, 550};//Стоимость товара. 1-дубинка, 2-клинок, 3-нормальная одежда, 4-кожаная броня, 5-боевой топорик, 6-кольчужная броня, 7-зелье, 8-Меч и палка жизни, 9-Алесандрова секира, 10-железная броня, 11-латы, 12-ожерелья, 13-броня кары, 14-загадочный шар
		int[] PowerItem = new int[20] {3, 8, 3, 6, 14, 9, 50, 18, 25, 23, 28, 12, 15, 50, 0, 5, 3, 13, 40, 25};//Прибавление характеристик товара. 1-при дубинке, 2-при клинке, 3-при нормальной одежде, 4-при кожаной броне, 5-при боевом топорике, 6-при кольчужной броне, 7-эффект зелья, 8-сила удара палки жизни, 9-(+HP) от палки жизни, 10-при мече, 11-при Александровой секире, 12-при железной броне, 13-при латах, 14-при ожерелье жизни, 15-общая кара, 16-каждый ход +HP от ожерелья регенераций, 17-рандом доп. хода от ожерелья стремительности, 18-при броне кары, 19-кара от ожерелья кары, 20-кара от брони кары
		bool[] TakenItem = new bool[18] {false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false};//Куплен ли товар? 1-дубинка line 8, 2-клинок line 9, 3-нормальная одежда line 10, 4-кожаная броня line 11, 5-боевой топорик line 12, 6-кольчужная броня line 13, 7-Палка жизни line 14, 8-меч line 15, 9-Александрова секира line 16, 10-железная броня line 17, 11-латы line 18, 12-ожерелье жизни line 19, 13-ожерелье кары line 20, 14-ожерелье кары line 21, 15-ожерелье регенераций line 22, 16-ожерелье стремительности line 23, 17-броня кары line 24, 18-загадочный шар line 25
		string[] DefenceName = new string[7] {"Ивановское тряпьё", "Нормальная одежда", "Кожаная броня", "Кольчужная броня", "Железная броня", "Латы", "Броня кары"};//Названия брони
		string[] DamageName = new string[7] {"Ивановы руки", "Дубинка", "Клинок", "Боевой топорик", "Палка жизни", "Меч", "Александрова секира"};//Названия оружий
		string[] NeckletName = new string[5] {"Нет", "Ожерелье жизни", "Ожерелье кары", "Ожерелье регенераций", "Ожерелье стремительности"};//Названия ожерелий
		int[] PlusMaxHP = new int[2] {0, 0};//Прибавление макс. здоровья от посторонних предметов... 1-от палки жизни, 2-от ожерелья жизни
		int[] Kara = new int[2] {0, 0};//Проценты кары от удара противника... 1-от ожерелья кары, 2-от брони кары

		public void Legend() {

			Console.Clear ();

			//Текст
			Console.WriteLine ("Вы хотите прочитать предысторию?");
			Console.WriteLine ("");
			Console.WriteLine ("1) Да");
			Console.WriteLine ("2) Нет");

			//Выбор варианта
			string text = Console.ReadLine ();
			string x = Convert.ToString (text);

			if (x == "1") {
				Console.Clear ();
				Console.WriteLine ("Иван был обычным отшельником, жил в лесах и питался дарами природы.");

				Console.ReadKey ();
				Console.Clear ();
				Console.WriteLine ("Всё было хорошо, жизнь плыла плавно и текуче, казалось, что ничто не сможет заставить сменить его нынешний образ жизни.");

				Console.ReadKey ();
				Console.Clear ();
				Console.WriteLine ("Однако в скором времени появилось то, что заставило его это сделать.");

				Console.ReadKey ();
				Console.Clear ();
				Console.WriteLine ("Однажды, копаясь в своём книжном шкафу, он случайно нашёл какую - то пыльную книгу.");

				Console.ReadKey ();
				Console.Clear ();
				Console.WriteLine ("Сдув с неё всю пыль, он прочитал на обложке выгравированное название.");

				Console.ReadKey ();
				Console.Clear ();
				Console.WriteLine ("Она называлась «Легенда о Лесном Демоне»");

				Console.ReadKey ();
				Console.Clear ();
				Console.WriteLine ("Он начал её читать...");

				Console.ReadKey ();
				Console.Clear ();
				Console.WriteLine ("В ней он прочитал, что жил однажды на Руси один богатырь, звали его Петром Игнатьевичем.");

				Console.ReadKey ();
				Console.Clear ();
				Console.WriteLine ("Этот богатырь нашёл какой - то непонятный золотой шар, который легко помещался в его могучей руке, он находился где - то в лесах деревни Казитовой, которая славится своим тайнственным злом в лесах.");

				Console.ReadKey ();
				Console.Clear ();
				Console.WriteLine ("Спустя какое - то время он нашёл в этих лесах алтарь, в середине которого была выемка, она была ровно по форме этого непонятного шара.");

				Console.ReadKey ();
				Console.Clear ();
				Console.WriteLine ("Пётр посмотрел на шар, подумал:");

				Console.ReadKey ();
				Console.Clear ();
				Console.WriteLine ("Может, это какая - то божья благодать? И если совместить эти два непонятных предмета вместе, мы получим несметные богатства от самого всевышнего?");

				Console.ReadKey ();
				Console.Clear ();
				Console.WriteLine ("Он решился...");

				Console.ReadKey ();
				Console.Clear ();
				Console.WriteLine ("Вставил этот шар в выемку и стал ждать...");

				Console.ReadKey ();
				Console.Clear ();
				Console.WriteLine ("Ничего не происходило...");

				Console.ReadKey ();
				Console.Clear ();
				Console.WriteLine ("Вдруг алтарь начала окутывать какая - то тьма!");

				Console.ReadKey ();
				Console.Clear ();
				Console.WriteLine ("В этой тьме было практически ничего не видно, видно было только, как какое - то тёмное, испускающее дым существо, летает и как Пётр размахивает мечом, отбиваясь от него.");

				Console.ReadKey ();
				Console.Clear ();
				Console.WriteLine ("Прошло немного времени, как вдруг это существо иногда стало выпускать непроглядные клубы дыма прямо в лицо Петру Игнатьевичу, это дезориентировало его");

				Console.ReadKey ();
				Console.Clear ();
				Console.WriteLine ("После ещё небольшого количества времени, глаза этого существа стали как - то странно светиться, а Пётр сильно шатался.");

				Console.ReadKey ();
				Console.Clear ();
				Console.WriteLine ("Пётр, весь израненный, упал наземь...");

				Console.ReadKey ();
				Console.Clear ();
				Console.WriteLine ("После, тьма рассеялась");

				Console.ReadKey ();
				Console.Clear ();
				Console.WriteLine ("Однако ни существа, ни Петра, ни загадочного шара там не нашли...");

				Console.ReadKey ();
				Console.Clear ();
				Console.WriteLine ("Однажды, спустя долгие годы после данного происшествия, в деревню пришёл один нейзвестный странник.");

				Console.ReadKey ();
				Console.Clear ();
				Console.WriteLine ("Он сказал, что нашёл в их лесах тот самый непонятный шар и согласился его отдать за большую сумму денег.");

				Console.ReadKey ();
				Console.Clear ();
				Console.WriteLine ("Купец Степан Ефимович, отдав огромные деньги, смог получить этот шар, который находится у него и по сей день.");

				Console.ReadKey ();
				Console.Clear ();
				Console.WriteLine ("Больше никто не решил связываться с таким существом, которого прозвали в народе Лесным Демоном...");

				Console.ReadKey ();
				Console.Clear ();
				Console.WriteLine ("После прочтения этой легенды, Иван начал думать.");

				Console.ReadKey ();
				Console.Clear ();
				Console.WriteLine ("Каков смысл жить, если нет никакой цели? - думал он.");

				Console.ReadKey ();
				Console.Clear ();
				Console.WriteLine ("Твёрдо решив, что он собирается сделать, он собрал рюкзак с едой на месяц и отправился в деревню Казитову, чтобы наконец избавить её от такого зла, как Лесной Демон.");

				Console.ReadKey ();

				Menu ();
			} else if (x == "2") {
				Menu ();
			} 
			else {
				Legend ();
			}
		}

		void Menu() {

			Console.Clear ();

			//Текст
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine ("Лесной Демон");
			Console.ForegroundColor = ConsoleColor.Gray;
			Console.WriteLine ("");
			Console.WriteLine ("1) Начать игру");

			//Есть ли файл сохранения для продолжения
			if (System.IO.File.Exists (Path)) {
				//Если есть, то кнопка горит ярким цветом
				Console.ForegroundColor = ConsoleColor.Gray;
				Console.WriteLine ("2) Продолжить");
			} 
			else {
				//Если нет, то кнопка потухает
				Console.ForegroundColor = ConsoleColor.DarkGray;
				Console.WriteLine ("2) Продолжить");
			}

			Console.ForegroundColor = ConsoleColor.Gray;

			Console.WriteLine ("3) Выйти из игры");

			Console.WriteLine ("");
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.WriteLine ("Разработчик во Вконтакте - https://vk.com/id217001904");
			Console.ForegroundColor = ConsoleColor.Gray;//Выбор варианта не должен окрашиваться

			//Выбор варианта
			string text = Console.ReadLine ();
			string x = Convert.ToString (text);

			switch (x)
			{
			case "1":
				ReallyNewGame ();
				break;

			case "2":
				if (System.IO.File.Exists (Path)) {
					Load ();
				} 
				else {
					Console.Clear ();

					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine ("У вас нет файла сохранения, вы не можете продолжить игру");

					Console.ReadKey ();

					Menu ();//Возвращаем в меню
				}
				break;

			case "3":
				Environment.Exit (0);
				break;

			default:
				Console.Clear ();
				Menu ();
				break;
			}
		}

		void ReallyNewGame() {
			Console.Clear ();

			//Если на компютере есть сохранение
			if (System.IO.File.Exists (Path)) {
				Console.WriteLine ("Вы уверены, что хотите начать новую игру? Предыдущее сохранение будет удалено");
				Console.WriteLine ("");
				Console.WriteLine ("1) Да     2) Нет");

				//Выбор варианта
				string text = Console.ReadLine ();
				string x = Convert.ToString (text);

				switch (x) 
				{
				case "1":
					System.IO.File.Delete (Path);//Удаление файла сохранения
					GameMenu ();
					break;

				case "2":
					Menu ();
					break;

				default:
					ReallyNewGame ();
					break;
				}
			}
			//Если нет
			else {
				GameMenu ();
			}
		}

		void GameMenu() {

			Console.Clear ();

			//Текущее здоровье не может быть больше максимального
			if (Health > MaxHealth) {
				Health = MaxHealth;
			}

			WalkLong = 0;//Всё, Иван ушёл из леса

			//Значения переменных при выбранной экипировке
			//Оружия
			if (NumberDamage == 0) {
				Damage = 10;
			}

			//Броня
			if (NumberDefence == 0) {
				Defence = 0;
			}

			//Текст
			Console.ForegroundColor = ConsoleColor.Gray;

			Console.WriteLine("Чем желаете сейчас заняться в этой деревне?");
			Console.WriteLine("");
			Console.WriteLine("1) Погулять по лесу");
			Console.WriteLine("2) Зайти в лавку Степана");
			Console.WriteLine ("3) Посмотреть статистику Ивана");
			Console.WriteLine ("4) Сходить к лекарю Панкрату");
			Console.WriteLine ("5) Сохранить игру");
			Console.WriteLine ("6) Выйти из игры");

			//Выбор варианта
			string text = Console.ReadLine ();
			string x = Convert.ToString (text);

			switch (x)
			{
			case "1":
				RndEnemy ();
				break;

			case "2":
				Shop ();
				break;
			
			case "3":
				Statistika ();
				break;

			case "4":
				Doctor ();
				break;

			case "5":
				Save ();
				break;

			case "6":
				Environment.Exit (0);
				break;
			default:
				Console.Clear ();
				GameMenu ();
				break;
			}
		}

		void Statistika() {
			Console.Clear ();

			//Текст
			Console.ForegroundColor = ConsoleColor.DarkGreen;
			Console.WriteLine ("Максимальное здоровье: " + MaxHealth);

			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine ("Текущее здоровье: " + Health.ToString("0"));

			Console.ForegroundColor = ConsoleColor.Gray;
			Console.WriteLine ("Защита: " + Defence + " (" + DefenceName[NumberDefence] + ")");

			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine ("Урон: " + Damage + " (" + DamageName[NumberDamage] + ")");

			Console.ForegroundColor = ConsoleColor.DarkMagenta;
			Console.WriteLine ("Ожерелье: " + NeckletName[NumberNecklet]);

			Console.ForegroundColor = ConsoleColor.DarkCyan;
			Console.WriteLine ("Кара: " + PowerItem[14] + "%");

			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine ("Монеты: " + Money);

			Console.ForegroundColor = ConsoleColor.Magenta;
			Console.WriteLine ("Количество лечебных зелий: " + PotionCount);

			//Варианты выбора
			Console.ReadKey();
			GameMenu ();
		}

		void Save() {
			using (StreamWriter sw = new StreamWriter (Path, false, System.Text.Encoding.Default)) {
				//Сохранение количества чего - либо
				sw.WriteLine (Health = Convert.ToInt32(Health));
				sw.WriteLine (Defence);
				sw.WriteLine (NumberDefence);
				sw.WriteLine (Damage);
				sw.WriteLine (NumberDamage);
				sw.WriteLine (Money);
				sw.WriteLine (PotionCount);
				sw.WriteLine (NumberNecklet);

				//Сохранение, имеются ли текущие предметы?
				sw.WriteLine (TakenItem [0]);
				sw.WriteLine (TakenItem [1]);
				sw.WriteLine (TakenItem [2]);
				sw.WriteLine (TakenItem [3]);
				sw.WriteLine (TakenItem [4]);
				sw.WriteLine (TakenItem [5]);
				sw.WriteLine (TakenItem [6]);
				sw.WriteLine (TakenItem [7]);
				sw.WriteLine (TakenItem [8]);
				sw.WriteLine (TakenItem [9]);
				sw.WriteLine (TakenItem [10]);
				sw.WriteLine (TakenItem [11]);
				sw.WriteLine (TakenItem [12]);
				sw.WriteLine (TakenItem [13]);
				sw.WriteLine (TakenItem [14]);
				sw.WriteLine (TakenItem [15]);
				sw.WriteLine (TakenItem [16]);
				sw.WriteLine (TakenItem [17]);

				sw.Close ();//Закрываем поток, чтобы он не ускользнул из текстового файла
			}

				Console.Clear ();

				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine("Вы успешно сохранили игру!");

				Console.ReadKey ();

				GameMenu ();
		}

		void Load() {
			using (StreamReader sr = new StreamReader (Path, System.Text.Encoding.Default)) {
				string[] lines = File.ReadAllLines(Path);//Массив, для просмотра файла в поисках нужной строки

				Health = Convert.ToInt32 (lines [0]);
				Defence = Convert.ToInt32 (lines [1]);
				NumberDefence = Convert.ToInt32 (lines [2]);
				Damage = Convert.ToInt32 (lines [3]);
				NumberDamage = Convert.ToInt32 (lines [4]);
				Money = Convert.ToInt32 (lines [5]);
				PotionCount = Convert.ToInt32 (lines [6]);
				NumberNecklet = Convert.ToInt32 (lines [7]);

				TakenItem[0] = Convert.ToBoolean (lines [8]);
				TakenItem[1] = Convert.ToBoolean (lines [9]);
				TakenItem[2] = Convert.ToBoolean (lines [10]);
				TakenItem[3] = Convert.ToBoolean (lines [11]);
				TakenItem[4] = Convert.ToBoolean (lines [12]);
				TakenItem[5] = Convert.ToBoolean (lines [13]);
				TakenItem[6] = Convert.ToBoolean (lines [14]);
				TakenItem[7] = Convert.ToBoolean (lines [15]);
				TakenItem[8] = Convert.ToBoolean (lines [16]);
				TakenItem[9] = Convert.ToBoolean (lines [17]);
				TakenItem[10] = Convert.ToBoolean (lines [18]);
				TakenItem[11] = Convert.ToBoolean (lines [19]);
				TakenItem[12] = Convert.ToBoolean (lines [20]);
				TakenItem[13] = Convert.ToBoolean (lines [21]);
				TakenItem[14] = Convert.ToBoolean (lines [22]);
				TakenItem[15] = Convert.ToBoolean (lines [23]);
				TakenItem[16] = Convert.ToBoolean (lines [24]);
				TakenItem[17] = Convert.ToBoolean (lines [25]);

				sr.Close ();

				Shop ();//Костыль, смотри переменную ItemCheck
			}
		}

		void Doctor() {

			Console.Clear ();

			//Текст
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine ("Панкрат: Ну, выкладывай, что надо?");
			Console.WriteLine ("");

			Console.ForegroundColor = ConsoleColor.Gray;
			Console.WriteLine ("1) Вылечи меня (-10 монет)");
			Console.WriteLine ("2) Я хочу купить у тебя лечебных зелий");
			Console.WriteLine ("3) Выйти");

			//Выбор варианта
			string text = Console.ReadLine ();
			string x = Convert.ToString (text);

			switch (x)
			{
			case "1":
				Heal ();
				break;

			case "2":
				BuyPotion ();
				break;

			case "3":
				GameMenu ();
				break;

			default:
				Doctor ();
				break;
			}
		}

		void Heal() {

			Console.Clear ();

			//Деньги есть и здоровье НЕполное
			if (Health < MaxHealth && Money >= 10) {
				Health = MaxHealth;
				Money -= 10;

				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine ("Панкрат: Бегают тут по лесам, а потом приходят сюда в ссадинах да царапинах. Надоели уже! Ладно, вот, теперь ты абсолютно здоров");
				Console.WriteLine ("");

				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine ("Ваше здоровье полностью восстановлено!");

				Console.ReadKey ();
				Doctor ();
			} 
			//Здоровье полное
			else if (Health == MaxHealth) {
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine ("Панкрат: Не лги, вижу я, здоров ты. Уходи, не трать моё время!");

				Console.ReadKey ();
				Doctor ();
			}
			//Если нет денег
			else {
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine ("Панкрат: Ты читать умеешь? Написано - же на табличке: Стоимость лечения - 10 монет. Без денег не лечу, убирайся!");

				Console.ReadKey ();
				Doctor ();
			}
		}

		void BuyPotion() {

			Console.Clear ();

			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine ("Панкрат: Зелья, ты хоть знаешь как мало они стоят и как сложно мне их делать?! Ладно... но только учти, я буду повышать цену на них, чтобы ты не тратил их легкомысленно");

			Console.ForegroundColor = ConsoleColor.Gray;

			//Виды состоянии у варианта зелья
			if (PotionCount == 0) {
				FinalPotionCost = Price [6];
				Console.WriteLine ("1) Купить лечебное зелье (-" + Price [6] + " монет)");
			} 
			else if (PotionCount == 5) {
				Console.WriteLine ("1) Купить лечебное зелье");
			} 
			else {
				FinalPotionCost = Price [6] * (PotionCount + 1);
				Console.WriteLine ("1) Купить лечебное зелье (-" + FinalPotionCost + " монет)");
			}

			Console.ForegroundColor = ConsoleColor.Gray;

			Console.WriteLine ("2) Отмена");


			//Варианты выбора
			string text = Console.ReadLine ();
			string x = Convert.ToString (text);

			Console.Clear();

			switch (x)
			{
			case "1":
				if (PotionCount == 5) {
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine ("Панкрат: Зелья кончились!");

					Console.ReadKey ();

					Doctor ();
				} else if (PotionCount != 5 && Money < FinalPotionCost) {
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine ("Панкрат: У тебя нет нужной суммы денег, зелье я тебе не продам!");

					Console.ReadKey ();

					Doctor ();
				} 
				else if(PotionCount != 5 && Money >= FinalPotionCost) {
					//Убавление денег от покупки зелий
					Money -= FinalPotionCost;

					PotionCount++;

					Console.ForegroundColor = ConsoleColor.Yellow;
					Console.WriteLine ("Вы купили лечебное зелье");

					Console.ReadKey ();

					BuyPotion ();
				}
				break;
			
			case "2":
				Doctor ();
				break;

			default:
				BuyPotion ();
				break;
			}
		}

		void RndEnemy() {
			Console.Clear ();

			WalkLong++;//Иван продвигается по лесу

			Random VragRnd = new Random ();
			int Vrag = VragRnd.Next (1, 4);

			//Кто напал?

			if (WalkLong < 4) {
				switch (Vrag) {
				case 1:
					EnemyName = "Лесной слизень";
					EnemyHP = 35;
					EnemyDef = 0;
					EnemyDMG = 10;
					Loot = 10;

					MissNumber = 2;
					FromWeak = 2;
					ToWeak = 3;
					FromNormal = 3;
					ToNormal = 6;

					Console.WriteLine ("В лесу из - за кустов выпрыгнул на Ивана лесной слизень");
					Console.WriteLine ("");
					break;

				case 2:
					EnemyName = "Неопытный разбойник";
					EnemyHP = 40;
					EnemyDef = 1;
					EnemyDMG = 15;
					Loot = 15;

					MissNumber = 3;
					FromWeak = 3;
					ToWeak = 4;
					FromNormal = 4;
					ToNormal = 6;

					Console.WriteLine ("В лесу Иван услышал какой - то шорох сбоку, повернувшись туда, он увидел неумело крадущегося разбойника в рванной одежде, в руках у него была палка. Поняв, что его заметили, он, размахивая палкой и что - то крича, бросился на Ивана");
					Console.WriteLine ("");
					break;

				case 3:
					EnemyName = "Птица - хищник";
					EnemyHP = 20;
					EnemyDef = 0;
					EnemyDMG = 20;
					Loot = 5;

					MissNumber = 1;
					FromWeak = 1;
					ToWeak = 3;
					FromNormal = 3;
					ToNormal = 6;

					Console.WriteLine ("В лесу, из своего дупла, растрепав свой чёрные перья, вылетела на Ивана птица - хищник");
					Console.WriteLine ("");
					break;
				}
			} else if (WalkLong > 3 && WalkLong < 7) {
				switch (Vrag) {
				case 1:
					EnemyName = "Волк";
					EnemyHP = 65;
					EnemyDef = 4;
					EnemyDMG = 20;
					Loot = 30;

					MissNumber = 2;
					FromWeak = 2;
					ToWeak = 4;
					FromNormal = 4;
					ToNormal = 6;

					Console.WriteLine ("В тёмном лесу Иван послышал рычание сзади, обернувшись, он увидел волка, который всё приближался и приближался к нему");
					Console.WriteLine ("");
					break;

				case 2:
					EnemyName = "Разбойник - одиночка";
					EnemyHP = 50;
					EnemyDef = 3;
					EnemyDMG = 25;
					Loot = 30;

					MissNumber = 2;
					FromWeak = 2;
					ToWeak = 3;
					FromNormal = 3;
					ToNormal = 6;

					Console.WriteLine ("В тёмном лесу Иван увидел меж деревьев разбойника, который выглядывал из - за них. Поняв, что его заметили, он вышел из - за деревьев и потребовал у Ивана всё, что у него есть. Иван отказался это делать и разбойник, достав нож, побежал на Ивана");
					Console.WriteLine ("");
					break;

				case 3:
					EnemyName = "Большой паук";
					EnemyHP = 45;
					EnemyDef = 2;
					EnemyDMG = 20;
					Loot = 25;

					MissNumber = 0;
					FromWeak = 0;
					ToWeak = 4;
					FromNormal = 4;
					ToNormal = 6;

					Console.WriteLine ("В тёмном лесу было слышно, как кто - то ползал по земле, Иван начал внимательно осматриваться вокруг в поисках источника шума. Источником оказался большой длиннолапый паук, он уверенно и быстро надвигался на Ивана");
					Console.WriteLine ("");
					break;
				}
			} else if (WalkLong > 6 && WalkLong < 10) {
				switch (Vrag) {
				case 1:
					EnemyName = "Болотный слизень";
					EnemyHP = 90;
					EnemyDef = 6;
					EnemyDMG = 20;
					Loot = 70;

					MissNumber = 5;
					FromWeak = 5;
					ToWeak = 5;
					FromNormal = 5;
					ToNormal = 5;

					Console.WriteLine ("В болоте Иван услышал взади какое - то громкое хлюпанье, оглянувшись, он увидел огромного болотного слизня, большими прыжками приближающийся к нему");
					Console.WriteLine ("");
					break;

				case 2:
					EnemyName = "Болотная тварь";
					EnemyHP = 75;
					EnemyDef = 4;
					EnemyDMG = 20;
					Loot = 60;

					MissNumber = 2;
					FromWeak = 2;
					ToWeak = 4;
					FromNormal = 4;
					ToNormal = 6;

					Console.WriteLine ("В болоте из трясины начало вылезать человекоподобное существо, с ног до головы обмотанное всевозможными болотными растениями. Оно, что - то хрипя и рыча, начало надвигаться на Ивана");
					Console.WriteLine ("");
					break;

				case 3:
					EnemyName = "Подводный чёрт";
					EnemyHP = 75;
					EnemyDef = 0;
					EnemyDMG = 25;
					Loot = 60;

					MissNumber = 1;
					FromWeak = 1;
					ToWeak = 3;
					FromNormal = 3;
					ToNormal = 5;

					Console.WriteLine ("В болоте, пока Иван проходил озеро, перепрыгивая с кочки на кочку, из воды показались длинные тонкие руки подводного чёрта. Ивану будет трудно сражаться с ним, находясь в середине озера");
					Console.WriteLine ("");
					break;
				}
			} else if (WalkLong > 9 && WalkLong < 13) {
				switch (Vrag) {
				case 1:
					EnemyName = "Разбойник";
					EnemyHP = 100;
					EnemyDef = 5;
					EnemyDMG = 25;
					Loot = 110;

					MissNumber = 2;
					FromWeak = 2;
					ToWeak = 4;
					FromNormal = 4;
					ToNormal = 6;

					Console.WriteLine ("Увидя вдалеке какую - то палатку, Иван заметил боковым зрением разбойника. Он рыскал между деревьев, и увидев Ивана криво улыбнулся, и начал доставать из кармана острый нож");
					Console.WriteLine ("");
					break;

				case 2:
					EnemyName = "Полный разбойник";
					EnemyHP = 130;
					EnemyDef = 8;
					EnemyDMG = 30;
					Loot = 125;

					MissNumber = 4;
					FromWeak = 4;
					ToWeak = 4;
					FromNormal = 4;
					ToNormal = 6;

					Console.WriteLine ("Иван проходил мимо какой - то палатки. Вдруг он услышал взади себя тяжёлые шаги, обернувшись, он увидел неуклюже идущего полного разбойника. На нём было нацеплено куча видов всевозможной брони, а в руках его была тяжёлая дубина, он начал замахиваться");
					Console.WriteLine ("");
					break;

				case 3:
					EnemyName = "Профессиональный разбойник";
					EnemyHP = 110;
					EnemyDef = 6;
					EnemyDMG = 25;
					Loot = 145;

					MissNumber = 1;
					FromWeak = 1;
					ToWeak = 3;
					FromNormal = 3;
					ToNormal = 6;

					Console.WriteLine ("Подойдя к палатке, Иван увидел там кромешную тьму. Он начал было уходить отсюда, но взади к нему всё это время подкрадывался разбойник, у него было два ножа, а в лице его было сосредоточенность. Он понял, что его заметили и не медля ни секунды бросился на Ивана");
					Console.WriteLine ("");
					break;
				}
			} 
			else {
				Altar ();
			}
			Fight ();
		}

		void FightDemonStart() {
			//Характеристики
			EnemyName = "Лесной Демон";
			EnemyHP = 300;
			EnemyDef = 30;
			EnemyDMG = 20;
			Loot = 0;//Всё равно после него игра заканчивается

			MissNumber = 1;
			FromWeak = 1;
			ToWeak = 3;
			FromNormal = 3;
			ToNormal = 6;

			//Описание появления
			Console.Clear ();
			Console.WriteLine ("Иван глубоко вобрал в себя воздух и вставил шар в выемку...");
			Console.ReadKey ();

			Console.Clear ();
			Console.WriteLine ("Сначала ничего не происходило.");
			Console.ReadKey ();

			Console.Clear ();
			Console.WriteLine ("Но потом из выемки начал распростряняться дым,");
			Console.ReadKey ();

			Console.Clear ();
			Console.WriteLine ("Иван не мог ничего в нём разглядеть!");
			Console.ReadKey ();

			Console.Clear ();
			Console.WriteLine ("Но потом глаза привыкли ко тьме.");
			Console.ReadKey ();

			Console.Clear ();
			Console.WriteLine ("Он увидел, как из выемки начал собираться более тёмный, более мрачный дым");
			Console.ReadKey ();

			Console.Clear ();
			Console.WriteLine ("А в этом дыму был виден череп какого - то невиданного зверя");
			Console.ReadKey ();

			Console.Clear ();
			Console.WriteLine ("После нескольких секунд он ожил и полетел на Ивана, неся за собой дымчатый хвост");
			Console.ReadKey ();

			Console.Clear ();
			Console.WriteLine ("Иван уклонился от его атаки.");
			Console.ReadKey ();

			Console.Clear ();
			Console.WriteLine ("После, он встал, крепко сжал в руках своё оружие и приготовился к битве с Лесным Демоном...");
			Console.ReadKey ();

			//Начальный текст
			Console.Clear ();
			Console.WriteLine ("Лесной Демон готов расправиться над новой жертвой");
			Console.WriteLine ("");

			Fight ();
		}

		void Altar() {
			Console.Clear ();

			Console.WriteLine ("Пройдя огромнейший путь, Иван наконец - то добрался до этого алтаря. Он был уже очень стар и пылен. В его середине, как и ожидалось была выемка. Готов ли Иван призвать Лесного Демона?");
			Console.WriteLine ("");
			Console.WriteLine ("1) Да, готов");
			Console.WriteLine ("2) Нет, уйти обратно в деревню");

			//Выбор варианта
			string text = Console.ReadLine ();
			string x = Convert.ToString (text);

			//Да
			if (x == "1") {
				//Если есть загадочный шар
				if (TakenItem [17] == true) {
					Console.Clear ();

					ForestDemon = true;
					FightDemonStart ();
				} 
				//Если НЕТ загадочного шара
				else {
					Console.Clear ();

					Console.WriteLine ("Но у него не было загадочного золотого шара, поэтому ему ничего не оставалось, кроме как уйти обратно в деревню...");

					Console.ReadKey ();

					GameMenu ();
				}
			} 
			//Нет
			else if (x == "2") {
				GameMenu ();
			} 
			//Неправильно введено
			else {
				Altar ();
			}
		}

		void Fight() {
			float Damaged = 0;//Множитель, который выбирается рандомом и умножается на атаку
			float EnemyDamaged;//Damaged врага

			if (ChargePower == 4.5f) {
				Console.ForegroundColor = ConsoleColor.Gray;
				Console.WriteLine("Иван зарядил удар как только мог, сильнее уже нельзя, настало время ударить врага!");
			}

			//Проверка на переход фазы
			if (ForestDemon == true) {
				if (EnemyHP <= 200 && EnemyHP > 100 && TwoStage == false) {
					TwoStage = true;
					StageBoss = 2;
					Console.ForegroundColor = ConsoleColor.Gray;
					Console.WriteLine ("Во рту Лесного Демона начал образовываться сплошной тёмный дым");
				} 
				else if (EnemyHP <= 100 && ThreeStage == false) {
					ThreeStage = true;
					StageBoss = 3;
					Console.ForegroundColor = ConsoleColor.Gray;
					Console.WriteLine ("Глаза врага начали как - то странно светиться. Ивану стало нехорошо от взгляда этих глаз, он стал хуже понимать происходящее");
				} 
				else if (FirstStage == false) {
					FirstStage = true;
					StageBoss = 1;
					//А тут просто начальная фраза боя, она находится в методе FightDemonStart
				}
				//В ином случае просто ничего не делаем
			}

			//Проверка на непривышение текущ. здоровья над макс. здоровьем
			if (MaxHealth < Health) {
				Health = MaxHealth;
			}

			//Показатель здоровья врага
			Console.ForegroundColor = ConsoleColor.Red;
			//Если битва с обычным врагом или с Лесным Демоном НЕ 3 фазы
			if (ForestDemon == false || StageBoss != 3) {
				//Показатель здоровья врага
				Console.ForegroundColor = ConsoleColor.Red;
				Console.Write (EnemyName + " " + EnemyHP.ToString ("0") + " HP ");

				//Разделитель показателей
				Console.ForegroundColor = ConsoleColor.Gray;
				Console.Write ("|");

				//Показатель здоровья Ивана
				Console.ForegroundColor = ConsoleColor.Green;
				Console.Write (" Иван " + Health.ToString ("0") + " HP");
			} 
			//Если битва с Лесным Демоном c 3 фазой
			else if (ForestDemon == true && StageBoss == 3) {
				//Присваивания конфуз чисел

				//Показатель здоровья врага
				Console.ForegroundColor = ConsoleColor.Red;
				ConfuseHP = Confuse.Next (-999, 999);//Рандом конфуза здоровья
				Console.Write (EnemyName + " " + ConfuseHP.ToString ("0") + " HP ");

				//Разделитель показателей
				Console.ForegroundColor = ConsoleColor.Gray;
				Console.Write ("|");

				//Показатель здоровья Ивана
				Console.ForegroundColor = ConsoleColor.Green;
				ConfuseHP = Confuse.Next (-999, 999);//Рандом конфуза здоровья
				Console.Write (" Иван " + ConfuseHP + " HP");
			}

			//Да-да, двойной отступ
			Console.WriteLine("");
			Console.WriteLine("");

			//Действия
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("1) Ударить, сильно замахнувшись");

			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine ("2) Ударить, средне замахнувшись");

			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine ("3) Ударить, слабо замахнувшись");

			//Изменение цвета действия заряда в зависимости от его заряженности
			if (ChargePower == 1) {
				Console.ForegroundColor = ConsoleColor.Gray;
			} 
			else if (ChargePower == 2) {
				Console.ForegroundColor = ConsoleColor.Green;
			} 
			else if (ChargePower == 3) {
				Console.ForegroundColor = ConsoleColor.Yellow;
			} 
			//То - есть, если 4.5
			else {
				Console.ForegroundColor = ConsoleColor.Red;
			}

			Console.WriteLine ("");

			Console.WriteLine ("4) Зарядить удар");

			Console.ForegroundColor = ConsoleColor.Magenta;
			if (ForestDemon == false || StageBoss != 3) {
				Console.WriteLine ("5) Выпить лечебное зелье x" + PotionCount + " (+" + PowerItem [6] + " едениц здоровья)");
			} 
			else {
				ConfuseHP = Confuse.Next (-999, 999);

				Console.WriteLine ("5) Выпить лечебное зелье x" + PotionCount + " (+" + ConfuseHP + " едениц здоровья)");
			}

			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine ("6) Сбежать");

			Console.ForegroundColor = ConsoleColor.Gray;

			string text = Console.ReadLine ();
			string x = Convert.ToString (text);

			//Осуществление действия

			//Рандом выпуска дыма
			Random SmokeStopper = new Random ();
			int SmokeStop = 1;

			if (StageBoss >= 2) {
				SmokeStop = SmokeStopper.Next (1, 5);

				if (SmokeStop == 3) {
					Damaged = 0;
				}
			}

			//Попал ли Иван?
			Random Got = new Random ();
			int GotInt = Got.Next (1, 9);

			Console.Clear ();

			//Выбор варианта
			switch (x) 
			{
			//Сильный размах
			case "1":
				if (SmokeStop != 3) {//SmokeStop, это значит, что Иван ударяет, только если в него не выпустили дым
					if (GotInt <= 5) {
						Damaged = 0;
						Console.WriteLine ("Сильно размахнувшись, Иван ударил, но промахнулся по врагу");
					} else if (GotInt > 4) {
						Damaged = 2;
						Console.WriteLine ("Сильно размахнувшись, Иван ударил, попал удачно");
					}
				}
				break;
			//Средний размах
			case "2":
				if (SmokeStop != 3) {//SmokeStop, это значит, что Иван ударяет, только если в него не выпустили дым
					if (GotInt <= 2 && SmokeStop != 3) {//SmokeStop, это значит, что Иван ударяет, только если в него не выпустили дым
						Damaged = 0;
						Console.WriteLine ("Размахнувшись, Иван ударил, но по врагу так и не попал");
					} else if (GotInt > 2 && GotInt <= 3) {
						Damaged = 0.5f;
						Console.WriteLine ("Размахнувшись, Иван ударил, и еле задел врага");
					} else if (GotInt > 3 && GotInt <= 6) {
						Damaged = 1;
						Console.WriteLine ("Размахнувшись, Иван ударил врага");
					} else {
						Damaged = 1.5f;
						Console.WriteLine ("Размахнувшись, Иван ударил, попадание было точным");
					}
				}
				break;
			//Слабый размах
			case "3":
				if (SmokeStop != 3) {//SmokeStop, это значит, что Иван ударяет, только если в него не выпустили дым
					if (GotInt <= 1 && SmokeStop != 3) {//SmokeStop, это значит, что Иван ударяет, только если в него не выпустили дым
						Damaged = 0;
						Console.WriteLine ("Еле размахнувшись, Иван ударил, да и то не попал");
					} else if (GotInt > 1 && GotInt <= 4) {
						Damaged = 0.25f;
						Console.WriteLine ("Еле размахнувшись, Иван ударил и совсем немного задел врага");
					} else if (GotInt > 4 && GotInt <= 6) {
						Damaged = 0.75f;
						Console.WriteLine ("Еле размахнувшись, Иван ударил врага");
					} else {
						Damaged = 1.25f;
						Console.WriteLine ("Еле размахнувшись, Иван ударил врага, это был весьма сильный удар");
					}
				}
				break;

			//Зарядить удар
			case "4":
				if (ChargePower == 1) {
					Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine ("Иван начал заряжать удар");
					ChargePower = 2;
				} 
				else if (ChargePower == 2) {
					Console.ForegroundColor = ConsoleColor.Yellow;
					Console.WriteLine ("Иван заряжает удар");
					ChargePower = 3;
				} 
				else if (ChargePower == 3) {
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine ("Иван зарядил удар");
					ChargePower = 4.5f;
				} 
				else {
					Fight ();
				}
				break;

			//Выпить зелье
			case "5":
				//Использование зелья
				Console.ForegroundColor = ConsoleColor.Green;

				ChargePower = 1;//Зарядка сбилась

				ConfuseHP = Confuse.Next (-999, 999);

				if (ForestDemon == false || StageBoss != 3) {
					Console.WriteLine ("Ваше здоровье повысилось на " + PowerItem [6] + " едениц!");
				} else {
					Console.WriteLine ("Ваше здоровье повысилось на " + ConfuseHP + " едениц!");
				}

				Console.ForegroundColor = ConsoleColor.Gray;

				if (PotionCount > 0) {
					PotionCount--;
					Health += PowerItem [6];

					//Приравние текущего здоровья к максимальному
					if (Health > MaxHealth) {
						Health = MaxHealth;
					}
				} 
				//Зелий нет
				else {
					Console.Clear ();

					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine ("У вас нет лечебных зелий!");

					Console.ReadKey ();

					Console.Clear ();

					Fight ();
				}

				Console.ReadKey ();
				Console.Clear ();
				break;

			//Сбежать
			case "6":
				ChargePower = 1;//Зарядка сбилась

				if (ForestDemon == false) {
					Random RunFight = new Random ();
					int Run = RunFight.Next (1, 6);

					if (Run == 1) {
						Console.WriteLine ("Иван трусливо убежал с поля битвы...");
						Console.ReadKey ();
						GameMenu ();
					} else {
						Console.WriteLine ("Вам не удалось сбежать");
					}
				} 
				else {
					Console.WriteLine ("Иван резко побежал куда глаза глядят, но тьма не давала ему сделать это, она выталкивала его обратно на арену");
				}
				break;
			default:
				Console.Clear ();
				Fight ();
				break;
			}

			//Атака игрока
			float TotalDMG = (Damage * Damaged) * ChargePower;

			if (Damaged != 0 && TotalDMG > EnemyDef) {
				EnemyHP -= TotalDMG - EnemyDef;
			}
			else {
				EnemyHP -= 0;
			}
				
			if (Damaged != 0 && TotalDMG > EnemyDef) {
				
				Console.ForegroundColor = ConsoleColor.Red;

				if (ForestDemon == false || StageBoss != 3 && SmokeStop != 3) {
					Console.WriteLine (EnemyName + ": " + "-" + (TotalDMG - EnemyDef).ToString ("0") + " HP");
				} else {
					ConfuseHP = Confuse.Next (-999, 999);

					Console.WriteLine (EnemyName + ": " + "-" + ConfuseHP + " HP");
				}
				ChargePower = 1;//Рестарт заряда
			} 
			else if (Damaged != 0 && TotalDMG <= EnemyDef) {
				Console.ForegroundColor = ConsoleColor.Gray;
				Console.WriteLine ("Броня врага не пробита");
				ChargePower = 1;//Рестарт заряда
			} 
			else if (SmokeStop == 3 && x != "4" && x != "5" && x != "6") {//4, 5 и 6, это номера заряда, выпиения зелья и побега, тогда демон не выпускает дым
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine ("Лесной Демон выпустил прямо в лицо Ивану непроглядные клубы дыма и это его дезориентировало. Иван не смог попасть в него");
				ChargePower = 1;//Рестарт заряда
			}
			else if (Damaged == 0 && x != "4" && x != "5" && x != "6") {
				Console.ForegroundColor = ConsoleColor.Gray;
				Console.WriteLine ("Враг не получил урона");
				ChargePower = 1;//Рестарт заряда
			}
			else {
				Console.ForegroundColor = ConsoleColor.Gray;
				Console.WriteLine ("Враг не получил урона");
			}

			Console.ReadKey ();
			Console.Clear ();

			//Смерть врага
			if (EnemyHP <= 0 && ForestDemon == false) {
				ChargePower = 1;//Рестарт заряда, чтобы в следующем бою не сохранилось

				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine ("Враг повержен!");

				Random RndMoney = new Random ();
				int RndLoot = RndMoney.Next (-Loot / 2, Loot / 2);

				int FinalLoot = (Loot + RndLoot) * LootX;

				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine ("");
				Console.WriteLine ("Ваша награда: " + FinalLoot + " монет");
				Money += FinalLoot;

				Console.ReadKey ();
				Continue ();
			} 
			//Смерть демона
			else if (EnemyHP <= 0 && ForestDemon == true) {
				Console.ForegroundColor = ConsoleColor.Gray;

				Console.WriteLine ("После длительного сражения, оба соперника выбились из сил");
				Console.ReadKey ();

				Console.Clear ();
				Console.WriteLine ("Иван еле размахивал своим оружием, а Лесной Демон едва летал");
				Console.ReadKey ();

				Console.Clear ();
				Console.WriteLine ("Но тут Иван собрал последние свои силы и в удачный момент сделал резкий удар");
				Console.ReadKey ();

				Console.Clear ();
				Console.WriteLine ("Череп Лесного Демона разбился и из него начала испускаться чернота");
				Console.ReadKey ();

				Console.Clear ();
				Console.WriteLine ("Иван, закрытый этой чернотой упал наземь...");
				Console.ReadKey ();

				Console.Clear ();
				Console.WriteLine ("Много времени прошло, перед тем как его нашёл Степан Ефимович");
				Console.ReadKey ();

				Console.Clear ();
				Console.WriteLine ("Он, завидев неважно выглядещее тело Ивана, лежащее на алтаре, взял его да понёс обратно в деревню...");
				Console.ReadKey ();

				Console.Clear ();
				Console.WriteLine ("Сколько времени спал он, точно сказать уже нельзя, но очень и очень долго");
				Console.ReadKey ();

				Console.Clear ();
				Console.WriteLine ("Когда он проснулся, первым, что он разобрал, был купец Степан Ефимович, сидящий неподалёку");
				Console.ReadKey ();

				Console.Clear ();
				Console.ForegroundColor = ConsoleColor.DarkCyan;
				Console.WriteLine ("Степан: Ты проснулся?!");
				Console.ReadKey ();

				Console.Clear ();
				Console.ForegroundColor = ConsoleColor.Gray;
				Console.WriteLine ("Степан был очень удивлён такому резкому пробуждению");
				Console.ReadKey ();

				Console.Clear ();
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine ("Иван: Да...");
				Console.ReadKey ();

				Console.Clear ();
				Console.ForegroundColor = ConsoleColor.Gray;
				Console.WriteLine ("Иван был ещё очень слаб, и не мог говорить так громко, насколько - бы он этого хотел");
				Console.ReadKey ();

				Console.Clear ();
				Console.ForegroundColor = ConsoleColor.DarkCyan;
				Console.WriteLine ("Степан: Слава богу... понимаешь... ты ведь понимаешь, что ты сделал, не так - ли?");
				Console.ReadKey ();

				Console.Clear ();
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine ("Иван: Нет... не понимаю, что я такого сделал?");
				Console.ReadKey ();

				Console.Clear ();
				Console.ForegroundColor = ConsoleColor.DarkCyan;
				Console.WriteLine ("Степан: Ты даже этого не помнишь? Господи, как же он потрепал твой разум...");
				Console.ReadKey ();

				Console.Clear ();
				Console.ForegroundColor = ConsoleColor.DarkCyan;
				Console.WriteLine ("Степан: Ты убил Лесного Демона! Даже сам Пётр Игнатьевич был им повержен, но ты, каким - то образом, смог его победить, как?");
				Console.ReadKey ();

				Console.Clear ();
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine ("Иван: Чего - то припоминаю...");
				Console.ReadKey ();

				Console.Clear ();
				Console.ForegroundColor = ConsoleColor.DarkCyan;
				Console.WriteLine ("Степан: Уже хорошо");
				Console.ReadKey ();

				Console.Clear ();
				Console.ForegroundColor = ConsoleColor.DarkCyan;
				Console.WriteLine ("Степан: Знаешь, после того, как ты его победил, лес стал куда более добрее к жителям, и всё это благодаря тебе");
				Console.ReadKey ();

				Console.Clear ();
				Console.ForegroundColor = ConsoleColor.DarkCyan;
				Console.WriteLine ("Степан: Поэтому даже князь не поскупился и решил отдать тебе дом самого Петра Игнатьевича!");
				Console.ReadKey ();

				ViborEnd ();
			}

			//Возможность на доп. ход
			if (NumberNecklet == 4) {
				//Рандом, будет ли доп. ход?
				Random RndExtraHod = new Random ();
				int RndHod = RndExtraHod.Next (1, 6);

				//Если будет
				if (RndHod == 3) {
					Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine ("Вы можете сделать дополнительный ход!");

					Console.ReadKey ();
					Console.Clear ();

					Fight ();
				}
			}

			//Попал ли враг?
			Random GotEnemy = new Random();
			int GotIntEnemy = GotEnemy.Next (1, 9);

			//Результаты атаки врага
			Console.ForegroundColor = ConsoleColor.Gray;

			if (GotIntEnemy <= MissNumber) {
				Console.WriteLine ("Враг хотел ударить Ивана, но промахнулся");
				EnemyDamaged = 0;
			} 
			else if (GotIntEnemy > FromWeak && GotIntEnemy <= ToWeak) {
				Console.WriteLine ("Враг хотел ударить Ивана, но он отскочил и удар его еле задел");
				EnemyDamaged = 0.5f;
			} 
			else if (GotIntEnemy > FromNormal && GotIntEnemy <= ToNormal) {
				Console.WriteLine ("Враг ударил Ивана");
				EnemyDamaged = 1;
			}
			else {
				Console.WriteLine ("Враг разъярённо ударил Ивана, это был очень сильный удар");
				EnemyDamaged = 1.5f;
			}

			//Атака врага
			float TotalEnemyDMG = EnemyDMG * EnemyDamaged;

			if (EnemyDamaged != 0 && TotalEnemyDMG > Defence) {
				Health -= TotalEnemyDMG - Defence;
			}
			else {
				Health -= 0;
			}

			if (EnemyDamaged != 0 && TotalEnemyDMG > Defence) {
				Console.ForegroundColor = ConsoleColor.Green;

				ConfuseHP = Confuse.Next (-999, 999);

				if (ForestDemon == false || StageBoss != 3) {
					Console.WriteLine ("Иван" + ": " + "-" + (TotalEnemyDMG - Defence).ToString ("0") + " HP");
				} 
				else {
					Console.WriteLine ("Иван" + ": " + "-" + ConfuseHP + " HP");
				}

				//Высчитывание кары исходя из урона c защитой

				float TotalKara;//Итог наносимой кары

				if (PowerItem[14] > 0) {
					TotalKara = ((TotalEnemyDMG - Defence) / 100) * PowerItem[14];

					EnemyHP -= TotalKara;

					Console.ForegroundColor = ConsoleColor.Red;

					ConfuseHP = Confuse.Next (-999, 999);

					if (ForestDemon == false || StageBoss != 3) {
						Console.WriteLine ("К врагу пришла кара и нанесла " + TotalKara.ToString ("0") + " едениц урона");
					} 
					else {
						Console.WriteLine ("К врагу пришла кара и нанесла " + ConfuseHP + " едениц урона");
					}
				}
			} 
			else if (EnemyDamaged != 0 && TotalEnemyDMG <= Defence) {
				Console.ForegroundColor = ConsoleColor.Gray;
				Console.WriteLine ("Враг не смог пробить броню Ивана");
			}
			else {
				Console.ForegroundColor = ConsoleColor.Gray;
				Console.WriteLine ("Иван не получил урона");
			}

			Console.ReadKey ();
			Console.Clear ();

			//Смерть игрока
			if (Health <= 0) {
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine ("Иван, не выдержав нанесённых ударов, упал замертво.");
				Console.WriteLine ("Вы проиграли...");

				Console.ReadKey ();

				Environment.Exit (0);
			} 
			//Смерть врага
			else if (EnemyHP <= 0) {
				ChargePower = 1;//Рестарт заряда, чтобы в следующем бою не сохранилось

				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine ("Враг повержен!");

				Random RndMoney = new Random ();
				int RndLoot = RndMoney.Next (-Loot / 2, Loot / 2);

				int FinalLoot = Loot + RndLoot * LootX;

				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine ("");
				Console.WriteLine ("Ваша награда: " + FinalLoot + " монет");
				Money += FinalLoot;

				Console.ReadKey ();
				Continue ();
			}
			//Смерть демона
			else if (EnemyHP <= 0 && ForestDemon == true) {
				Console.ForegroundColor = ConsoleColor.Gray;

				Console.WriteLine ("После длительного сражения, оба соперника выбились из сил");
				Console.ReadKey ();

				Console.Clear ();
				Console.WriteLine ("Иван еле размахивал своим оружием, а Лесной Демон едва летал");
				Console.ReadKey ();

				Console.Clear ();
				Console.WriteLine ("Но тут Иван собрал последние свои силы и в удачный момент сделал резкий удар");
				Console.ReadKey ();

				Console.Clear ();
				Console.WriteLine ("Череп Лесного Демона разбился и из него начала испускаться чернота");
				Console.ReadKey ();

				Console.Clear ();
				Console.WriteLine ("Иван, закрытый этой чернотой упал наземь...");
				Console.ReadKey ();

				Console.Clear ();
				Console.WriteLine ("Много времени прошло, перед тем как его нашёл Степан Ефимович");
				Console.ReadKey ();

				Console.Clear ();
				Console.WriteLine ("Он, завидев неважно выглядещее тело Ивана, лежащее на алтаре, взял его да понёс обратно в деревню...");
				Console.ReadKey ();

				Console.Clear ();
				Console.WriteLine ("Сколько времени спал он, точно сказать уже нельзя, но очень и очень долго");
				Console.ReadKey ();

				Console.Clear ();
				Console.WriteLine ("Когда он проснулся, первым, что он разобрал, был купец Степан Ефимович, сидящий неподалёку");
				Console.ReadKey ();

				Console.Clear ();
				Console.ForegroundColor = ConsoleColor.DarkCyan;
				Console.WriteLine ("Степан: Ты проснулся?!");
				Console.ReadKey ();

				Console.Clear ();
				Console.ForegroundColor = ConsoleColor.Gray;
				Console.WriteLine ("Степан был очень удивлён такому резкому пробуждению");
				Console.ReadKey ();

				Console.Clear ();
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine ("Иван: Да...");
				Console.ReadKey ();

				Console.Clear ();
				Console.ForegroundColor = ConsoleColor.Gray;
				Console.WriteLine ("Иван был ещё очень слаб, и не мог говорить так громко, насколько - бы он этого хотел");
				Console.ReadKey ();

				Console.Clear ();
				Console.ForegroundColor = ConsoleColor.DarkCyan;
				Console.WriteLine ("Степан: Слава богу... понимаешь... ты ведь понимаешь, что ты сделал, не так - ли?");
				Console.ReadKey ();

				Console.Clear ();
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine ("Иван: Нет... не понимаю, что я такого сделал?");
				Console.ReadKey ();

				Console.Clear ();
				Console.ForegroundColor = ConsoleColor.DarkCyan;
				Console.WriteLine ("Степан: Ты даже этого не помнишь? Господи, как же он потрепал твой разум...");
				Console.ReadKey ();

				Console.Clear ();
				Console.ForegroundColor = ConsoleColor.DarkCyan;
				Console.WriteLine ("Степан: Ты убил Лесного Демона! Даже сам Пётр Игнатьевич был им повержен, но ты, каким - то образом, смог его победить, как?");
				Console.ReadKey ();

				Console.Clear ();
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine ("Иван: Чего - то припоминаю...");
				Console.ReadKey ();

				Console.Clear ();
				Console.ForegroundColor = ConsoleColor.DarkCyan;
				Console.WriteLine ("Степан: Уже хорошо");
				Console.ReadKey ();

				Console.Clear ();
				Console.ForegroundColor = ConsoleColor.DarkCyan;
				Console.WriteLine ("Степан: Знаешь, после того, как ты его победил, лес стал куда более добрее к жителям, и всё это благодаря тебе");
				Console.ReadKey ();

				Console.Clear ();
				Console.ForegroundColor = ConsoleColor.DarkCyan;
				Console.WriteLine ("Степан: Поэтому даже князь не поскупился и решил отдать тебе дом самого Петра Игнатьевича!");
				Console.ReadKey ();

				ViborEnd ();
			}
			else if (NumberNecklet == 3 && MaxHealth > Health){
				RegenerateHP ();
			}
			else {
				Fight ();
			}
		}

		//Выбор концовки
		void ViborEnd() {
			Console.Clear ();
			Console.ForegroundColor = ConsoleColor.DarkCyan;
			Console.WriteLine ("Степан: Ну что, готов - ли ты принять этот благородный дом?");

			Console.ForegroundColor = ConsoleColor.Gray;
			Console.WriteLine ("1) Да, я принимаю его   2) Нет, я хочу вернуться обратно в свою избушку");

			//Выбор варианта
			string text = Console.ReadLine ();
			string x = Convert.ToString (text);

			//Да
			if (x == "1") {
				Console.Clear ();
				Console.ForegroundColor = ConsoleColor.DarkCyan;
				Console.WriteLine ("Степан: Замечательно! Как только ты выздоровеешь, тебя можно выпустить из моего домика и указать дорогу к твоему дому. Который когда - то был домом Петра Игнатьевича...");
				Console.ReadKey ();

				Console.Clear ();
				Console.ForegroundColor = ConsoleColor.Gray;
				Console.WriteLine ("После выздоровления и перехода в этот дом, который оказался очень хорошим и красивым");
				Console.ReadKey ();

				Console.Clear ();
				Console.ForegroundColor = ConsoleColor.Gray;
				Console.WriteLine ("Иван зажил очень счастливо, у него было всё для хорошей жизни");
				Console.ReadKey ();

				Console.Clear ();
				Console.ForegroundColor = ConsoleColor.Gray;
				Console.WriteLine ("И после его смерти, жители этой когда - то опасной деревушки, начали передавать легенду из уст в уста другим поколениям");
				Console.ReadKey ();

				Console.Clear ();
				Console.ForegroundColor = ConsoleColor.Gray;
				Console.WriteLine ("Она рассказывала о некогда жившем в лесу отшельнике, который решил прийти в деревню и победить Лесного Демона, так сильно мешающего народу жить и процветать");
				Console.ReadKey ();

				Console.Clear ();
				Console.ForegroundColor = ConsoleColor.Gray;
				Console.WriteLine ("И не без труда, но смог добраться до него и победить в честном бою, после, остался жить в предоставленном ему доме Петра Игнатьевича");
				Console.ReadKey ();

				Console.Clear ();
				Console.ForegroundColor = ConsoleColor.Gray;
				Console.WriteLine ("Эта легенда доказывала, что даже самый обычный человек, даже отшельник может многое изменить, если очень постарается.");
				Console.ReadKey ();

				Console.Clear ();
				Console.ForegroundColor = ConsoleColor.Gray;
				Console.WriteLine ("-Спасибо за то, что поиграли!-");
				Console.ReadKey ();

				Environment.Exit (0);//Выход из игры
			} 
			//Нет
			else if (x == "2") {
				Console.Clear ();
				Console.ForegroundColor = ConsoleColor.DarkCyan;
				Console.WriteLine ("Степан: Правда, ты отказываешься от дома, который такой хороший, такой красивый?");
				Console.ReadKey ();

				Console.Clear ();
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine ("Иван: Я думаю... не, я хочу обратно домой, там я прожил основную часть своей жизни, так проживу - же там целую жизнь");
				Console.ReadKey ();

				Console.Clear ();
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine ("Иван: Ни на какой, ни царский, ни благородный, ни золотой дом не обменяю я свою родную дряхлую избушку...");
				Console.ReadKey ();

				Console.Clear ();
				Console.ForegroundColor = ConsoleColor.Gray;
				Console.WriteLine ("Так и порешили. Иван, когда полностью выздоровел, направился обратно в свой лес, в свои края");
				Console.ReadKey ();

				Console.Clear ();
				Console.ForegroundColor = ConsoleColor.Gray;
				Console.WriteLine ("Вернувшись в свою избушку, которая выглядела очень неухоженной, из - за того что он тут так долго не был, он почувствовал самую истинную радость");
				Console.ReadKey ();

				Console.Clear ();
				Console.ForegroundColor = ConsoleColor.Gray;
				Console.WriteLine ("Он прожил тут хорошую жизнь, зная, что что - то он в этой жизни всё - таки сделал");
				Console.ReadKey ();

				Console.Clear ();
				Console.ForegroundColor = ConsoleColor.Gray;
				Console.WriteLine ("И после его смерти, жители этой когда - то опасной деревушки, начали передавать легенду из уст в уста другим поколениям");
				Console.ReadKey ();

				Console.Clear ();
				Console.ForegroundColor = ConsoleColor.Gray;
				Console.WriteLine ("Она рассказывала о жившем в лесу отшельнике, который решил прийти в деревню и победить Лесного Демона, так сильно мешающего народу жить и процветать");
				Console.ReadKey ();

				Console.Clear ();
				Console.ForegroundColor = ConsoleColor.Gray;
				Console.WriteLine ("И не без труда, но смог добраться до него и победить в честном бою, после, отказался от дома благородного Петра Игнатьевича и вернулся к отшельнической жизни в своей избушке");
				Console.ReadKey ();

				Console.Clear ();
				Console.ForegroundColor = ConsoleColor.Gray;
				Console.WriteLine ("Эта легенда доказывала, что даже самый обычный человек, даже отшельник может многое изменить, если очень постарается.");
				Console.ReadKey ();

				Console.Clear ();
				Console.ForegroundColor = ConsoleColor.Gray;
				Console.WriteLine ("-Спасибо за то, что поиграли!-");
				Console.ReadKey ();

				Environment.Exit (0);//Выход из игры
			} 
			//Неправильно введено
			else {
				ViborEnd ();
			}
		}

		//Регенерация HP от ожерелья регенераций
		void RegenerateHP() {
				//Рандом восстановления HP
				Random RndRegenerate = new Random ();
				PowerItem[15] = RndRegenerate.Next (0, 6);

				//Если БОЛЬШЕ 0 восстановилось
			if (PowerItem [15] > 0) {
				Health += PowerItem [15];

				Console.ForegroundColor = ConsoleColor.Green;

				ConfuseHP = Confuse.Next (-999, 999);

				if (ForestDemon == false || StageBoss != 3) {
					Console.WriteLine ("Ожерелье регенераций восстановило вам " + PowerItem [15] + " едениц здоровья");
				} 
				else {
					Console.WriteLine ("Ожерелье регенераций восстановило вам " + ConfuseHP + " едениц здоровья");
				}
				Console.WriteLine ("");

				Fight ();
			}
			else {
				Fight ();//Если - же всё - же ноль
			}
		}

		//После победы над врагом
		void Continue() {
			Console.Clear ();

			//Текст
			Console.ForegroundColor = ConsoleColor.Gray;
			Console.WriteLine("Что собираетесь делать далее?");
			Console.WriteLine("");
			Console.WriteLine("1) Продолжить гулять");
			Console.WriteLine("2) Вернуться в деревню");

			//Выбор варианта
			string text = Console.ReadLine ();
			string x = Convert.ToString (text);

			switch (x) 
			{
			case "1":
				RndEnemy ();
				break;

			case "2":
				GameMenu ();
				break;
			
			default:
				Console.Clear ();
				Continue ();
				break;
			}
		}
			
		void Shop() {
			Console.Clear ();

			//Фраза Степана
			Console.ForegroundColor = ConsoleColor.DarkCyan;
			Console.WriteLine ("Степан: Что купить желаете?");

			//Что можно купить?
			Console.ForegroundColor = ConsoleColor.Gray;

			//Оружия
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine ("Оружия");

			//Дубинка
			if (TakenItem [0] == false) {
				Console.ForegroundColor = ConsoleColor.Gray;
				Console.WriteLine ("   1) " + DamageName[1] + " (+" + PowerItem [0] + " к урону) - " + Price [0] + " монет");
			} 
			else if (TakenItem [0] == true && NumberDamage == 1) {
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine ("   1) " + DamageName[1] + " (+" + PowerItem [0] + " к урону)");
				Damage = 10 + PowerItem[0];
			}
			else {
				Console.ForegroundColor = ConsoleColor.DarkYellow;
				Console.WriteLine ("   1) " + DamageName[1] + " (+" + PowerItem [0] + " к урону)");
			}

			//Клинок
			if (TakenItem [1] == false) {
				Console.ForegroundColor = ConsoleColor.Gray;
				Console.WriteLine ("   2) " + DamageName[2] + " (+" + PowerItem [1] + " к урону) - " + Price[1] + " монет");
			} 
			else if (TakenItem [1] == true && NumberDamage == 2) {
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine ("   2) " + DamageName[2] + " (+" + PowerItem [1] + " к урону)");
				Damage = 10 + PowerItem[1];
			}
			else {
				Console.ForegroundColor = ConsoleColor.DarkYellow;
				Console.WriteLine ("   2) " + DamageName [2] + " (+" + PowerItem [1] + " к урону)");
			}

			//Боевой топорик
			if (TakenItem [4] == false) {
				Console.ForegroundColor = ConsoleColor.Gray;
				Console.WriteLine ("   3) " + DamageName[3] + " (+" + PowerItem [4] + " к урону) - " + Price [4] + " монет");
			} 
			else if (TakenItem [4] == true && NumberDamage == 3) {
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine ("   3) " + DamageName[3] + " (+" + PowerItem [4] + " к урону)");
				Damage = 10 + PowerItem[4];
			}
			else {
				Console.ForegroundColor = ConsoleColor.DarkYellow;
				Console.WriteLine ("   3) " + DamageName[3] + " (+" + PowerItem [4] + " к урону)");
			}

			//Палка жизни
			if (TakenItem [6] == false) {
				Console.ForegroundColor = ConsoleColor.Gray;
				Console.WriteLine ("   4) " + DamageName [4] + " (+" + PowerItem [7] + " к урону и +" + PowerItem [8] + " к максимальному здоровью) - " + Price [7] + " монет");
			} 
			else if (TakenItem [6] == true && NumberDamage == 4) {
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine ("   4) " + DamageName [4] + " (+" + PowerItem [7] + " к урону и +" + PowerItem [8] + " к максимальному здоровью)");
				Damage = 10 + PowerItem[7];
				PlusMaxHP[0] = 25;
				MaxHealth = 100 + PlusMaxHP [0] + PlusMaxHP [1];
			}
			else {
				Console.ForegroundColor = ConsoleColor.DarkYellow;
								Console.WriteLine ("   4) " + DamageName [4] + " (+" + PowerItem [7] + " к урону и +" + PowerItem [8] + " к максимальному здоровью)");
				PlusMaxHP[0] = 0;
				MaxHealth = 100 + PlusMaxHP [0];
			}

			//Меч
			if (TakenItem [7] == false) {
				Console.ForegroundColor = ConsoleColor.Gray;
				Console.WriteLine ("   5) " + DamageName[5] + " (+" + PowerItem [9] + " к урону) - " + Price [7] + " монет");
			} 
			else if (TakenItem [7] == true && NumberDamage == 5) {
				Console.ForegroundColor = ConsoleColor.Yellow;
								Console.WriteLine ("   5) " + DamageName[5] + " (+" + PowerItem [9] + " к урону)");
				Damage = 10 + PowerItem[9];
			}
			else {
				Console.ForegroundColor = ConsoleColor.DarkYellow;
				Console.WriteLine ("   5) " + DamageName[5] + " (+" + PowerItem [9] + " к урону)");
			}

			//Александрова секира
			if (TakenItem [8] == false) {
				Console.ForegroundColor = ConsoleColor.Gray;
				Console.WriteLine ("   6) " + DamageName[6] + " (+" + PowerItem [10] + " к урону) - " + Price [8] + " монет");
			} 
			else if (TakenItem [8] == true && NumberDamage == 6) {
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine ("   6) " + DamageName[6] + " (+" + PowerItem [10] + " к урону)");
				Damage = 10 + PowerItem[10];
			}
			else {
				Console.ForegroundColor = ConsoleColor.DarkYellow;
				Console.WriteLine ("   6) " + DamageName[6] + " (+" + PowerItem [10] + " к урону)");
			}

			//Броня
			Console.WriteLine("");
			Console.ForegroundColor = ConsoleColor.Gray;
			Console.WriteLine ("Броня");

			//Нормальная одежда
			if (TakenItem [2] == false) {
				Console.ForegroundColor = ConsoleColor.Gray;
				Console.WriteLine ("   7) " + DefenceName[1] + " (+" + PowerItem [2] + " к защите) - " + Price [2] + " монет");
			} 
			else if (TakenItem [2] == true && NumberDefence == 1) {
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine ("   7) " + DefenceName[1] + " (+" + PowerItem [2] + " к защите)");
				Defence = 0 + PowerItem[2];
			}
			else {
				Console.ForegroundColor = ConsoleColor.DarkYellow;
				Console.WriteLine ("   7) " + DefenceName[1] + " (+" + PowerItem [2] + " к защите)");
			}

			//Кожаная броня
			if (TakenItem [3] == false) {
				Console.ForegroundColor = ConsoleColor.Gray;
				Console.WriteLine ("   8) " + DefenceName[2] + " (+" + PowerItem [3] + " к защите) - " + Price [3] + " монет");
			} 
			else if (TakenItem [3] == true && NumberDefence == 2) {
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine ("   8) " + DefenceName[2] + " (+" + PowerItem [3] + " к защите)");
				Defence = 0 + PowerItem[3];
			}
			else {
				Console.ForegroundColor = ConsoleColor.DarkYellow;
				Console.WriteLine ("   8) " + DefenceName[2] + " (+" + PowerItem [3] + " к защите)");
			}

			//Кольчужная броня
			if (TakenItem [5] == false) {
				Console.ForegroundColor = ConsoleColor.Gray;
				Console.WriteLine ("   9) " + DefenceName[3] + " (+" + PowerItem [5] + " к защите) - " + Price [5] + " монет");
			} 
			else if (TakenItem [5] == true && NumberDefence == 3) {
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine ("   9) " + DefenceName[3] + " (+" + PowerItem [5] + " к защите)");
				Defence = 0 + PowerItem[5];
			}
			else {
				Console.ForegroundColor = ConsoleColor.DarkYellow;
				Console.WriteLine ("   9) " + DefenceName[3] + " (+" + PowerItem [5] + " к защите)");
			}

			//Железная броня
			if (TakenItem [9] == false) {
				Console.ForegroundColor = ConsoleColor.Gray;
				Console.WriteLine ("   10) " + DefenceName[4] + " (+" + PowerItem [11] + " к защите) - " + Price [9] + " монет");
			} 
			else if (TakenItem [9] == true && NumberDefence == 4) {
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine ("   10) " + DefenceName[4] + " (+" + PowerItem [11] + " к защите)");
				Defence = 0 + PowerItem[11];
			}
			else {
				Console.ForegroundColor = ConsoleColor.DarkYellow;
				Console.WriteLine ("   10) " + DefenceName[4] + " (+" + PowerItem [11] + " к защите)");
			}

			//Броня кары
			if (TakenItem [16] == false) {
				Console.ForegroundColor = ConsoleColor.Gray;
				Console.WriteLine ("   11) " + DefenceName[6] + " (+" + PowerItem[17] + " к защите и +" + PowerItem[19] + "% к каре) - " + Price[12] + " монет");
			} 
			else if (TakenItem [16] == true && NumberDefence == 6) {
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine ("   11) " + DefenceName[6] + " (+" + PowerItem[17] + " к защите и +" + PowerItem[19] + "% к каре)");
				Defence = 0 + PowerItem[17];
				Kara [1] = PowerItem[19];
				PowerItem [14] = Kara [0] + Kara[1];
			}
			else {
				Console.ForegroundColor = ConsoleColor.DarkYellow;
				Console.WriteLine ("   11) " + DefenceName[6] + " (+" + PowerItem[17] + " к защите и +" + PowerItem[19] + "% к каре)");
				Kara [1] = 0;
				PowerItem [14] = Kara [0] + Kara[1];
			}

			//Латы
			if (TakenItem [10] == false) {
				Console.ForegroundColor = ConsoleColor.Gray;
				Console.WriteLine ("   12) " + DefenceName[5] + " (+" + PowerItem [12] + " к защите) - " + Price [10] + " монет");
			} 
			else if (TakenItem [10] == true && NumberDefence == 5) {
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine ("   12) " + DefenceName[5] + " (+" + PowerItem [12] + " к защите)");
				Defence = 0 + PowerItem[12];
			}
			else {
				Console.ForegroundColor = ConsoleColor.DarkYellow;
				Console.WriteLine ("   12) " + DefenceName[5] + " (+" + PowerItem [12] + " к защите)");
			}

			//Ожерелья
			Console.WriteLine("");
			Console.ForegroundColor = ConsoleColor.DarkMagenta;
			Console.WriteLine ("Ожерелья");

			//Ожерелье жизни
			if (TakenItem [11] == false) {
				Console.ForegroundColor = ConsoleColor.Gray;
				Console.WriteLine ("   13) " + NeckletName[1] + " (+" + PowerItem [13] + " к максимальному здоровью) - " + Price [11] + " монет");
			} 
			else if (TakenItem [11] == true && NumberNecklet == 1) {
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine ("   13) " + NeckletName[1] + " (+" + PowerItem [13] + " к максимальному здоровью)");
				PlusMaxHP [1] = 50;
				MaxHealth = 100 + PlusMaxHP [0] + PlusMaxHP [1];
			}
			else {
				Console.ForegroundColor = ConsoleColor.DarkYellow;
				Console.WriteLine ("   13) " + NeckletName[1] + " (+" + PowerItem [13] + " к максимальному здоровью)");
				PlusMaxHP [1] = 0;
				MaxHealth = 100 + PlusMaxHP [0] + PlusMaxHP [1];
			}

			//Ожерелье кары
			if (TakenItem [12] == false) {
				Console.ForegroundColor = ConsoleColor.Gray;
				Console.WriteLine ("   14) " + NeckletName[2] + " (+" + PowerItem[18] + "%" + " к каре) - " + Price [11] + " монет");
			} 
			else if (TakenItem [12] == true && NumberNecklet == 2) {
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine ("   14) " + NeckletName[2] + " (+" + PowerItem[18] + "%" + " к каре)");
				Kara [0] = PowerItem[18];
				PowerItem [14] = Kara [0] + Kara[1];
			}
			else {
				Console.ForegroundColor = ConsoleColor.DarkYellow;
				Console.WriteLine ("   14) " + NeckletName[2] + " (+" + PowerItem[18] + "%" + " к каре)");
				Kara [0] = 0;
				PowerItem [14] = Kara [0] + Kara[1];
			}

			//Ожерелье регенераций
			if (TakenItem [13] == false) {
				Console.ForegroundColor = ConsoleColor.Gray;
				Console.WriteLine ("   15) " + NeckletName[3] + " (Восстанавливает здоровье в бою) - " + Price [11] + " монет");
			} 
			else if (TakenItem [13] == true && NumberNecklet == 3) {
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine ("   15) " + NeckletName[3] + " (Восстанавливает здоровье в бою)");
			}
			else {
				Console.ForegroundColor = ConsoleColor.DarkYellow;
				Console.WriteLine ("   15) " + NeckletName[3] + " (Восстанавливает здоровье в бою)");
			}

			//Ожерелье стремительности
			if (TakenItem [14] == false) {
				Console.ForegroundColor = ConsoleColor.Gray;
				Console.WriteLine ("   16) " + NeckletName[4] + " (Шанс сделать дополнительный ход) - " + Price [11] + " монет");
			} 
			else if (TakenItem [14] == true && NumberNecklet == 4) {
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine ("   16) " + NeckletName[4] + " (Шанс сделать дополнительный ход)");
			}
			else {
				Console.ForegroundColor = ConsoleColor.DarkYellow;
				Console.WriteLine ("   16) " + NeckletName[4] + " (Шанс сделать дополнительный ход)");
			}

			//Действия

			Console.WriteLine("");
			Console.ForegroundColor = ConsoleColor.DarkGray;
			Console.WriteLine ("Другое");

			//Загадочный шар
			if (TakenItem [17] == false) {
				Console.ForegroundColor = ConsoleColor.Gray;
				Console.WriteLine ("   17) Загадочный шар - " + Price[13] + " монет");
			} 
			else if (TakenItem [17] == true) {
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine ("   17) Загадочный шар");
			}

			//Выйти из лавки
			Console.ForegroundColor = ConsoleColor.Gray;
			Console.WriteLine ("   18) Выйти из лавки");

			//Костыль, смотри переменную ItemCheck
			if (ItemCheck == true) {
				ItemCheck = false;
				GameMenu ();
			}

			//Выбор варианта
			string text = Console.ReadLine ();
			string x = Convert.ToString (text);

			Console.Clear ();

			switch (x) 
			{
			case "1":
				if (TakenItem [0] == false) {
					DybinkaBuy();
				}
				else if (TakenItem [0] == true && NumberDamage == 1) {
					NumberDamage = 0;
					Shop ();
				}
				else {
					NumberDamage = 1;
					Shop ();
				}
				break;

			case "2":
				if (TakenItem [1] == false) {
					KlinokBuy();
				}
				else if (TakenItem [1] == true && NumberDamage == 2) {
					NumberDamage = 0;
					Shop ();
				}
				else {
					NumberDamage = 2;
					Shop ();
				}
				break;
			case "3":
				if (TakenItem [4] == false) {
					FightAxeBuy();
				}
				else if (TakenItem [4] == true && NumberDamage == 3) {
					NumberDamage = 0;
					Shop ();
				}
				else {
					NumberDamage = 3;
					Shop ();
				}
				break;

			case "4":
				if (TakenItem [6] == false) {
					StickLifeBuy ();
				}
				else if (TakenItem [6] == true && NumberDamage == 4) {
					NumberDamage = 0;
					Shop ();
				}
				else {
					NumberDamage = 4;
					Shop ();
				}
				break;

			case "5":
				if (TakenItem [7] == false) {
					SwordBuy ();
				}
				else if (TakenItem [7] == true && NumberDamage == 5) {
					NumberDamage = 0;
					Shop ();
				}
				else {
					NumberDamage = 5;
					Shop ();
				}
				break;

			case "6":
				if (TakenItem [8] == false) {
					AleksandrovaSekiraBuy ();
				}
				else if (TakenItem [8] == true && NumberDamage == 6) {
					NumberDamage = 0;
					Shop ();
				}
				else {
					NumberDamage = 6;
					Shop ();
				}
				break;

			case "7":
				if (TakenItem [2] == false) {
					NormClothBuy();
				}
				else if (TakenItem [2] == true && NumberDefence == 1) {
					NumberDefence = 0;
					Shop ();
				}
				else {
					NumberDefence = 1;
					Shop ();
				}
				break;

			case "8":
				if (TakenItem [3] == false) {
					KojArmorBuy();
				}
				else if (TakenItem [3] == true && NumberDefence == 2) {
					NumberDefence = 0;
					Shop ();
				}
				else {
					NumberDefence = 2;
					Shop ();
				}
				break;

			case "9":
				if (TakenItem [5] == false) {
					KolchygaBuy();
				}
				else if (TakenItem [5] == true && NumberDefence == 3) {
					NumberDefence = 0;
					Shop ();
				}
				else {
					NumberDefence = 3;
					Shop ();
				}
				break;

			case "10":
				if (TakenItem [9] == false) {
					IronArmorBuy ();
				}
				else if (TakenItem [9] == true && NumberDefence == 4) {
					NumberDefence = 0;
					Shop ();
				}
				else {
					NumberDefence = 4;
					Shop ();
				}
				break;

			case "11":
				if (TakenItem [16] == false) {
					ArmorKaraBuy ();
				}
				else if (TakenItem [16] == true && NumberDefence == 6) {
					NumberDefence = 0;
					Shop ();
				}
				else {
					NumberDefence = 6;
					Shop ();
				}
				break;

			case "12":
				if (TakenItem [10] == false) {
					LatiBuy ();
				}
				else if (TakenItem [10] == true && NumberDefence == 5) {
					NumberDefence = 0;
					Shop ();
				}
				else {
					NumberDefence = 5;
					Shop ();
				}
				break;

			case "13":
				if (TakenItem [11] == false) {
					NeckletLifeBuy ();
				}
				else if (TakenItem [11] == true && NumberNecklet == 1) {
					NumberNecklet = 0;
					Shop ();
				}
				else {
					NumberNecklet = 1;
					Shop ();
				}
				break;

			case "14":
				if (TakenItem [12] == false) {
					NeckletKaraBuy ();
				}
				else if (TakenItem [12] == true && NumberNecklet == 2) {
					NumberNecklet = 0;
					Shop ();
				}
				else {
					NumberNecklet = 2;
					Shop ();
				}
				break;

			case "15":
				if (TakenItem [13] == false) {
					NeckletRegenerateBuy ();
				}
				else if (TakenItem [13] == true && NumberNecklet == 3) {
					NumberNecklet = 0;
					Shop ();
				}
				else {
					NumberNecklet = 3;
					Shop ();
				}
				break;

			case "16":
				if (TakenItem [14] == false) {
					NeckletSpeedBuy ();
				}
				else if (TakenItem [14] == true && NumberNecklet == 4) {
					NumberNecklet = 0;
					Shop ();
				}
				else {
					NumberNecklet = 4;
					Shop ();
				}
				break;

			case "17":
				if (TakenItem [17] == false) {
					MysterySphere ();
				} 
				else {
					Shop ();
				}
				break;

			case "18":
				GameMenu ();
				break;

			default:
				Shop ();
				break;
			}
		}

		void DybinkaBuy() {
			Console.Clear ();

			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine (DamageName[1] + " (+" + PowerItem[0] + " к урону) - " + Price[0] + " монет");
			Console.WriteLine ("");

			Console.ForegroundColor = ConsoleColor.Gray;
			Console.WriteLine ("Вы точно хотите купить этот товар?");
			Console.WriteLine ("");

			Console.ForegroundColor = ConsoleColor.DarkCyan;
			Console.WriteLine ("Степан: Ну что, хорошая такая дубиночка. Лесных слизней раскидывает хорошо");

			Console.ForegroundColor = ConsoleColor.Gray;
			Console.WriteLine ("");
			Console.WriteLine ("1) Купить(-" + Price[0] + " монет)");
			Console.WriteLine ("2) Отмена");

			string text = Console.ReadLine ();
			string x = Convert.ToString (text);

			switch (x) 
			{
			case "1":
				//Подтверждение покупки ДУБИНКИ
				if (Money >= Price [0]) {
					Money -= Price [0];
					TakenItem [0] = true;
					NumberDamage = 1;

					Console.Clear ();

					Console.ForegroundColor = ConsoleColor.Yellow;
					Console.WriteLine ("Вы купили дубинку!");

					Console.ReadKey ();
					Shop ();
				} 
				else {
					Console.Clear ();

					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine ("У вас недостаточно монет!");

					Console.ReadKey ();
					Shop ();
				}
				break;
			case "2":
				//Отмена покупки ДУБИНКИ
				Shop ();
				break;
			default:
				DybinkaBuy ();
				break;
			}
		}

		void KlinokBuy() {
			Console.Clear ();

			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine (DamageName[2] + " (+" + PowerItem[1] + " к урону) - " + Price[1] + " монет");
			Console.WriteLine ("");

			Console.ForegroundColor = ConsoleColor.Gray;
			Console.WriteLine ("Вы точно хотите купить этот товар?");
			Console.WriteLine ("");

			Console.ForegroundColor = ConsoleColor.DarkCyan;
			Console.WriteLine ("Степан: Хорошая вещица. И носить легко и секёт врагов неплохо");

			Console.ForegroundColor = ConsoleColor.Gray;
			Console.WriteLine ("");
			Console.WriteLine ("1) Купить(-" + Price[1] + " монет)");
			Console.WriteLine ("2) Отмена");

			string text = Console.ReadLine ();
			string x = Convert.ToString (text);

			switch (x) 
			{
			case "1":
				//Подтверждение покупки КЛИНКА
				if (Money >= Price [1]) {
					Money -= Price [1];
					TakenItem [1] = true;
					NumberDamage = 2;

					Console.Clear ();

					Console.ForegroundColor = ConsoleColor.Yellow;
					Console.WriteLine ("Вы купили клинок!");

					Console.ReadKey ();
					Shop ();
				} 
				else {
					Console.Clear ();

					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine ("У вас недостаточно монет!");

					Console.ReadKey ();
					Shop ();
				}
				break;
			case "2":
				//Отмена покупки КЛИНКА
				Shop ();
				break;
			default:
				KlinokBuy ();
				break;
			}
		}

		void FightAxeBuy() {
			Console.Clear ();

			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine (DamageName[3] + " (+" + PowerItem[4] + " к урону) - " + Price[4] + " монет");
			Console.WriteLine ("");

			Console.ForegroundColor = ConsoleColor.Gray;
			Console.WriteLine ("Вы точно хотите купить этот товар?");
			Console.WriteLine ("");

			Console.ForegroundColor = ConsoleColor.DarkCyan;
			Console.WriteLine ("Степан: Эти боевые топорики, когда - то давно, когда я ещё и не родился, покупал у моего отца сам Пётр Игнатьевич. Хорошо отзывался он о них, но до той поры, пока для его сражений не понадобилось более хорошее оружие, так и пропали эти топорики из его боевого арсенала...");

			Console.ForegroundColor = ConsoleColor.Gray;
			Console.WriteLine ("");
			Console.WriteLine ("1) Купить(-" + Price[4] + " монет)");
			Console.WriteLine ("2) Отмена");

			string text = Console.ReadLine ();
			string x = Convert.ToString (text);

			switch (x) 
			{
			case "1":
				//Подтверждение покупки БОЕВОГО ТОПОРИКА
				if (Money >= Price [4]) {
					Money -= Price [4];
					TakenItem [4] = true;
					NumberDamage = 3;

					Console.Clear ();

					Console.ForegroundColor = ConsoleColor.Yellow;
					Console.WriteLine ("Вы купили боевой топорик!");

					Console.ReadKey ();
					Shop ();
				} 
				else {
					Console.Clear ();

					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine ("У вас недостаточно монет!");

					Console.ReadKey ();
					Shop ();
				}
				break;
			case "2":
				//Отмена покупки БОЕВОГО ТОПОРИКА
				Shop ();
				break;
			default:
				FightAxeBuy ();
				break;
			}
		}

		void StickLifeBuy() {
			Console.Clear ();

			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine (DamageName [4] + " (+" + PowerItem [7] + " к урону и +" + PowerItem [8] + " к максимальному здоровью) - " + Price [7] + " монет");
			Console.WriteLine ("");

			Console.ForegroundColor = ConsoleColor.Gray;
			Console.WriteLine ("Вы точно хотите купить этот товар?");
			Console.WriteLine ("");

			Console.ForegroundColor = ConsoleColor.DarkCyan;
			Console.WriteLine ("Степан: Палка жизни, создана она одним нейзвестным магом. Она хоть и выглядит как обычная палка, но тот кто её держит у себя в руках, чувствует себя здоровее. Название её весьма иронично, учитывая что она является оружием");

			Console.ForegroundColor = ConsoleColor.Gray;
			Console.WriteLine ("");
			Console.WriteLine ("1) Купить(-" + Price[7] + " монет)");
			Console.WriteLine ("2) Отмена");

			string text = Console.ReadLine ();
			string x = Convert.ToString (text);

			switch (x) 
			{
			case "1":
				//Подтверждение покупки ПАЛКИ ЖИЗНИ
				if (Money >= Price [7]) {
					Money -= Price [7];
					TakenItem [6] = true;
					NumberDamage = 4;

					Console.Clear ();

					Console.ForegroundColor = ConsoleColor.Yellow;
					Console.WriteLine ("Вы купили палку жизни!");

					Console.ReadKey ();
					Shop ();
				} 
				else {
					Console.Clear ();

					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine ("У вас недостаточно монет!");

					Console.ReadKey ();
					Shop ();
				}
				break;
			case "2":
				//Отмена покупки ПАЛКИ ЖИЗНИ
				Shop ();
				break;
			default:
				StickLifeBuy ();
				break;
			}
		}

		void SwordBuy() {
			Console.Clear ();

			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine (DamageName[5] + " (+" + PowerItem[9] + " к урону) - " + Price[7] + " монет");
			Console.WriteLine ("");

			Console.ForegroundColor = ConsoleColor.Gray;
			Console.WriteLine ("Вы точно хотите купить этот товар?");
			Console.WriteLine ("");

			Console.ForegroundColor = ConsoleColor.DarkCyan;
			Console.WriteLine ("Степан: Обыкновенный меч, который давно стал символом сражений");

			Console.ForegroundColor = ConsoleColor.Gray;
			Console.WriteLine ("");
			Console.WriteLine ("1) Купить(-" + Price[7] + " монет)");
			Console.WriteLine ("2) Отмена");

			string text = Console.ReadLine ();
			string x = Convert.ToString (text);

			switch (x) 
			{
			case "1":
				//Подтверждение покупки МЕЧА
				if (Money >= Price [7]) {
					Money -= Price [7];
					TakenItem [7] = true;
					NumberDamage = 5;

					Console.Clear ();

					Console.ForegroundColor = ConsoleColor.Yellow;
					Console.WriteLine ("Вы купили меч!");

					Console.ReadKey ();
					Shop ();
				} 
				else {
					Console.Clear ();

					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine ("У вас недостаточно монет!");

					Console.ReadKey ();
					Shop ();
				}
				break;
			case "2":
				//Отмена покупки МЕЧА
				Shop ();
				break;
			default:
				SwordBuy ();
				break;
			}
		}

		void AleksandrovaSekiraBuy() {
			Console.Clear ();

			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine (DamageName[6] + " (+" + PowerItem[10] + " к урону) - " + Price[8] + " монет");
			Console.WriteLine ("");

			Console.ForegroundColor = ConsoleColor.Gray;
			Console.WriteLine ("Вы точно хотите купить этот товар?");
			Console.WriteLine ("");

			Console.ForegroundColor = ConsoleColor.DarkCyan;
			Console.WriteLine ("Степан: Жил такой богатырь на Руси, звали его Александром, не такой конечно могучий, как Пётр Игнатьевич, но за свою жизнь получил тоже немалую славу. Когда стал он силён ему понадобилось более мощное оружие, но такового в лавках и рынках не имелось. И решил он тогда заказать собственное оружие, пошёл он к кузнецу Липецкому и попросил его сделать секиру, ему очень нравились такие оружия. Дал большую сумму денег и стал ждать, пока его сделают. Позже, он пришёл за своим новым оружием к тому мастеру и обомлел... Оружие было такое прочное, такое лёгкое, такое острое, что посмотришь на остриё и глаза начнёт резать. Взял он его да так и до смерти продержал. После его смерти, у того мастера Липецкого начали выпрашивать секрет того оружия. Долго-ж они выпрашивали, но таки выпросили. После, множество кузнецов начали ковать эти секиры и прозвали их Александровы, в честь того самого богатыря. На сей день это самые мощные секиры на Руси");

			Console.ForegroundColor = ConsoleColor.Gray;
			Console.WriteLine ("");
			Console.WriteLine ("1) Купить(-" + Price[8] + " монет)");
			Console.WriteLine ("2) Отмена");

			string text = Console.ReadLine ();
			string x = Convert.ToString (text);

			switch (x) 
			{
			case "1":
				//Подтверждение покупки АЛЕКСАНДРОВОЙ СЕКИРЫ
				if (Money >= Price [8]) {
					Money -= Price [8];
					TakenItem [8] = true;
					NumberDamage = 6;

					Console.Clear ();

					Console.ForegroundColor = ConsoleColor.Yellow;
					Console.WriteLine ("Вы купили Александрову секиру!");

					Console.ReadKey ();
					Shop ();
				} 
				else {
					Console.Clear ();

					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine ("У вас недостаточно монет!");

					Console.ReadKey ();
					Shop ();
				}
				break;
			case "2":
				//Отмена покупки АЛЕКСАНДРОВОЙ СЕКИРЫ
				Shop ();
				break;
			default:
				AleksandrovaSekiraBuy ();
				break;
			}
		}

		void NormClothBuy() {
			Console.Clear ();

			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine (DefenceName[1] + " (+" + PowerItem[2] + " к защите) - " + Price[2] + " монет");
			Console.WriteLine ("");

			Console.ForegroundColor = ConsoleColor.Gray;
			Console.WriteLine ("Вы точно хотите купить этот товар?");
			Console.WriteLine ("");

			Console.ForegroundColor = ConsoleColor.DarkCyan;
			Console.WriteLine ("Степан: Хорошая обычная одежда, её мой знакомый сшил. Все в подобной ходят, ибо она не только красива, но и защищает неплохо");

			Console.ForegroundColor = ConsoleColor.Gray;
			Console.WriteLine ("");
			Console.WriteLine ("1) Купить(-" + Price[2] + " монет)");
			Console.WriteLine ("2) Отмена");

			string text = Console.ReadLine ();
			string x = Convert.ToString (text);

			switch (x) 
			{
			case "1":
				//Подтверждение покупки НОРМАЛЬНОЙ ОДЕЖДЫ
				if (Money >= Price [2]) {
					Money -= Price [2];
					TakenItem [2] = true;
					NumberDefence = 1;

					Console.Clear ();

					Console.ForegroundColor = ConsoleColor.Yellow;
					Console.WriteLine ("Вы купили нормальную одежду!");

					Console.ReadKey ();
					Shop ();
				} 
				else {
					Console.Clear ();

					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine ("У вас недостаточно монет!");

					Console.ReadKey ();
					Shop ();
				}
				break;
			case "2":
				//Отмена покупки НОРМАЛЬНОЙ ОДЕЖДЫ
				Shop ();
				break;
			default:
				NormClothBuy ();
				break;
			}
		}

		void KojArmorBuy() {
			Console.Clear ();

			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine (DefenceName[2] + " (+" + PowerItem[3] + " к защите) - " + Price[3] + " монет");
			Console.WriteLine ("");

			Console.ForegroundColor = ConsoleColor.Gray;
			Console.WriteLine ("Вы точно хотите купить этот товар?");
			Console.WriteLine ("");

			Console.ForegroundColor = ConsoleColor.DarkCyan;
			Console.WriteLine ("Степан: Её и делать недорого, и защищает хорошо. Поэтому она и любимица начинающих войнов");

			Console.ForegroundColor = ConsoleColor.Gray;
			Console.WriteLine ("");
			Console.WriteLine ("1) Купить(-" + Price[3] + " монет)");
			Console.WriteLine ("2) Отмена");

			string text = Console.ReadLine ();
			string x = Convert.ToString (text);

			switch (x) 
			{
			case "1":
				//Подтверждение покупки КОЖАНОЙ БРОНИ
				if (Money >= Price [3]) {
					Money -= Price [3];
					TakenItem [3] = true;
					NumberDefence = 2;

					Console.Clear ();

					Console.ForegroundColor = ConsoleColor.Yellow;
					Console.WriteLine ("Вы купили кожаную броню!");

					Console.ReadKey ();
					Shop ();
				} 
				else {
					Console.Clear ();

					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine ("У вас недостаточно монет!");

					Console.ReadKey ();
					Shop ();
				}
				break;
			case "2":
				//Отмена покупки КОЖАНОЙ БРОНИ
				Shop ();
				break;
			default:
				KojArmorBuy ();
				break;
			}
		}

		void KolchygaBuy() {
			Console.Clear ();

			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine (DefenceName[3] + " (+" + PowerItem[5] + " к защите) - " + Price[5] + " монет");
			Console.WriteLine ("");

			Console.ForegroundColor = ConsoleColor.Gray;
			Console.WriteLine ("Вы точно хотите купить этот товар?");
			Console.WriteLine ("");

			Console.ForegroundColor = ConsoleColor.DarkCyan;
			Console.WriteLine ("Степан: Хорошая лёгкая броня, бегать легко, защищает хорошо, люблю я ходить в ней по лесу");

			Console.ForegroundColor = ConsoleColor.Gray;
			Console.WriteLine ("");
			Console.WriteLine ("1) Купить(-" + Price[5] + " монет)");
			Console.WriteLine ("2) Отмена");

			string text = Console.ReadLine ();
			string x = Convert.ToString (text);

			switch (x) 
			{
			case "1":
				//Подтверждение покупки КОЛЬЧУЖНОЙ БРОНИ
				if (Money >= Price [5]) {
					Money -= Price [5];
					TakenItem [5] = true;
					NumberDefence = 3;

					Console.Clear ();

					Console.ForegroundColor = ConsoleColor.Yellow;
					Console.WriteLine ("Вы купили кольчужную броню!");

					Console.ReadKey ();
					Shop ();
				} 
				else {
					Console.Clear ();

					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine ("У вас недостаточно монет!");

					Console.ReadKey ();
					Shop ();
				}
				break;
			case "2":
				//Отмена покупки КОЛЬЧУЖНОЙ БРОНИ
				Shop ();
				break;
			default:
				KolchygaBuy ();
				break;
			}
		}

		void IronArmorBuy() {
			Console.Clear ();

			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine (DefenceName[4] + " (+" + PowerItem[11] + " к защите) - " + Price[9] + " монет");
			Console.WriteLine ("");

			Console.ForegroundColor = ConsoleColor.Gray;
			Console.WriteLine ("Вы точно хотите купить этот товар?");
			Console.WriteLine ("");

			Console.ForegroundColor = ConsoleColor.DarkCyan;
			Console.WriteLine ("Степан: Довольно тяжёлая, но защищает нехуже");

			Console.ForegroundColor = ConsoleColor.Gray;
			Console.WriteLine ("");
			Console.WriteLine ("1) Купить(-" + Price[9] + " монет)");
			Console.WriteLine ("2) Отмена");

			string text = Console.ReadLine ();
			string x = Convert.ToString (text);

			switch (x) 
			{
			case "1":
				//Подтверждение покупки ЖЕЛЕЗНОЙ БРОНИ
				if (Money >= Price [9]) {
					Money -= Price [9];
					TakenItem [9] = true;
					NumberDefence = 4;

					Console.Clear ();

					Console.ForegroundColor = ConsoleColor.Yellow;
					Console.WriteLine ("Вы купили железную броню!");

					Console.ReadKey ();
					Shop ();
				} 
				else {
					Console.Clear ();

					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine ("У вас недостаточно монет!");

					Console.ReadKey ();
					Shop ();
				}
				break;
			case "2":
				//Отмена покупки ЖЕЛЕЗНОЙ БРОНИ
				Shop ();
				break;
			default:
				IronArmorBuy ();
				break;
			}
		}

		void ArmorKaraBuy() {
			Console.Clear ();

			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine (DefenceName[6] + " (+" + PowerItem[17] + " к защите и +" + PowerItem[19] + "% к каре) - " + Price[12] + " монет");
			Console.WriteLine ("");

			Console.ForegroundColor = ConsoleColor.Gray;
			Console.WriteLine ("Вы точно хотите купить этот товар?");
			Console.WriteLine ("");

			Console.ForegroundColor = ConsoleColor.DarkCyan;
			Console.WriteLine ("Степан: Броня кары, её ещё называют Броня Василитовых. Василитовы - это два брата волшебника, создавшие её. Она способна вернуть часть полученной хозяином боли противнику");

			Console.ForegroundColor = ConsoleColor.Gray;
			Console.WriteLine ("");
			Console.WriteLine ("1) Купить(-" + Price[12] + " монет)");
			Console.WriteLine ("2) Отмена");

			string text = Console.ReadLine ();
			string x = Convert.ToString (text);

			switch (x) 
			{
			case "1":
				//Подтверждение покупки БРОНИ КАРЫ
				if (Money >= Price [12]) {
					Money -= Price [12];
					TakenItem [16] = true;
					NumberDefence = 6;

					Console.Clear ();

					Console.ForegroundColor = ConsoleColor.Yellow;
					Console.WriteLine ("Вы купили броню кары!");

					Console.ReadKey ();
					Shop ();
				} 
				else {
					Console.Clear ();

					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine ("У вас недостаточно монет!");

					Console.ReadKey ();
					Shop ();
				}
				break;
			case "2":
				//Отмена покупки БРОНИ КАРЫ
				Shop ();
				break;
			default:
				ArmorKaraBuy ();
				break;
			}
		}

		void LatiBuy() {
			Console.Clear ();

			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine (DefenceName[5] + " (+" + PowerItem[12] + " к защите) - " + Price[10] + " монет");
			Console.WriteLine ("");

			Console.ForegroundColor = ConsoleColor.Gray;
			Console.WriteLine ("Вы точно хотите купить этот товар?");
			Console.WriteLine ("");

			Console.ForegroundColor = ConsoleColor.DarkCyan;
			Console.WriteLine ("Степан: Прекрасные доспехи! Их все великие рыцари да богатыри носят, Пётр Игнатьевич, Александр и прочие. Ибо их нигде не пробить и сложно сломать");

			Console.ForegroundColor = ConsoleColor.Gray;
			Console.WriteLine ("");
			Console.WriteLine ("1) Купить(-" + Price[10] + " монет)");
			Console.WriteLine ("2) Отмена");

			string text = Console.ReadLine ();
			string x = Convert.ToString (text);

			switch (x) 
			{
			case "1":
				//Подтверждение покупки ЛАТ
				if (Money >= Price [10]) {
					Money -= Price [10];
					TakenItem [10] = true;
					NumberDefence = 5;

					Console.Clear ();

					Console.ForegroundColor = ConsoleColor.Yellow;
					Console.WriteLine ("Вы купили латы!");

					Console.ReadKey ();
					Shop ();
				} 
				else {
					Console.Clear ();

					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine ("У вас недостаточно монет!");

					Console.ReadKey ();
					Shop ();
				}
				break;
			case "2":
				//Отмена покупки ЛАТ
				Shop ();
				break;
			default:
				LatiBuy ();
				break;
			}
		}

		void NeckletLifeBuy() {
			Console.Clear ();

			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine (NeckletName[1] + " (+" + PowerItem[13] + " к максимальному здоровью) - " + Price[11] + " монет");
			Console.WriteLine ("");

			Console.ForegroundColor = ConsoleColor.Gray;
			Console.WriteLine ("Вы точно хотите купить этот товар?");
			Console.WriteLine ("");

			Console.ForegroundColor = ConsoleColor.DarkCyan;
			Console.WriteLine ("Степан: Ожерелье жизни, на нём, как видишь, висит зелёное бриллиантовое сердце. Оно заколдовано одним старым магом и является самым первым видом магических ожерелий. Оно способно улучшать самочувствие своему хозяину, несомненно полезная вещица");

			Console.ForegroundColor = ConsoleColor.Gray;
			Console.WriteLine ("");
			Console.WriteLine ("1) Купить(-" + Price[11] + " монет)");
			Console.WriteLine ("2) Отмена");

			string text = Console.ReadLine ();
			string x = Convert.ToString (text);

			switch (x) 
			{
			case "1":
				//Подтверждение покупки ОЖЕРЕЛЬЯ ЖИЗНИ
				if (Money >= Price [11]) {
					Money -= Price [11];
					TakenItem [11] = true;
					NumberNecklet = 1;;

					Console.Clear ();

					Console.ForegroundColor = ConsoleColor.Yellow;
					Console.WriteLine ("Вы купили ожерелье жизни!");

					Console.ReadKey ();
					Shop ();
				} 
				else {
					Console.Clear ();

					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine ("У вас недостаточно монет!");

					Console.ReadKey ();
					Shop ();
				}
				break;
			case "2":
				//Отмена покупки ОЖЕРЕЛЬЯ ЖИЗНИ
				Shop ();
				break;
			default:
				NeckletLifeBuy ();
				break;
			}
		}

		void NeckletKaraBuy() {
			Console.Clear ();

			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine (NeckletName [2] + " (+" + PowerItem[18] + "%" + " к каре) - " + Price [11] + " монет");
			Console.WriteLine ("");

			Console.ForegroundColor = ConsoleColor.Gray;
			Console.WriteLine ("Вы точно хотите купить этот товар?");
			Console.WriteLine ("");

			Console.ForegroundColor = ConsoleColor.DarkCyan;
			Console.WriteLine ("Степан: Это ожерелье кары, видишь этот висящий волчий зуб? Он означает карательность. На этот зуб наложено заклятие, если кто - либо ударит хозяина этого ожерелья, то некоторая часть полученной боли вернётся обидчику");

			Console.ForegroundColor = ConsoleColor.Gray;
			Console.WriteLine ("");
			Console.WriteLine ("1) Купить(-" + Price [11] + " монет)");
			Console.WriteLine ("2) Отмена");

			string text = Console.ReadLine ();
			string x = Convert.ToString (text);

			switch (x) {
			case "1":
				//Подтверждение покупки ОЖЕРЕЛЬЯ КАРЫ
				if (Money >= Price [11]) {
					Money -= Price [11];
					TakenItem [12] = true;
					NumberNecklet = 2;

					Console.Clear ();

					Console.ForegroundColor = ConsoleColor.Yellow;
					Console.WriteLine ("Вы купили ожерелье кары!");

					Console.ReadKey ();
					Shop ();
				} else {
					Console.Clear ();

					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine ("У вас недостаточно монет!");

					Console.ReadKey ();
					Shop ();
				}
				break;
			case "2":
				//Отмена покупки ОЖЕРЕЛЬЯ КАРЫ
				Shop ();
				break;
			default:
				NeckletKaraBuy ();
				break;
			}
		}

		void NeckletRegenerateBuy() {
			Console.Clear ();

			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine (NeckletName[3] + " (Восстанавливает здоровье в бою) - " + Price [11] + " монет");
			Console.WriteLine ("");

			Console.ForegroundColor = ConsoleColor.Gray;
			Console.WriteLine ("Вы точно хотите купить этот товар?");
			Console.WriteLine ("");

			Console.ForegroundColor = ConsoleColor.DarkCyan;
			Console.WriteLine ("Степан: Это ожерелье регенераций, видишь этот зелёный крест? Он заколдован. Ускоряет заживление ран и ушибов, сращивание костей. Полезная вещь при длительных боях");

			Console.ForegroundColor = ConsoleColor.Gray;
			Console.WriteLine ("");
			Console.WriteLine ("1) Купить(-" + Price [11] + " монет)");
			Console.WriteLine ("2) Отмена");

			string text = Console.ReadLine ();
			string x = Convert.ToString (text);

			switch (x) {
			case "1":
				//Подтверждение покупки ОЖЕРЕЛЬЯ РЕГЕНЕРАЦИЙ
				if (Money >= Price [11]) {
					Money -= Price [11];
					TakenItem [13] = true;
					NumberNecklet = 3;

					Console.Clear ();

					Console.ForegroundColor = ConsoleColor.Yellow;
					Console.WriteLine ("Вы купили ожерелье регенераций!");

					Console.ReadKey ();
					Shop ();
				} else {
					Console.Clear ();

					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine ("У вас недостаточно монет!");

					Console.ReadKey ();
					Shop ();
				}
				break;
			case "2":
				//Отмена покупки ОЖЕРЕЛЬЯ РЕГЕНЕРАЦИЙ
				Shop ();
				break;
			default:
				NeckletRegenerateBuy ();
				break;
			}
		}

		void NeckletSpeedBuy() {
			Console.Clear ();

			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine (NeckletName[4] + " (Шанс сделать дополнительный ход) - " + Price [11] + " монет");
			Console.WriteLine ("");

			Console.ForegroundColor = ConsoleColor.Gray;
			Console.WriteLine ("Вы точно хотите купить этот товар?");
			Console.WriteLine ("");

			Console.ForegroundColor = ConsoleColor.DarkCyan;
			Console.WriteLine ("Степан: Возраст начинает брать своё? У меня тут одно ожерельице завалялось, ожерельем стремительности называют. Оно поможет тебе делать больше, чем ты делаешь сейчас. Оно ускоряет тело");

			Console.ForegroundColor = ConsoleColor.Gray;
			Console.WriteLine ("");
			Console.WriteLine ("1) Купить(-" + Price [11] + " монет)");
			Console.WriteLine ("2) Отмена");

			string text = Console.ReadLine ();
			string x = Convert.ToString (text);

			switch (x) {
			case "1":
				//Подтверждение покупки ОЖЕРЕЛЬЯ СТРЕМИТЕЛЬНОСТИ
				if (Money >= Price [11]) {
					Money -= Price [11];
					TakenItem [14] = true;
					NumberNecklet = 4;

					Console.Clear ();

					Console.ForegroundColor = ConsoleColor.Yellow;
					Console.WriteLine ("Вы купили ожерелье стремительности!");

					Console.ReadKey ();
					Shop ();
				} else {
					Console.Clear ();

					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine ("У вас недостаточно монет!");

					Console.ReadKey ();
					Shop ();
				}
				break;
			case "2":
				//Отмена покупки ОЖЕРЕЛЬЯ СТРЕМИТЕЛЬНОСТИ
				Shop ();
				break;
			default:
				NeckletSpeedBuy ();
				break;
			}
		}

		void MysterySphere() {
			Console.Clear ();

			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine ("Загадочный шар - " + Price[13] + " монет");
			Console.WriteLine ("");

			Console.ForegroundColor = ConsoleColor.Gray;
			Console.WriteLine ("Вы точно хотите купить этот товар?");
			Console.WriteLine ("");

			Console.ForegroundColor = ConsoleColor.DarkCyan;
			Console.WriteLine ("Степан: Оххх... Этот шар был наверно самой глупой покупкой в моей жизни. Он лежит, пылится у меня уже лет сорок. Я всё понижаю да понижаю на него цену, чтоб хотя - бы что - то вернуть от тех потраченных двух тысяч монет. Но он никому не нужен, никто не хочет повторить попытку Петра Игнатьевича... но может ты хочешь?");

			Console.ForegroundColor = ConsoleColor.Gray;
			Console.WriteLine ("");
			Console.WriteLine ("1) Купить(-" + Price [13] + " монет)");
			Console.WriteLine ("2) Отмена");

			string text = Console.ReadLine ();
			string x = Convert.ToString (text);

			switch (x) {
			case "1":
				//Подтверждение покупки ЗАГАДОЧНОГО ШАРА
				if (Money >= Price [13]) {
					Money -= Price [13];
					TakenItem [17] = true;

					Console.Clear ();

					Console.ForegroundColor = ConsoleColor.Yellow;
					Console.WriteLine ("Вы купили загадочный шар!");

					Console.ReadKey ();
					Console.Clear ();

					//Удивление Степана
					Console.ForegroundColor = ConsoleColor.DarkCyan;
					Console.WriteLine ("Степан: Серьёзно? Ты хочешь попробовать это сделать? Понимаешь, это очень и очень опасно");

					Console.ReadKey ();
					Console.Clear ();

					Console.WriteLine ("Степан: Значит, ты твёрдо решил сделать попытку... знаешь, я буду за тебя молиться. Ибо не хотелось - бы терять такого сильного богатыря... уже второй раз. Алтарь находится за лагерем разбойников, там и используешь этот шар");

					Console.ReadKey ();

					Shop ();
				} else {
					Console.Clear ();

					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine ("У вас недостаточно монет!");

					Console.ReadKey ();
					Shop ();
				}
				break;
			case "2":
				//Отмена покупки ЗАГАДОЧНОГО ШАРА

				Console.Clear ();

				//Степан это ожидал
				Console.ForegroundColor = ConsoleColor.DarkCyan;
				Console.WriteLine ("Степан: Ожидаемо...");

				Console.ReadKey ();

				Shop ();
				break;
			default:
				MysterySphere ();
				break;
			}
		}
	}
}