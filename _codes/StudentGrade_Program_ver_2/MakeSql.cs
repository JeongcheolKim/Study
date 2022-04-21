using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeCalc
{
   class MakeSql
    {
        string column = "INDEX";
        string column0 = "이름";
        string column1 = "국어";
        string column2 = "영어";
        string column3 = "수학";
        string column4 = "평균";

        // 정보 검색
        public string selectSql(string from, string select="*")
        {
            string sql =
                $"SELECT {select} FROM {from}";
            return sql;
        }

        // 정보 삽입
        public string insertSql(string from, string value0, int value1, int value2, int value3)
        {
            double AvgValue = (value1 + value2 + value3) / 3.0;
            string sql =
                $"INSERT INTO {from} ({column0}, {column1}, {column2}, {column3}, {column4}) " +
                $"VALUES ('{value0}', {value1}, {value2}, {value3}, {AvgValue})";

            return sql;
        }

        // 정보 삭제
        public string deleteSql(string from, string where)
        {
            string sql =
                $"DELETE FROM {from} where {column0} = '{where}'";

            return sql;
        }

        public string deleteAllSql(string from)
        {
            string sql =
                $"DELETE FROM {from}";

            return sql;
        }

        // 정보 정렬
        public string orderSql(string from, string select="*")
        {
            string sql =
                $"SELECT {select} FROM {from} " +
                $"ORDER BY {column4} DESC";

            return sql;
        }

        // 정보 수정
        public string updateSql(string from, string field, string field1, int value, string select)
        {
            string sql =
                $"UPDATE {from} " +
                $"SET {field1} = {value} " +
                $"WHERE {field} = '{select}'";

            return sql;
        }




        // 존재여부
        //public string existSql(string from, string target, string select="*")
        //{
        //    string sql =
        //        $"SELECT {select} FROM {from} " +
        //        $"WHERE {column0} = 'target'' ";

        //    return sql;
        //}

        // 총 인원 파악
        //public string countSql(string from, string select="*")
        //{
        //    string sql =
        //        $"SELECT COUNT({select}) FROM {from}";
        //    return sql;
        //}

    }
}
