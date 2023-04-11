#include <stdio.h>  		// подключаем заголовочный файл stdio.h
#include<locale.h>  
#include<stdlib.h>
#include<time.h>
int main(void)                  
{  
int chislo1,chislo2,prov;
int min,max,i,j,kolvo,kolvobol;
float summa;  //chislo - переменное для числа вводимое пользователем        
setlocale(LC_ALL,"Russian");	//Руссификация
do{               
    printf("Введите кол-во столбцов\n");
prov = scanf("%i", &chislo2);	//Проверка на число
fflush(stdin);					//Убирает зацикливаение
}while ( prov!=1 || (chislo2>100) || (chislo2<1));  //если это число с диапазоном от 1 до 9 то проходит

srand(time(NULL)); //Функция для генерации случайных чисел
int mass[chislo2];	
min=101;
max=0;
kolvobol=0;

	for (j = 1; j <= chislo2; j++) 
	{
		mass[j]= rand()%101-50;	//Записывание рандомного числа в массив с диапазоном от -50 до 50 
		summa=summa+mass[j];
		if(mass[j]<min) 		//Нахождение минимального числа
			{
			min=mass[j];
			}
			
		if(mass[j]>max)			//Нахождение максимального числа по модулю если число положительное
			{
			max=mass[j];
			i=j;
			}	
		if(mass[j]*(-1)>max)	//Нахождение максимального числа по модулю если число отрицательное
			{
			max=mass[j];
			i=j;
			}				
	}


	for (j = 1; j <= chislo2; j++) //Цыкл для вывода массива
	{
	printf("%d",mass[j]);			// вывод массива на экран
		if (j!=chislo2)				// условие для запятой что бы она не ставилась в конце
		{
		printf(",");
		}
		if(mass[j]>summa/chislo2)
		{
		kolvobol++;
		}
	}	
printf("\n");
printf("Максимальный элемент %d \n",mass[i]);
printf("Минимальный элемент %d\n",min);
printf("Среднее арифметическое значений элементов массива %.1f\n",summa/chislo2);
printf("Количество элементов массива, значение которых больше среднегоарифметического %d\n",kolvobol);
return 0;	
}                               