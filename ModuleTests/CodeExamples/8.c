#include <stdio.h>
#include <time.h>
#include <stdlib.h>
#include <locale.h>
#include <math.h>
int main(void)
{
	setlocale(LC_ALL,"Russian");
	int count;
	printf("Укажите целое число кол-во(count) элементов в массиве\n");
	scanf("%d",&count);
	int a[100],ma,mi,k,sm;
	float sr;
	srand(time(NULL));
	sm=0;
	k=0;
	sr=0;
	for (int i =0;i<count;i++){
		a[i] =rand()%201 - 100;
		printf("%d ",a[i]);
		sm= sm + a[i];
	}
	sr = (float)sm/count;
	
	printf(" \n");
	//ma=-100;
	ma=0;
	mi=100;
	for (int i =0;i<count;i++){
		if (abs(a[ma]) < abs(a[i])) {
			ma = i;
		}
		if (mi > a[i]) {
			mi = a[i];
		}
		if (sr < a[i]) {
			k+=1;
		}
	}
	printf("макс значение матрицы: %d\n",a[ma]);
	printf("мин значение матрицы: %d\n",mi);
	printf("Среднее арифметическое: %f\n",sr);
	printf("Кол-во чисел больше сред. ариф.: %d\n",k);
	return(0);
}