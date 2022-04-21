using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeCalc
{
    class Run
    {

        public void run()
        { 

            while (true)
            {
                string selectmenu;
                Menu menu = new Menu();
                Menu.showmenu();
                Console.WriteLine();
                Console.WriteLine("메뉴를 선택하세요 : ");
                selectmenu = Console.ReadLine();


                switch (selectmenu)
                {
                    case "1":
                        // 학생 정보 입력 메뉴
                        menu.insertMenu();
                        break;

                    case "2":
                        // 전체 학생 목록 보기 메뉴
                        menu.contentsMenu();
                        break;

                    case "3":
                        // 성적 순 나열 메뉴
                        menu.sortMenu();
                        break;

                    case "4":
                        // 정보 삭제 메뉴
                        menu.deleteMenu();
                        break;

                    case "5":
                        // 정보 수정 메뉴
                        menu.modifyMenu();
                        break;

                    case "6":
                        return;

                    case "Y":
                        // 정보 초기화 메뉴
                        menu.resetMenu();
                        break;

                    default:
                        Console.Clear();
                        break;

                }

            }
        }
    }
}
