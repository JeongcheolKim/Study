
using MySql.Data.MySqlClient;

namespace GradeCalc
{
    class Program
    {
        // 메인 프로그램 동작
        static void Main(string[] args)
        {
            // 학생, 점수 배열 생성

            string[] Names = new string[20]; // 최대 학생 수
            int[] Kors = new int[20];
            int[] Engs = new int[20];
            int[] Maths = new int[20];
            int[] Sum = new int[20]; //평균

            Student student = new Student();

            string dataTable = "students";

            MariaDB maria = new MariaDB();
            MakeSql sql = new MakeSql();

            maria.open();   // 데이터베이스 연결

            int Cnt = 0;    // 학생 수 카운트
            string checkNull;

            while (true)
            {
                string selectmenu;

                Menu.showmenu();
                Console.WriteLine();
                Console.WriteLine("메뉴를 선택하세요 : ");
                selectmenu = Console.ReadLine();

                string inventory;

                switch (selectmenu)
                {
                    case "1":
                        Sum[Cnt] = student.insertInfo(Names, Kors, Engs, Maths, Cnt);   //각 정보 배열에 넣고, (합계 리턴)평균값 배열에 대입
                        inventory = sql.insertSql(dataTable, Names[Cnt], Kors[Cnt], Engs[Cnt], Maths[Cnt]);
                        Cnt++;  // 학생 수 +1
                        maria.run(inventory);
                        Console.WriteLine("... 키를 입력해주세요");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "2":
                        inventory = sql.selectSql(dataTable);
                        maria.selectInfo(inventory);
                        Console.WriteLine("... 키를 입력해주세요");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "3":
                        inventory = sql.orderSql(dataTable);
                        maria.selectInfo(inventory);
                        Console.WriteLine("... 키를 입력해주세요");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "4":
                        inventory = sql.selectSql(dataTable);
                        maria.selectInfo(inventory);

                        Console.Write("삭제할 이름을 입력해주세요 : ");
                        string deleteName = Console.ReadLine();
                        inventory = sql.deleteSql(dataTable, deleteName);
                        maria.run(inventory);

                        Cnt--;
                        Console.WriteLine("... 키를 입력해주세요");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "5":
                        inventory = sql.selectSql(dataTable);
                        maria.selectInfo(inventory);

                        Console.Write("점수를 변경하고 싶은 학생 이름을 입력해주세요 : ");
                        string changeName = Console.ReadLine();

                        int changeSubject = 0;
                        string changeSubjectName = null;
                        do
                        {
                            Console.WriteLine("국어(1), 영어(2), 수학(3)");
                            Console.Write("변경하고 싶은 과목 번호를 입력해주세요 : ");
                            checkNull = Console.ReadLine();
                            try
                            {
                                changeSubject = int.Parse(checkNull);
                            }
                            catch
                            {
                                continue;
                            }
                        } while (changeSubject == 0);
                        switch(changeSubject)
                        {
                            case 1:
                                changeSubjectName = "국어";
                                break;
                            case 2:
                                changeSubjectName = "영어";
                                break;
                            case 3:
                                changeSubjectName = "수학";
                                    break;
                        }


                        int changeScore = 0;
                        do
                        {
                            Console.Write("변경할 점수 : ");
                            checkNull = Console.ReadLine();
                            try
                            {
                                changeScore = int.Parse(checkNull);
                            }
                            catch
                            {
                                continue;
                            }
                        } while (changeScore == 0);
                        string field = "이름";
                        inventory = sql.updateSql(dataTable, field, changeSubjectName, changeScore, changeName);

                        maria.run(inventory);
                        Console.WriteLine("... 키를 입력해주세요");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "6":
                        return;
                    case "Y":
                        inventory = sql.deleteAllSql(dataTable);
                        maria.run(inventory);
                        Console.WriteLine("초기화 완료");
                        Console.WriteLine("... 키를 입력해주세요");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    default:
                        Console.Clear();
                        break;

                }
            }
        }
    }
}
            
        


