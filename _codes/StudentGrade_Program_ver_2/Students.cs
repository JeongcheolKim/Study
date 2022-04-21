using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;


namespace GradeCalc
{

    class Student
    {
        public string checkNull; // 엔터체크

        public string Name;// { get; set; }
                           //public int[] Score = new int[3];    // 0:국, 1:영, 2:수
        public int Kor, Eng, Math;

        public int insertInfo(ref string name, ref int kor, ref int eng, ref int math)
        {
            
            // 학생 입력 순서대로 index에 값 대입
            name = insertName();
            kor = insertKor();
            eng = insertEng();
            math = insertMath();

            int sum = (kor + eng + math);

            // 합계 리턴
            return sum;
        }

        
        // 하단부 각각 이름, 과목별 점수 입력 받는 메서드들 ////

        // 이름 입력 받는 메서드
        public string insertName()
        {
           
            Console.Write("이름을 입력하세요 : ");
            Name = Console.ReadLine();

            return Name;
        }

        // 국어 점수 입력 받는 메서드
        public int insertKor()
        {
            do
            {
                Kor = -1;   // 기본이 0으로 초기화 되기 때문에 예외 catch되어도 while문을 빠져나가서 -1 대입;
                Console.Write("국어 점수를 입력하세요 : ");
                checkNull = Console.ReadLine();
                try
                {
                    Kor = int.Parse(checkNull);
                }
                catch
                {
                    continue;
                }

                if (Kor < 0)
                    Console.WriteLine("점수는 0 이상이어야 합니다.");
                if (Kor > 100)
                    Console.WriteLine("점수는 100 이하여야 합니다.");
            } while (Kor < 0 || Kor > 100);

            return Kor;
        }

        // 영어 점수 입력 받는 메서드
        public int insertEng()
        {
            do
            {
                Eng = -1;
                Console.Write("영어 점수를 입력하세요 : ");
                checkNull = Console.ReadLine();
                try
                {
                    Eng = int.Parse(checkNull);
                }
                catch
                {
                    continue;
                }
                if (Eng < 0)
                    Console.WriteLine("점수는 0 이상이어야 합니다.");
                if (Eng > 100)
                    Console.WriteLine("점수는 100 이하여야 합니다.");
            } while (Eng < 0 || Eng > 100);

            return Eng;
        }

        // 수학 점수 입력받는 메서드
        public int insertMath()
        {
            do
            {
                Math = -1;
                Console.Write("수학 점수를 입력하세요 : ");
                checkNull = Console.ReadLine();
                try
                {
                    Math = int.Parse(checkNull);
                }
                catch
                {
                    continue;
                }
                if (Math < 0)
                    Console.WriteLine("점수는 0 이상이어야 합니다.");
                if (Math > 100)
                    Console.WriteLine("점수는 100 이하여야 합니다.");
            } while (Math < 0 || Math > 100);

            return Math;
        }

    }
}
