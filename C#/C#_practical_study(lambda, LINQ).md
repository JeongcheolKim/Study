
람다식과 LINQ 기초

델리게이트 – 델리게이트로 선언하면 메서드를 인수로 넘길 수 있다.
/////////////////////////////////////////////////////
Judgement judge = IsEven;
var count = Count(numbers, judge)


int Count(int [] numbers, Judgement judge)

bool IsEven(int n)

delegate bool Judgement(int value)
/////////////////////////////////////////////////////////

에서 var count = Count(numbers, IsEven) 으로 대입 가능

.NetFramework 2.0-----------------------------------------
더 나가서 var count = Count(numbers, delegate(int n) {return n%2 == 0;} ); 
으로 익명 메서드로 적용할 수 있다.
대신 int Count(int [] numbers, Predicate<int> judge) { }
로 변경

public delegate bool Predicate<in T> (T obj);
어떤 기준을 만족하는지 판단하는 메서드 / Judgement 델리게이트를 자기가 직접 정의하지 않아도 됨 / 위는 int로 지정해두어서 int형 받아서 bool 반환하는 메서드 넘길 수 있다.

Count 메서드를 호출하는 Do 메서드는 delegate 키워드를 사용해서 직접 메서드 정의하고 그걸 Count메서드에게 넘겨줌
이 delegate 키워드를 사용해서 정의한 메서드를 익명 메서드 라고 함.


C# 3.0----------------------------------------------------------
람다식 도입
var count = Count(numbers, n => n% 2 == 0);
 가장 풀어쓴 형태 (int n 부터 중괄호 끝까지가 람다식  judge 변수에 대입)
Predicate<int> judge =
	(int n) => {
	   if (n % 2 == 0)
		return true;
	   else
		return false;
	};
var count = Count(numbers, judge);


람다식은 일종의 메서드 delegate 키워드 대신 => (람다 연산자) 사용
 step 1 한번 간단하게
judge 변수 없앰 식을 직접 Count 메서드 인수로 지정
var count = Count(numbers,
	(int n) => {
		if(n % 2 == 0)
			return true;
		else
			return false;
}
);

step 2
return 오른쪽에 식을 쓸 수 있고 if 조건문이 bool 형식 값이므로 if문 제거
var count = Count( numbers, (int n) => {return n % 2 == 0;} );

step 3
람다식에서 {} 가 하나의 명령문 포함하면 {} 와 return 생략
var count = Count( numbers, (int n) => n % 2 == 0 )

step 4
람다식에서 인수 형 생략 가능. 컴파일러가 잡아줌
var count = Count( numbers, (n) => n % 2 == 0 );

step 5
인수가 한개인 경우 () 생략 가능
var count = Count( numbers, n => n % 2 == 0 );
 

List<T> 클래스와 람다식의 조합
List<T> 클래스에는 델리게이트를 인수로 받는(람다식을 인수로 받는) 메서드가 다수.

ex)
var list = new List<string> {
	“Seoul”, “New Delhi”, “Bangkok”, “London”, “Paris”, “Berlin”, Canberra”, “Hong Kong”, };
