SQL ZOO 사이트 기준 
0 SELECT basics, 
1 SELECT name	-quiz
2. SELECT from World	-quiz
까지 진행

SELECT
FROM
WHERE
IN		- 원하는 조건 안에 A IN (‘abc’)	A컬럼 중에서 abc 항목만
LIKE		- 포함되는 조건? ~와 같은지 확인 문자열 확인, A LIKE ‘Y%’ ->Y로 시작하는 단어 전부
BETWEEN	- 어디부터 어디까지 표현할때/ BETWEEN 1 AND 10
ROUND(A, I)	- A를 B소숫점 갯수만큼 반올림. ( - 붙이면 반대로 올라옴 -3이면 1000자리로 반올림)
LENGTH(A)	- A 문자열 길이로 반환
LEFT(A, I)	- A 문자열에서 I 숫자만큼 왼쪽에서 읽음 / LEFT(‘HELLO’, 2) -> HE
CONCAT(A, B)	-A랑 B 문자열 합치기
문자열 작은따옴표 안에, %사용하면 전부, _ 사용하면 한글자, +연산자로 합치기 가능



질문?
XOR 간략화 방법
SELECT name, population, area 
FROM world 
WHERE   (area > 3000000 AND population < 250000000) 
OR     (area < 3000000 AND population > 250000000)

