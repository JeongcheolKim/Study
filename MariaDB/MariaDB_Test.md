[MariaDB 구축] "https://sosopro.tistory.com/109"

using MySql.Data.MySqlClient;	<- MySql 클래스
using System.Data;			<- DataSet 클래스

MySql.Data.dll << 종속성에 참조 추가 필수


MySqlConnection 객체 생성
MySqlConnection conn = new MySqlConnection(connStr);


MySqlConnection
Open	<< 데이터베이스 연결 (데이터베이스 오픈)
Close	<< 데이터베이스 연결해제
CreateCommand << MySqlCommand 객체를 만들고 반환함
BeginTransaction	<< 데이터베이스 트랜잭션 시작
CommandText << get,set 프로퍼티 , 쿼리문 담는데 사용

MySqlTransaction
데이터베이스에서 만들어지는 SQL 트랜잭션을 표시함
- 조금 더 봐야할 듯





connStr 은 접속 정보
"server={서버IP}; user={유저ID}; database={데이터베이스이름}; port=3306; password{설정암호}";

>>> port는 설치 시 포트값 기본 3306





MySqlCommand - 데이터베이스 operation 수행
new MySqlCommand(string, conn)		<< 매개변수 string에 쿼리문, conn Connection 객체

MySqlCommand.ExecuteReader() 메서드
데이터를 받아오는 쿼리문에 사용 / MySqlDataReader 라는 클래스 객체로 리턴
MySqlCommand.ExecuteNonQuery() 메서드
데이터 삽입/삭제 시 사용
MySqlCommand.ExecuteScalar() 메서드
하나의 값이 리턴되는 쿼리문에 사용


MySqlDataReader - SQL서버와 연결 유지 상태에서 한번에 한 레코드(ROW)씩 데이터 가져올 때 사용됨.
위의 MySqlCommand.ExecuteReader() 로부터 리턴되는 MySqlDataReader 객체는 첫 ROW 이전에 포인터를 위치시킨다.
따라서 MySqlDataReader의 Read() 메서드를 사용해서 처음 ROW로 이동시켜 주어야함.
MySqlDataReader는 하나의 Connection에 하나만 Open되어 있어야 하고 사용이 종료되면 Close() 메서드 이용해서 닫아주어야함


```c
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace MariaDB
{
    class MariaUse
    {
        //Connection 객체 선언
        private MySqlConnection dbConnection;
        //싱글톤 - 객체 딱 하나만 만들기 위해서
        private static MariaUse mariaUse = new MariaUse();
        // 외부 객체에서 변수 참조 방법은 instance 메소드 하나로만 가능
        public static MariaUse instance
        {
            get { return mariaUse; }
        }

        // 생성자
        public MariaUse()
        {
        }

        public int open()
        {
            if (isOpen())
            {
                close();
            }

            int iret = 0; // interrupt return - 문제발생 변수

            string server = "127.0.0.1";
            string database = "data";
            int port = 3306;
            string user = "root";
            string password = "1234";
            string connectionStr = $"Server={server}; Database={database}; Port={port}; Uid={user}; Pwd={password};";

            dbConnection = new MySqlConnection(connectionStr);
            try
            {
                iret = 1;   // 정상 오픈
                dbConnection.Open();
                Console.Write("DB Open Complete");
            }
            catch(Exception ex)
            {
                Console.WriteLine("DB open problem : " + ex.Message.ToString());
                close();
                iret = -1;
            }
            return iret; // 정상 : 1 , 비정상 : -1
        }

        // open여부 확인
        public bool isOpen()
        {
            if (dbConnection != null)
                return true;    //dbConnection 객체가 있다면 - Open에서 Close 하기 위함
            else
                return false;   // 객체 없으면 Open 진행
        }

        // Close
        public int close()
        {
            int iret = 1;
            try
            {
                if(dbConnection != null)    // dbConnection 객체 존재하면
                {
                    dbConnection.Close();
                    Console.WriteLine("DB Close Complete");
                }
            }
            catch(Exception ex)
            {
                iret = -1;
            }
            dbConnection = null;    // dbConnection null
            return iret;    // 정상 : 1, 비정상 -1
        }
        

        //insert, update, delete [overloading] -> 성공한 row 갯수를 리턴함
        public int insert(string sql)
        {
            int iret = 0;
            try
            {
                Console.WriteLine("MariaDB Connection...");
                MySqlCommand mySqlCommand = new MySqlCommand(sql, dbConnection);
                iret = mySqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return iret;
        }

        public int update(string[] sqls)
        {
            int iret = 0;
            MySqlCommand cmd = dbConnection.CreateCommand();
            MySqlTransaction tran = dbConnection.BeginTransaction();

            cmd.Connection = dbConnection;
            cmd.Transaction = tran;

            if (dbConnection == null || tran == null)
                iret = -2;
            else
            {
                try
                {
                    for(int i = 0; i < sqls.Length; i++)
                    {
                        cmd.CommandText = sqls[i];  // 커맨드 텍스트에 쿼리문 반복하면서 대입
                        iret += cmd.ExecuteNonQuery();  // 정상이면 1 리턴
                    }
                }
            }
        }




    }
}
```