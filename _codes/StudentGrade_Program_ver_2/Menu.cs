using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeCalc
{
    class Menu
    {
        Student student = new Student(); // student 객체 생성
        MariaDB maria = new MariaDB();
        MakeSql sql = new MakeSql();

        string dataTable = "students"; // 데이터  테이블 명
        string inventory;
        string checkNull;

        public Menu()
        {
            maria.open();   // 데이터베이스 연결
        }

        //메뉴 표시
        static public void showmenu()
        {
            Console.WriteLine("=====================================");
            Console.WriteLine("  1. 학생 정보 입력(이름, 국, 영, 수)");
            Console.WriteLine("  2. 전체 학생 목록 보기");
            Console.WriteLine("  3. 학생 성적 순 나열하기");
            Console.WriteLine("  4. 학생 정보 삭제");
            Console.WriteLine("  5. 학생 정보 수정");
            Console.WriteLine("  6. 프로그램 종료");
            Console.WriteLine("  Y. 학생 정보 초기화");
            Console.WriteLine("=====================================");
        }

        // 학생 정보 입력 메뉴
        public void insertMenu()
        {
            // 학생, 점수 변수 생성
            string Names = null;
            int Kors = 0;
            int Engs = 0;
            int Maths = 0;
            int Sum;

            Sum = student.insertInfo(ref Names, ref Kors, ref Engs, ref Maths);
            inventory = sql.insertSql(dataTable, Names, Kors, Engs, Maths);
            maria.run(inventory);
            Console.WriteLine("... 키를 입력해주세요");
            Console.ReadKey();
            Console.Clear();
        }

        // 전체 학생 목록 보기 메뉴
        public void contentsMenu()
        {
            inventory = sql.selectSql(dataTable);
            maria.selectInfo(inventory);
            Console.WriteLine("... 키를 입력해주세요");
            Console.ReadKey();
            Console.Clear();
        }

        // 성적 순 나열 메뉴
        public void sortMenu()
        {
            inventory = sql.orderSql(dataTable);
            maria.selectInfo(inventory);
            Console.WriteLine("... 키를 입력해주세요");
            Console.ReadKey();
            Console.Clear();
        }

        // 정보 삭제 메뉴
        public void deleteMenu()
        {
            inventory = sql.selectSql(dataTable);
            maria.selectInfo(inventory);

            Console.Write("삭제할 이름을 입력해주세요 : ");
            string deleteName = Console.ReadLine();
            inventory = sql.deleteSql(dataTable, deleteName);
            maria.run(inventory);

            Console.WriteLine("... 키를 입력해주세요");
            Console.ReadKey();
            Console.Clear();
        }

        // 정보 수정 메뉴
        public void modifyMenu()
        {
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

                switch (changeSubject)
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
            } while (changeSubject != 1 && changeSubject != 2 && changeSubject != 3);



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
        }

        // 정보 초기화 메뉴
        public void resetMenu()
        {
            inventory = sql.deleteAllSql(dataTable);
            maria.run(inventory);
            Console.WriteLine("초기화 완료");
            Console.WriteLine("... 키를 입력해주세요");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
