using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeCalc
{
    class Menu
    {
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
    }
}
