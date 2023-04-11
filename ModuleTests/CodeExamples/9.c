#include <stdio.h>  		// подключаем заголовочный файл stdio.h
#include<locale.h>  
#include<stdlib.h>
#include<time.h>
int main(void)                  
{  
int chislo1,chislo2,prov;
int min,max,i,j,kolvo,kolvobol,etaj[4];
int top[10];
float summa;  //chislo - переменное для числа вводимое пользователем        
setlocale(LC_ALL,"Russian");	//Руссификация              
    
srand(time(NULL));
int mass[10][4];	
chislo1=0;
kolvo=0;

for (i = 9; i >= 1; i--) 
{
	top[i]=0;
	printf("Этаж %d: \n",i);		
	for (j = 0; j <= 3; j++) 
	{		
		mass[i][j]= rand()%7;		// записывается рандомное число
		printf("кв.%d - %d ",(i-1)*4+j+1,mass[i][j]);
		top[i]=mass[i][j]+top[i];	//сумируется шум на каждый этаж
		if(mass[i][j]>4)
				
		if (j!=3)				// условие для запятой что бы она не ставилась в конце
		{
			printf(",");
		}	
	}
	printf("\n");	
}

	
	printf("Топ самых шумных этажей:\n");
	for (i = 1; i <= 3; i++) 
	{	
		max=0;
		for (j = 1; j <= 9; j++) 
		{
			
			if(top[j] >= max)			
			{
				etaj[i]=j;
				max=top[j];		//находится максимальный шум
			}
		
		}
		printf("%d место - Этаж %d (кв. %d(%d ш.е),кв. %d(%d ш.е),кв. %d(%d ш.е),кв. %d(%d ш.е))",i,etaj[i],etaj[i]*4+0+1,mass[etaj[i]][0]*3,etaj[i]*4+1+1,mass[etaj[i]][1]*3,etaj[i]*4+2+1,mass[etaj[i]][2]*3,etaj[i]*4+3+1,mass[etaj[i]][3]*3);	
		top[etaj[i]]=0;
		for (j = 1; j <= 9; j++) 
		{
			if(top[j]==max )			//нахождение второго этажа на одно месте топа		
			{
				printf(", - Этаж %d (кв. %d(%d ш.е),кв. %d(%d ш.е),кв. %d(%d ш.е),кв. %d(%d ш.е))",i,i*4+0+1,mass[i][0]*3,i*4+1+1,mass[i][1]*3,i*4+2+1,mass[i][2]*3,i*4+3+1,mass[i][3]*3);	
				top[j]=0;
			}
		}
		printf("\n");	
	}

printf("\n");

return 0;	
}                               