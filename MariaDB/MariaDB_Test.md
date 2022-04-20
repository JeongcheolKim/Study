[MariaDB 구축] "https://sosopro.tistory.com/109"

using MySql.Data.MySqlClient;	<- MySql 클래스
using System.Data;			<- DataSet 클래스


MySqlConnection 객체 생성
MySqlConnection conn = new MySqlConnection(connStr);

connStr 은 접속 정보
"server={서버IP}; user={유저ID}; database={데이터베이스이름}; port=3306; password{설정암호}";

>>> port는 설치 시 포트값 기본 3306

conn.Open();	<< SQL 연결