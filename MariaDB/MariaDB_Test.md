[MariaDB 구축](https://sosopro.tistory.com/109)

-----------
# 1. MariaDB 준비
- MySql.Data.dll << 종속성에 참조 추가 필수

- using MySql.Data.MySqlClient;	<- MySql 클래스
- using System.Data;			<- DataSet 클래스


-------------
# 2. MariaDB 클래스 파악

**MySqlConnection**

    Open	             << 데이터베이스 연결 (데이터베이스 오픈)
    Close	             << 데이터베이스 연결해제
    CreateCommand        << MySqlCommand 객체를 만들고 반환함
    BeginTransaction     << 데이터베이스 트랜잭션 시작
    CommandText          << get,set 프로퍼티 , 쿼리문 담는데 사용   

**MySqlTransaction**

    데이터베이스에서 만들어지는 SQL 트랜잭션을 표시함
    - 조금 더 봐야할 듯
    
    Commit          << 작업 결과를 저장, 조작 완료됨 전달
    Rollback        << 작업 내용 원래 상태로 복구


- 객체 생성 및 매개변수


        MySqlConnection 객체 생성
        MySqlConnection 객체이름 = new MySqlConnection(스트링);

        [스트링] 은 접속 정보
        "server={서버IP}; user={유저ID}; database={데이터베이스이름}; port=3306; password{설정암호}";

        >>> port는 설치 시 포트값 기본 3306





**MySqlCommand**

    - 데이터베이스 operation 수행
    new MySqlCommand(string쿼리문, Connection객체)

    MySqlCommand.ExecuteReader() 메서드
        - 데이터를 받아오는 쿼리문에 사용 / MySqlDataReader 라는 클래스 객체로 리턴
    MySqlCommand.ExecuteNonQuery() 메서드
        - 데이터 삽입/삭제 시 사용 , 영향받은 ROW 수 return
    MySqlCommand.ExecuteScalar() 메서드
        - 하나의 값이 리턴되는 쿼리문에 사용


**MySqlDataReader**

    - SQL서버와 연결 유지 상태에서 한번에 한 레코드(ROW)씩 데이터 가져올 때 사용됨.
    
    위의 MySqlCommand.ExecuteReader() 로부터 리턴되는   
    MySqlDataReader 객체는 첫 ROW 이전에 포인터를 위치시킨다.
    
    따라서 MySqlDataReader의 Read() 메서드를 사용해서 처음 ROW로 이동시켜 주어야함.
    MySqlDataReader는 하나의 Connection에 하나만 Open되어 있어야 하고   
    사용이 종료되면 Close() 메서드 이용해서 닫아주어야함


**DataTable**

    Load(IDataReader)       << DataTable 이용해서 DataReader을 데이터 소스값으로 채움


