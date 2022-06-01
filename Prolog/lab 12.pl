%Наибольший общий делитель
nod(0,X,X):-!.
nod(X,Y,Z):- X1 is Y mod X, nod(X1,X,Z).

%Проверка числа на простоту
pr(X,X):-!.
pr(X,I):- X1 is X mod I, X1 \= 0, I1 is I + 1, pr(X,I1).
prost(X):-pr(X,2),!.

%Проверка на не взаимную простоту
not_vz_prost(X,Y):- nod(X,Y,Z), Z \= 1.

%Задание 11 (рекурсия вверх)
el_up(_,1,0):-!.
el_up(X,I,Ans):-  I1 is I - 1, el_up(X,I1,A), (Z is I1 mod 2, Z is 0, not_vz_prost(X,I1),Cur is 1; Cur is 0), Ans is A + Cur.
eleven_up(X,Ans):- el_up(X,X,Ans),!.

%Задание 11(рекурсия вниз)
el_down(_,1,Count,Count):-!.
el_down(X,I,Count,Ans):- I1 is I - 1, Z is I1 mod 2, Z is 0, not_vz_prost(X,I1), C is Count + 1, el_down(X,I1,C,Ans).
el_down(X,I,Count,Ans):- I1 is I - 1, el_down(X,I1,Count,Ans).
eleven_down(X,Ans):- el_down(X,X,0,Ans),!.





