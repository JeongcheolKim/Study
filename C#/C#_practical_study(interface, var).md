# p 41. 매출 계산 프로그램

- 클래스 내부의 메서드에 Dictionary 객체를 생성하고 있을 경우   
    Main 메서드에서   
    Dictionary<string, int> amountPerStore = new Dictionary<string, int>();       
    ->> 이렇게 객체 생성하면 '안된다'
    
        new를 통해 객체가 생성되지만 클래스 내부 메서드가 호출되면서   
        메서드 안에서 객체가 재생성.
        내부에서 생성된 객체의 참조를 반환하기 때문에 처음 생성된 객체를 사용하지 않는다.


# 인터페이스 적용하기
 
List – 정의   
    
    List<T> 클래스는 ILIST<T> 인터페이스가 정의한 메서드 속성을 포함.   
    -> ‘ List<T> 클래스가 IList<T> 인터페이스를 구현한다.
 
ICollection<T> 도 포함.   
– 포함된 메서드와 속성에서 **Add,Clear(메서드)  Count, IsReadOnly(속성)**  등 확인 가능.
 
    - List<int> list = new List<int>() { .... };
    - ICollection<T> collection = list	     <- List<T> 는 ICollection<T>의 인터페이스를 갖고 있으므로 대입 가능
    - var count = collection.**Count**	     <- 사용가능
    - collection.**Add**(6)	                     <- 사용가능



## 인터페이스 관련 기억하기
 
    - A 클래스가 IX 인터페이스를 구현했다면 A 객체는 IX 형 변수에 대입될 수 있다.
    - IX 형 변수는 IX 인터페이스가 정의하는 속성과 메서드를 사용할 수 있다.
    - 속성이나 메서드가 실행할 수 있는 구체적인 동작은 IX 인터페이스가 아니라 A 클래스에 작성된다.

**********************

매출 집계 프로그램에 인터페이스 도입
List<Sale>    ->    IEnumerable<Sale>
Dictionary<string, int>    ->    IDictionary<string, int>

메서드명, 멤버변수명에만 적용
메서드 내부에서는 그대로 List, Dictionary를 사용함

- 메서드 반환값, 인수를 인터페이스로 적용하면 좋은 점?
    
        프로그램 수정에 용이하다.
        - SalesCounter 생성자로 List<Sale> 말고 Sale 배열도 받아들이고 싶을 때,   
          SalesCounter 클래스를 수정하지 않아도 됨. (배열도 IEnumerable<T>를 구현했기 때문에
          SalesCounter 생성자 안에서 sales 객체가 오버라이드 되지 않는다는 점.   
        - IEnumerable<T>에는 List<T> 클래스에 정의된 Add, Remove 같은 메서드가 없음

IDictionary
호출 쪽에도 수정
메서드 내부에서 Dictionary를 SortedDictionary로 수정해야 한다고 할 때,
메서드 내부 Dictionary는 SortedDictionary로 수정하지만 메서드의 반환값은 IDictionary로 하면 호출하는 쪽에서는 수정할 필요가 없다는 것. (구체적인 형이 아니라 인터페이스를 대상으로 코드 작성했으므로)

    
    
‘ 구체적인 클래스가 아닌 인터페이스에 대해 프로그래밍 ‘ <- 객체지향
List<int> list = new List<int>();
ICollection<int> collection = list;		<- List<T>는 ICollection<T>를 구현해으므로
IEnumerable<int> enumerable = list;





# var 암시형 사용하기
" = "(Equal) 기호를 사이에 두고 양 변에 클래스 명이 나오는 구문들
    
    매서드 안에서 지역변수 선언할 때, var 키워드 사용하면 C# 컴파일러가 자동으로 형을 판단
    
GetPerStoreSale() 메서드에서
Dictionary 객체 생성 시 / foreach Sale 객체에 각각 var 사용

메인 메서드에서
Sale, Dictionary, foreach dictionary 부분을 var 로 치환

## var 사용 Tip
    -	우변의 변수 형이 분명할 경우 or 엄밀하게 형을 지정하지 않아도 될 경우 사용
    -	dynamic 대신 var 사용하지 않기
    -	for 문이나 foreach 문에서 루프 변수 형 지정할 때 사용



'''c
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App   // 프로그램과 동일하게 해주면 그대로 사용가능
{
    public class Sale // 판매 정보 객체
    {
        public string ShopName { get; set; }
        public string ProductCategory { get; set; }
        public int Amount { get; set; }

    }

    // 점포 별 매출 계산
    public class SalesCounter
    {
        private IEnumerable<Sale> _sales;

        //생성자
        public SalesCounter(List<Sale> sales)   // List<Sale> 객체 받아서 private _sales에 대입
        {
            _sales = sales;
        }

        public SalesCounter(string filepath)
        {
            _sales = ReadSales(filepath);
        }

        // 매출 계산
        public IDictionary<string, int> GetPerStoreSales()   // Dictionary(반환값)에 key값(점포이름) 기준으로 value 합산하는 방식
        {
            var dict = new Dictionary<string, int>();
            foreach(var sale in _sales)    //_sales 딕셔너리에서 Sale 객체 하나씩 꺼냄
            {
                if (dict.ContainsKey(sale.ShopName))    // sale객체의 ShopName이 dict의 key값으로 저장되어 있는지 확인
                    dict[sale.ShopName] += sale.Amount; // 이미 있는 key의 경우 원래 value에 지금 value 합산
                else // key값 저장되어 있지 않을 경우 dict의 key값에 sale.Amount(value) 값 대입하며 저장
                    dict[sale.ShopName] = sale.Amount;
            }
            return dict;    // 결과 Dictionary 반환
        }

        private static IEnumerable<Sale> ReadSales(string filePath)    //파일 경로에서 파일 읽기
        {
            List<Sale> sales = new List<Sale>();    // 리스트 객체 생성( Sale 클래스 객체 )
            string[] lines = File.ReadAllLines(filePath);   // 경로의 파일에서 모든 라인 읽기
            foreach (string line in lines)   // 한 줄 씩 읽기
            {
                string[] items = line.Split(',');   // 콤마로 구분 된 것 나누어서 item 배열에
                Sale sale = new Sale    // Sale 객체
                {
                    ShopName = items[0],    // 처음 요소 가게이름
                    ProductCategory = items[1], // 두번째 요소 물건 카테고리
                    Amount = int.Parse(items[2])    // 세번째 요소 수량
                };
                sales.Add(sale); // sales 리스트 객체에 sale 객체 추가
            }
            return sales;   // sales 리스트 객체 반환
        }
    }
}
'''


'''c
using System.IO;


namespace App // 클래스와 같게 해주면 그대로 사용 가능
{
    class Program
    {
        static void Main(string[] args)
        {
            var sales = new SalesCounter("sales.csv");  //파일경로에서 파일 읽기 - 객체 대입
            var amountPerStore = sales.GetPerStoreSales();  //매점 별 매출 계산

            foreach (var obj in amountPerStore)
            {
                Console.WriteLine("{0} {1}", obj.Key, obj.Value);
            }
        }

        
    }
}

//Main 메서드에서 SalesCounter 클래스 인스턴스 먼저 생성함.
// 생성자로 넘겨주는 객체는 ReadSales 메서드에서 반환된 List<Sale> 객체
// 점포 별 매출액 집계 후 - foreach문에서 딕셔너리에 저장된 요소를 꺼내서 해당 Key, Value를 출력함.

// Dictionary<string, int> amountPerStore = new Dictionary<string, int>();      ->> 이렇게 객체 생성하면 '안된다'
// amountPerStore = sales.GetPerStoreSales();

//new를 통해 객체가 생성되지만 그 다음 GetPerStoreSales 메서드 안에서 (Dictionary 객체 생성이 포함되어 있다)
// 내부에서 생성된 객체의 참조를 반환하기 때문에 메모리 낭비         ->> 그럼 매개변수로 dictionary를 넘겨주고 내부에서 객체생성을 안하면?
'''

