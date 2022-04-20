# p 41. 매출 계산 프로그램

Main 메서드에서 SalesCounter 클래스 인스턴스 먼저 생성함.
생성자로 넘겨주는 객체는 ReadSales 메서드에서 반환된 List<Sale> 객체
점포 별 매출액 집계 후 - foreach문에서 딕셔너리에 저장된 요소를 꺼내서 해당 Key, Value를 출력함.

Dictionary<string, int> amountPerStore = new Dictionary<string, int>();      ->> 이렇게 객체 생성하면 '안된다'
amountPerStore = sales.GetPerStoreSales();

new를 통해 객체가 생성되지만 그 다음 GetPerStoreSales 메서드 안에서 (Dictionary 객체 생성이 포함되어 있다)
 내부에서 생성된 객체의 참조를 반환하기 때문에 메모리 낭비         ->> 그럼 매개변수로 dictionary를 넘겨주고 내부에서 객체생성을 안하면?


# 인터페이스 적용하기
 
List – 정의로 이동해보면 List<T> 클래스는 ILIST<T> 인터페이스가 정의한 메서드 속성을 포함하는 것을 알 수 있다.   
 -> ‘ List<T> 클래스가 IList<T> 인터페이스를 구현한다 ’ 라고 함.
 
ICollection<T> 도 포함하고 있다. – 포함된 메서드와 속성에서 **Add,Clear(메서드)  Count, IsReadOnly(속성)**  등 확인 가능.
 
-	List<int> list = new List<int>() { .... };
-	ICollection<T> collection = list	<- List<T> 는 ICollection<T>의 인터페이스를 갖고 있으므로 대입 가능
-	var count = collection.Count	<- 사용가능
-	collection.Add(6)	<- 사용가능



## 인터페이스 관련 기억하기
 
  1.	A 클래스가 IX 인터페이스를 구현했다면 A 객체는 IX 형 변수에 대입될 수 있다.
  2.	IX 형 변수는 IX 인터페이스가 정의하는 속성과 메서드를 사용할 수 있다.
  3.	속성이나 메서드가 실행할 수 있는 구체적인 동작은 IX 인터페이스가 아니라 A 클래스에 작성된다.



매출 집계 프로그램에 인터페이스 도입
List<Sale>    ->    IEnumerable<Sale>
Dictionary<string, int>    ->    IDictionary<string, int>

메서드명, 멤버변수명에만 적용
메서드 내부에서는 그대로 List, Dictionary를 사용함

메서드 반환값, 인수를 인터페이스로 적용하면 좋은 점?
프로그램 수정에 용이하다.
-	SalesCounter 생성자로 List<Sale> 말고 Sale 배열도 받아들이고 싶을 때, SalesCounter 클래스를 수정하지 않아도 됨. (배열도 IEnumerable<T>를 구현했기 때문에
-	SalesCounter 생성자 안에서 sales 객체가 오버라이드 되지 않는다는 점. IEnumerable<T>에는 List<T> 클래스에 정의된 Add, Remove 같은 메서드가 없음

IDictionary
호출 쪽에도 수정
메서드 내부에서 Dictionary를 SortedDictionary로 수정해야 한다고 할 때,
메서드 내부 Dictionary는 SortedDictionary로 수정하지만 메서드의 반환값은 IDictionary로 하면 호출하는 쪽에서는 수정할 필요가 없다는 것. (구체적인 형이 아니라 인터페이스를 대상으로 코드 작성했으므로)

‘ 구체적인 클래스가 아닌 인터페이스에 대해 프로그래밍 ‘ <- 객체지향
List<int> list = new List<int>();
ICollection<int> collection = list;		<- List<T>는 ICollection<T>를 구현해으므로
IEnumerable<int> enumerable = list;





# var 암시형 사용하기
= 기호를 사이에 두고 양 변에 클래스 명이 나오는 구문들
매서드 안에서 지역변수 선언할 때, var 키워드 사용하면 C# 컴파일러가 자동으로 형을 판단함
GetPerStoreSale() 메서드에서
Dictionary 객체 생성 시 / foreach Sale 객체에 각각 var 사용

메인 메서드에서
Sale, Dictionary, foreach dictionary 부분을 var 로 치환

-	우변의 변수 형이 분명할 경우 or 엄밀하게 형을 지정하지 않아도 될 경우 var 사용
-	dynamic 대신 var 사용하지 않기
-	for 문이나 foreach 문에서 루프 변수 형 지정할 때 var로 지정 가능


