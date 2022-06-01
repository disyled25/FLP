%Grater common divisor
gcd(0,X,X):-!.
gcd(X,Y,Z):- X1 is Y mod X, gcd(X1,X,Z).

%Check if number is prime
pr(X,X):-!.
pr(X,I):- X1 is X mod I, X1 \= 0, I1 is I + 1, pr(X,I1).
prost(X):-pr(X,2),!.

%Check if two numbers isn't coprime
not_coprime(X,Y):- gcd(X,Y,Z), Z \= 1.

%Find minimal divisor of number
md(1,_,1):-!.
md(X,I,Ans):-X1 is X mod I, X1 is 0, Ans is I,!.
md(X,I,Ans):-I1 is I + 1, md(X,I1,Ans).
mdiv(X,Ans):- md(X,2,Ans).


%Exercise 11 (up)
el_up(_,1,0):-!.
el_up(X,I,Ans):-  I1 is I - 1, el_up(X,I1,A),
    (Z is I1 mod 2, Z is 0, not_coprime(X,I1),
     Cur is 1; Cur is 0), Ans is A + Cur.

eleven_up(X,Ans):- el_up(X,X,Ans),!.

%Exercise 11(down)
el_down(_,1,Count,Count):-!.
el_down(X,I,Count,Ans):- I1 is I - 1, Z is I1 mod 2,
    Z is 0, not_coprime(X,I1), C is Count + 1, el_down(X,I1,C,Ans).
el_down(X,I,Count,Ans):- I1 is I - 1, el_down(X,I1,Count,Ans).

eleven_down(X,Ans):- el_down(X,X,0,Ans),!.

%Exercise 12
sum_dig_les_5(0,Sum,Sum):-!.
sum_dig_les_5(X,Sum,Ans):- Cur is X mod 10, Cur < 5, Nsum is Sum + Cur,
    X1 is X div 10, sum_dig_les_5(X1,Nsum,Ans).
sum_dig_les_5(X,Sum,Ans):- X1 is X div 10, sum_dig_les_5(X1,Sum,Ans).
sum_digits_lesser_5(X,Ans):-sum_dig_les_5(X,0,Ans),!.

tw(X,X,Max,Max):-!.
tw(X,I,Max,Ans):- not_coprime(X,I), mdiv(X,Div), I1 is I mod Div, I1 is 0,
    I > Max, Max1 is I, I2 is I + 1, tw(X,I2,Max1,Ans).
tw(X,I,Max,Ans):- I2 is I + 1, tw(X,I2, Max,Ans).
twelve(X,Ans):- tw(X,1,0,A1), sum_digits_lesser_5(X,A2), Ans is A1*A2,!.


