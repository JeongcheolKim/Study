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

        public string Name;// { get; set; }
                           //public int[] Score = new int[3];    // 0:국, 1:영, 2:수
        public int Kor, Eng, Math;

        public int insertInfo(string[] name, int[] kor, int[] eng, int[] math, int count)
        {
            // 이름 입력 받기
            int checkSameName = 0; // 동명이인 검사 flag용
            do
            {
                checkSameName = 0;
                Console.Write("이름을 입력하세요 : ");
                Name = Console.ReadLine();
                for (int i = 0; i < count; i++)
                    if (name[i] == Name)
                    {
                        Console.WriteLine("동명이인이 있습니다. 구분할 수 있게 이름을 지정해 주십시오.");
                        checkSameName = -1;
                    }
            } while (checkSameName != 0);

            string checkNull; // 엔터체크
                              //국어 점수 입력 받기
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

            // 영어 점수 입력 받기
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


            // 수학 점수 입력 받기
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

            // 학생 입력 순서대로 index에 값 대입
            name[count] = Name;
            kor[count] = Kor;
            eng[count] = Eng;
            math[count] = Math;

            int sum = (Kor + Eng + Math);

            // 합계 리턴
            return sum;
        }

       
    }
}
