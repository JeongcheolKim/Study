using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using MySql.Data.MySqlClient;
using System.Data;

namespace GradeCalc
{
    class MariaDB
    {
        private MySqlConnection conn;

        // 싱글턴
        //private static MariaDB mariaDB = new MariaDB();
        //public static MariaDB DBinstance
        //{
        //    get { return mariaDB; }
        //}
        public int open()
        {
            int iRet = 0;
            // 접속 정보
            string server = "127.0.0.1";
            string database = "Grade_Management";
            string user = "root";
            string password = "1234";
            int port = 3306;
            string connStr = $"Server={server}; Database={database}; Port={port}; Uid={user}; Pwd={password};";

            conn = new MySqlConnection(connStr);

            try
            {
                Console.WriteLine("DB Opening...");
                conn.Open();
                Console.WriteLine("DB Opened.");
                iRet = 1;   // 정상 Open
            }
            catch(Exception ex)
            {
                Console.WriteLine("DB Open Failed : " + ex.ToString());
                iRet = -1; // 비정상 Open
            }
            return iRet;
        }

        // 데이터 입력, 삭제
        public int run(string sql)
        {
            int iRet = 0;
            try
            {
                Console.WriteLine("DB Connection...");
                MySqlCommand comm = new MySqlCommand(sql, conn);
                iRet = comm.ExecuteNonQuery();
                // 성공한 ROW 갯수 리턴함
            }
            catch(Exception ex)
            {
                iRet = -2;
                Console.WriteLine(ex.ToString());
            }
            return iRet;
        }


        // 데이터 검색
        public int selectInfo(string sql)
        {
            int iRet = 0;
            try
            {
                MySqlCommand comm = new MySqlCommand(sql, conn);
                MySqlDataReader dataRdr = comm.ExecuteReader();

                while(dataRdr.Read())
                {
                    Console.WriteLine($"이름 : {dataRdr[1]}");
                    Console.WriteLine($"점수 : 국어 '{dataRdr[2]}'/ 영어 '{dataRdr[3]}'/ 수학 '{dataRdr[4]}'");
                    Console.WriteLine($"평균 : {dataRdr[5]}");
                    Console.WriteLine();
                }
                dataRdr.Close();
                iRet = 1;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                iRet = -3;
            }
            return iRet;
        }

        //public int countInfo(string sql)
        //{
        //    int iRet = -1;

        //    try
        //    {
        //        MySqlCommand command = new MySqlCommand(sql, conn);
        //        MySqlDataReader dataRder = command.ExecuteReader();

        //        dataRder.Read();
        //        iRet = (int)dataRder[0];
 
        //        dataRder.Close();

        //    }
        //    catch (Exception ex)
        //    {
        //        if (isOpen())
        //        {
        //            conn.Close();
        //        }
        //        Console.WriteLine(ex.ToString());
        //        iRet = 0;
        //    }
        //    return iRet;
        //}


        //public bool isOpen()
        //{
        //    if (conn != null)   // 만약 객체 있으면 열려 있다 반환
        //        return true;
        //    else
        //        return false;
        //}
    }
}
