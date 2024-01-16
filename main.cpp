#include <iostream>

using namespace std;



int main() {

 int num,tam,cant,t,ban=0, pos=0;

 int vec[]= {70,20,30};

 cout << "Ingrese su numero a evaluar ";

 cin >> num;
 tam = sizeof(vec);
 cant = sizeof(int);
 t =tam/cant;
 
for(int k=0;k<=t;k++){
	if(num==vec[k]){
	 ban=1;}}
if(ban==1){
	 cout<<"\nElnumero  "<< num<<"\nSe encuentra en la posicion  "<<"["<<k+1<<"]";
	 break;
}else
	 cout<<"\nElnumero  "<< num<<"\nNo se encuentra  ";
	 break;
}

